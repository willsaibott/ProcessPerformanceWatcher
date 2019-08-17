using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace ProcessPerformanceWatcher {
    class ProcessWatcher
    {
        private String instance_name;
        private String _network_adapter;

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

        Thread _thread;
        public void Start() => _thread.Start();
        public void Join()  => _thread.Join();
        public bool IsAlive => _thread.IsAlive;

        public ProcessWatcher(String process_name, String network_adapter) {
            instance_name = process_name;
            if (network_adapter == null || network_adapter == "") {
                throw new Exception("Network adapter invalid");
            }
            _network_adapter = network_adapter;
            _thread = new Thread(new ThreadStart(this.QueryIOActivity));
        }

        public ProcessWatcher(int process_pid, String network_adapter)
            : this(PerformanceCounterInstanceName(process_pid), network_adapter) {
        }

        public void stop() {
            is_running = false;
        }

        private static string GetProcessInstanceName(int pid) {
            PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");
            string[] instances = cat.GetInstanceNames();
            foreach (string instance in instances) {
                using (PerformanceCounter cnt =
                            new PerformanceCounter("Process", "ID Process", instance, true)) {
                    int val = (int)cnt.RawValue;
                    if (val == pid) {
                        return instance;
                    }
                }
            }
            throw new Exception("Could not find performance counter instance name for current process.");
        }

        private void QueryIOActivity() {
            is_running = true;
            try {
                var counters = new List<PerformanceCounter> {
                    new PerformanceCounter("Process","IO Read Operations/sec", instance_name, true),
                    new PerformanceCounter("Process", "IO Write Operations/sec", instance_name, true),
                    new PerformanceCounter("Process", "IO Data Operations/sec", instance_name, true),
                    new PerformanceCounter("Process", "IO Read Bytes/sec", instance_name, true),
                    new PerformanceCounter("Process", "IO Write Bytes/sec", instance_name, true),
                    new PerformanceCounter("Process", "IO Data Bytes/sec", instance_name, true),
                    //new PerformanceCounter("Network Interface", "Bytes Sent", _network_adapter, true),
                    //new PerformanceCounter("Network Interface", "Bytes Received", _network_adapter, true),
                    new PerformanceCounter("Network Interface", "Bytes Sent/sec", _network_adapter, true),
                    new PerformanceCounter("Network Interface", "Bytes Received/sec", _network_adapter, true),
                };
                var categories = PerformanceCounterCategory.GetCategories();
                var interfaces = (new PerformanceCounterCategory("Process")).GetInstanceNames();
                var valid_counters = (new PerformanceCounterCategory("Process")).GetCounters(instance_name);
                ;
                while (is_running) {
                    for (var ii = 0; ii < counters.Count; ii++) {
                        values[ii].add_sample(counters[ii].NextValue());
                    }
                }
            }
            catch (Exception ex) {
                Console.Error.WriteLine( "Error on instance: " + instance_name + "Error:" + ex.Message);
                Console.Error.WriteLine(ex.StackTrace);
                //bool exists = PerformanceCounterCategory.CounterExists("Processo", "Bytes de leitura de E/S/s");
            }
        }

        public static string PerformanceCounterInstanceName(int pid)
        {
            Process process = System.Diagnostics.Process.GetProcessById(pid);
            if (process != null)
            {
                var matchesProcessId = new Func<string, bool>(instanceName =>
                {
                    using (var pc = new PerformanceCounter("Process", "ID Process", instanceName, true))
                    {
                        if ((int)pc.RawValue == process.Id)
                        {
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
