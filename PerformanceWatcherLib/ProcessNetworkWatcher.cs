using Microsoft.Diagnostics.Tracing.Parsers;
using Microsoft.Diagnostics.Tracing.Session;
using System;
using System.Threading.Tasks;

namespace ProcessPerformanceWatcher {
    public class NetworkPerformanceReporter : IDisposable {
        private DateTime          _EtwStartTime;
        private TraceEventSession _EtwSession;

        private readonly Counter _tcp_counter = new Counter();
        private readonly Counter _udp_counter = new Counter();
        private long _pid = 0;

        private class Counter {
            public long Received;
            public long Sent;
        }

        public NetworkPerformanceReporter(long pid) {
            _pid = pid;
        }

        public void Initialise() {
            // Note that the ETW class blocks processing messages,
            // so should be run on a different thread if you want the
            // application to remain responsive.
            Task.Run(() => StartEtwSession());
        }

        private void StartEtwSession() {
            try {
                ResetCounters();
                using (_EtwSession = new TraceEventSession("MyKernelAndClrEventsSession")) {
                    _EtwSession.EnableKernelProvider(
                        KernelTraceEventParser.Keywords.NetworkTCPIP);
                    _EtwSession.Source.Kernel.TcpIpRecv += data => {
                        if (data.ProcessID == _pid) {
                            lock (_tcp_counter) {
                                _tcp_counter.Received += data.size;
                            }
                        }
                    };
                    _EtwSession.Source.Kernel.TcpIpSend += data => {
                        if (data.ProcessID == _pid) {
                            lock (_tcp_counter) {
                                _tcp_counter.Sent += data.size;
                            }
                        }
                    };
                    _EtwSession.Source.Kernel.UdpIpRecv += data => {
                        if (data.ProcessID == _pid) {
                            lock (_udp_counter) {
                                _udp_counter.Received += data.size;
                            }
                        }
                    };
                    _EtwSession.Source.Kernel.UdpIpSend += data => {
                        if (data.ProcessID == _pid) {
                            lock (_udp_counter) {
                                _udp_counter.Sent += data.size;
                            }
                        }
                    };
                    _EtwSession.Source.Process();
                }
            }
            catch {
                ResetCounters(); // Stop reporting figures
                // Probably should log the exception
            }
        }

        private NetworkPerformanceData
        GetPerformanceData(Counter counter, double interval) {
            NetworkPerformanceData networkData;
            lock (counter) {
                networkData = new NetworkPerformanceData(counter.Received,
                                                         counter.Sent,
                                                         interval);
            }
            return networkData;
        }

        public NetworkPerformanceData[]
        GetNetworkPerformanceData() {
            var interval_sec = (DateTime.Now - _EtwStartTime).TotalSeconds;
            var tcp = GetPerformanceData(_tcp_counter, interval_sec);
            var udp = GetPerformanceData(_udp_counter, interval_sec);

            // Reset the counters to get a fresh reading for
            // next time this is called.
            ResetCounters();
            return new NetworkPerformanceData[]{ tcp, udp };
        }

        private void ResetCounters() {
            lock (_tcp_counter) {
                _tcp_counter.Sent = 0;
                _tcp_counter.Received = 0;
            }
            lock (_udp_counter) {
                _udp_counter.Sent = 0;
                _udp_counter.Received = 0;
            }
            _EtwStartTime = DateTime.Now;
        }

        public void Dispose() {
            _EtwSession?.Dispose();
        }

        public sealed class NetworkPerformanceData {
            public long BytesReceived      { get; private set; }
            public long BytesSent          { get; private set; }
            public long TotalBytesSent     { get; private set; }
            public long TotalBytesReceived { get; private set; }

            public NetworkPerformanceData(long recv_b,
                                          long sent_b,
                                          double interval) {
                BytesReceived      = Convert.ToInt64(recv_b / interval);
                BytesSent          = Convert.ToInt64(sent_b / interval);
                TotalBytesReceived = Convert.ToInt64(recv_b);
                TotalBytesSent     = Convert.ToInt64(sent_b);
            }
        }
    }

}
