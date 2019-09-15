using System;
using System.Diagnostics;
using System.Timers;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ProcessPerformanceWatcher {
    public partial class MainWindow : Form
    {
        enum FindByMode { Name, PID };
        private ProcessWatcher _perf_watcher = null;
        System.Timers.Timer timer;
        bool _is_running = false;
        Process[] processes;
        UInt64 _update_count = 0;

        private readonly String[] units = {
            "bps", "Bps", "Kbps", "KiBps", "Mbps", "MiBps", "Gbps", "GiBps"
        };
        private readonly double[] unit_converter = {
            8.0, 1, 8.0 / 1024, 1.0 / 1024, 8.0 / 1024 / 1024, 1.0 / 1024 / 1024,
            8.0 / 1024 / 1024 / 1024, 1.0 / 1024 / 1024 / 1024,
        };

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                var net_interfaces = (
                        new PerformanceCounterCategory("Network Interface")
                    ).GetInstanceNames();
                if (net_interfaces.Length > 0) {
                    this.network_adapter_combo_box.Items.AddRange(net_interfaces);
                    this.network_adapter_combo_box.SelectedItem =
                        this.network_adapter_combo_box.Items[0];
                    this.unit_combo_box.SelectedItem =
                        this.unit_combo_box.Items[3]; // KiBps
                }
                else {
                    MessageBox.Show("No Network Adapters were found");
                }
            }
            catch (Exception err) {
                MessageBox.Show("Error: " + err.Message);
                Console.WriteLine(err.Message);
                Console.WriteLine(err.StackTrace);
            }
            // update every 200 ms
            timer = new System.Timers.Timer();
            timer.Interval = 300;
            timer.Elapsed += new ElapsedEventHandler(this.OnUpdate);
            timer.Enabled = true;
            timer.Start();
            processes = Process.GetProcesses();
            Array.Sort(
                processes,
                new Comparison<Process>(
                    (p1, p2) => p1.ProcessName.CompareTo(p2.ProcessName)));
        }

        private void OnUpdate(object sender, ElapsedEventArgs e)
        {
            if (_perf_watcher != null &&
                _perf_watcher.IsAlive &&
                _perf_watcher.is_running)
            {
                this.Invoke(new Action(() =>
                {
                    var idx = unit_combo_box.SelectedIndex;
                    read_op_sec.Text            = (_perf_watcher.values[0].Average / 1000).ToString("0.## K/s");
                    write_op_sec.Text           = (_perf_watcher.values[1].Average / 1000).ToString("0.## K/s");
                    data_op_sec.Text            = (_perf_watcher.values[2].Average / 1000).ToString("0.## K/s"); ;
                    read_bytes_sec.Text         = (unit_converter[idx] * _perf_watcher.values[3].Average).ToString("0.## ") + units[idx];
                    write_bytes_sec.Text        = (unit_converter[idx] * _perf_watcher.values[4].Average).ToString("0.## ") + units[idx];
                    data_bytes_sec.Text         = (unit_converter[idx] * _perf_watcher.values[5].Average).ToString("0.## ") + units[idx];
                    total_bytes_sent.Text       = (unit_converter[idx] * _perf_watcher.values[6].Average).ToString("0.## ") + units[idx];
                    total_bytes_received.Text   = (unit_converter[idx] * _perf_watcher.values[7].Average).ToString("0.## ") + units[idx];
                    // TDP + UDP data
                    process_bytes_sent.Text     = (unit_converter[idx] * _perf_watcher.values[8].Average + 
                                                   unit_converter[idx] * _perf_watcher.values[12].Average).ToString("0.## ") + units[idx];
                    process_bytes_received.Text = (unit_converter[idx] * _perf_watcher.values[9].Average +
                                                   unit_converter[idx] * _perf_watcher.values[13].Average).ToString("0.## ") + units[idx];
                }));
            }

            if ((_update_count & 3) == 0) {
                this.Invoke(new Action(() => {
                    processes = Process.GetProcesses();
                    Array.Sort(
                        processes,
                        new Comparison<Process>(
                            (p1, p2) => p1.ProcessName.CompareTo(p2.ProcessName)));
                    if (_update_count == 0) {
                        foreach (var proc in processes) {
                            pid_combo_box.Items.Add(proc.Id);
                        }
                        pid_combo_box.SelectedItem = pid_combo_box.Items[0];
                    }
                }));
            }
            _update_count++;
        }

        private void start_button_click(object sender, EventArgs e) {
            _is_running = true;
            StartMonitoring();
        }

        private void Process_instance_KeyUp(object sender, KeyEventArgs e) {
            if (process_instance.Text != "" && processes.Length > 0) {
                this.Invoke(new Action(() => {
                    Process[] processes_by_name =
                    Array.FindAll(
                        processes,
                        new Predicate<Process>(
                            (p) => p.ProcessName.StartsWith(process_instance.Text)));
                    pid_combo_box.Items.Clear();
                    if (processes_by_name.Length > 0) {
                        foreach (var proc in processes_by_name) {
                            pid_combo_box.Items.Add(proc.Id);
                        }
                        pid_combo_box.SelectedItem = pid_combo_box.Items[0];
                    }
                }));
            }
        }

        private void StartMonitoring() {
            if (pid_combo_box.Items.Count == 0) return;
            error_picture.Visible = false;
            try {
                if (_perf_watcher != null && _perf_watcher.IsAlive) {
                    _perf_watcher.stop();
                    _perf_watcher.Join();
                }
                _perf_watcher = new ProcessWatcher(
                    int.Parse(pid_combo_box.GetItemText(
                        pid_combo_box.SelectedItem)),
                    network_adapter_combo_box.GetItemText(
                        network_adapter_combo_box.SelectedItem));
                success_picture.Visible = true;
                _perf_watcher.Start();
            }
            catch (Exception err) {
                MessageBox.Show("Error: " + err.Message);
                Console.Error.WriteLine(err.Message);
                Console.Error.WriteLine(err.StackTrace);
                error_picture.Visible = true;
                success_picture.Visible = false;
            }
        }

        private void Network_adapter_combo_box_SelectedIndexChanged(object sender, EventArgs e) {
            if (process_instance.Text != "" && _is_running) {
                StartMonitoring();
            }
        }
    }
}
