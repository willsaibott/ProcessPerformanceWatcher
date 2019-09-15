using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using ProcessPerformanceWatcher;

namespace ProcessPerformanceWatcher {
    public class ProcessWatcher {
        private String _instance_name;
        private String _network_adapter;
        private long   _pid;

        public MovingAverage[] values { get; private set; } =
            new MovingAverage[20] {
                new MovingAverage(), new MovingAverage(), new MovingAverage(),
                new MovingAverage(), new MovingAverage(), new MovingAverage(),
                new MovingAverage(), new MovingAverage(), new MovingAverage(),
                new MovingAverage(), new MovingAverage(), new MovingAverage(),
                new MovingAverage(), new MovingAverage(), new MovingAverage(),
                new MovingAverage(), new MovingAverage(), new MovingAverage(),
                new MovingAverage(), new MovingAverage()
            };
        public bool is_running { get; private set; }

        NetworkPerformanceReporter reporter;
        Thread _thread;
        public void Start() => _thread.Start();
        public void Join()  => _thread.Join();
        public bool IsAlive => _thread.IsAlive;

        public ProcessWatcher(String process_name, String network_adapter) {
            _instance_name = process_name;
            if (network_adapter == null || network_adapter == "") {
                throw new Exception("Network adapter invalid");
            }
            _network_adapter = network_adapter;
            _thread = new Thread(new ThreadStart(this.QueryIOActivity));
        }

        public ProcessWatcher(int process_pid, String network_adapter)
            : this(PerformanceCounterInstanceName(process_pid), network_adapter) {
            reporter = new NetworkPerformanceReporter(process_pid);
        }

        public void stop() {
            is_running = false;
        }

        private void QueryIOActivity() {
            is_running = true;
            try {
                var counters = new List<PerformanceCounter> {
                    new PerformanceCounter("Process",           "IO Read Operations/sec",  _instance_name,   true),
                    new PerformanceCounter("Process",           "IO Write Operations/sec", _instance_name,   true),
                    new PerformanceCounter("Process",           "IO Data Operations/sec",  _instance_name,   true),
                    new PerformanceCounter("Process",           "IO Read Bytes/sec",       _instance_name,   true),
                    new PerformanceCounter("Process",           "IO Write Bytes/sec",      _instance_name,   true),
                    new PerformanceCounter("Process",           "IO Data Bytes/sec",       _instance_name,   true),
                    new PerformanceCounter("Network Interface", "Bytes Sent/sec",          _network_adapter, true),
                    new PerformanceCounter("Network Interface", "Bytes Received/sec",      _network_adapter, true),
                };
                reporter.Initialise();
                while (is_running) {
                    for (var ii = 0; ii < counters.Count; ii++) {
                        values[ii].add_sample(counters[ii].NextValue());
                    }
                    var data = reporter.GetNetworkPerformanceData();
                    values[counters.Count]  .add_sample(data[0].BytesSent);
                    values[counters.Count+1].add_sample(data[0].BytesReceived);
                    values[counters.Count]  .add_sample(data[0].TotalBytesSent);
                    values[counters.Count+1].add_sample(data[0].TotalBytesReceived);
                    values[counters.Count+2].add_sample(data[1].BytesSent);
                    values[counters.Count+3].add_sample(data[1].BytesReceived);
                    values[counters.Count+2].add_sample(data[1].TotalBytesSent);
                    values[counters.Count+3].add_sample(data[1].TotalBytesReceived);
                }
            }
            catch (Exception ex) {
                Console.Error.WriteLine( "Error on instance: " + _instance_name + "Error:" + ex.Message);
                Console.Error.WriteLine(ex.StackTrace);
            }
        }

        public static string PerformanceCounterInstanceName(int pid) {
            Process process = Process.GetProcessById(pid);
            if (process != null) {
                var matchesProcessId = new Func<string, bool>(instanceName => {
                    using (var pc = new PerformanceCounter("Process", "ID Process", instanceName, true)) {
                        if ((int)pc.RawValue == process.Id) {
                            return true;
                        }
                    }
                    return false;
                });

                string processName = Path.GetFileNameWithoutExtension(process.ProcessName);
                return new PerformanceCounterCategory("Process")
                   .GetInstanceNames()
                   .AsParallel()
                   .FirstOrDefault(instanceName => instanceName.StartsWith(processName)
                                                   && matchesProcessId(instanceName));
            }
            throw new Exception("Process with pid " + pid + "does not exist");
        }
    }
}
