using System.Windows.Forms;

namespace ProcessPerformanceWatcher {
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.start_button = new System.Windows.Forms.Button();
            this.process_instance = new System.Windows.Forms.TextBox();
            this.instance_name_label = new System.Windows.Forms.Label();
            this.error_picture = new System.Windows.Forms.PictureBox();
            this.success_picture = new System.Windows.Forms.PictureBox();
            this.process_name_radio = new System.Windows.Forms.RadioButton();
            this.pid_radio_button = new System.Windows.Forms.RadioButton();
            this.find_by_label = new System.Windows.Forms.Label();
            this.disk_io_panel = new System.Windows.Forms.GroupBox();
            this.data_bytes_sec_label = new System.Windows.Forms.Label();
            this.data_bytes_sec = new System.Windows.Forms.TextBox();
            this.write_bytes_sec_label = new System.Windows.Forms.Label();
            this.write_bytes_sec = new System.Windows.Forms.TextBox();
            this.read_bytes_sec_label = new System.Windows.Forms.Label();
            this.read_bytes_sec = new System.Windows.Forms.TextBox();
            this.data_op_sec_label = new System.Windows.Forms.Label();
            this.data_op_sec = new System.Windows.Forms.TextBox();
            this.write_op_sec_label = new System.Windows.Forms.Label();
            this.write_op_sec = new System.Windows.Forms.TextBox();
            this.read_op_sec_label = new System.Windows.Forms.Label();
            this.read_op_sec = new System.Windows.Forms.TextBox();
            this.network_io_panel = new System.Windows.Forms.GroupBox();
            this.process_bytes_received_label = new System.Windows.Forms.Label();
            this.process_bytes_received = new System.Windows.Forms.TextBox();
            this.process_bytes_sent_label = new System.Windows.Forms.Label();
            this.process_bytes_sent = new System.Windows.Forms.TextBox();
            this.total_bytes_received_label = new System.Windows.Forms.Label();
            this.total_bytes_received = new System.Windows.Forms.TextBox();
            this.total_bytes_sent_label = new System.Windows.Forms.Label();
            this.total_bytes_sent = new System.Windows.Forms.TextBox();
            this.network_adapter_label = new System.Windows.Forms.Label();
            this.network_adapter_combo_box = new System.Windows.Forms.ComboBox();
            this.unit_combo_box = new System.Windows.Forms.ComboBox();
            this.bytes_unit_label = new System.Windows.Forms.Label();
            this.total_network_traffic_label = new System.Windows.Forms.Label();
            this.process_network_traffic_label = new System.Windows.Forms.Label();
            this.pid_combo_box = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.error_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.success_picture)).BeginInit();
            this.disk_io_panel.SuspendLayout();
            this.network_io_panel.SuspendLayout();
            this.SuspendLayout();
            //
            // start_button
            //
            this.start_button.Location = new System.Drawing.Point(220, 131);
            this.start_button.Margin = new System.Windows.Forms.Padding(2);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(97, 28);
            this.start_button.TabIndex = 1;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_click);
            //
            // process_instance
            //
            this.process_instance.Location = new System.Drawing.Point(133, 43);
            this.process_instance.Name = "process_instance";
            this.process_instance.Size = new System.Drawing.Size(303, 20);
            this.process_instance.TabIndex = 3;
            this.process_instance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Process_instance_KeyUp);
            //
            // instance_name_label
            //
            this.instance_name_label.AutoSize = true;
            this.instance_name_label.Location = new System.Drawing.Point(40, 46);
            this.instance_name_label.Name = "instance_name_label";
            this.instance_name_label.Size = new System.Drawing.Size(48, 13);
            this.instance_name_label.TabIndex = 4;
            this.instance_name_label.Text = "Process:";
            //
            // error_picture
            //
            this.error_picture.Image = ((System.Drawing.Image)(resources.GetObject("error_picture.Image")));
            this.error_picture.Location = new System.Drawing.Point(342, 138);
            this.error_picture.Name = "error_picture";
            this.error_picture.Size = new System.Drawing.Size(24, 20);
            this.error_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.error_picture.TabIndex = 6;
            this.error_picture.TabStop = false;
            this.error_picture.Visible = false;
            //
            // success_picture
            //
            this.success_picture.Image = ((System.Drawing.Image)(resources.GetObject("success_picture.Image")));
            this.success_picture.InitialImage = ((System.Drawing.Image)(resources.GetObject("success_picture.InitialImage")));
            this.success_picture.Location = new System.Drawing.Point(342, 138);
            this.success_picture.Name = "success_picture";
            this.success_picture.Size = new System.Drawing.Size(24, 20);
            this.success_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.success_picture.TabIndex = 7;
            this.success_picture.TabStop = false;
            this.success_picture.Visible = false;
            //
            // process_name_radio
            //
            this.process_name_radio.AutoSize = true;
            this.process_name_radio.Checked = true;
            this.process_name_radio.Location = new System.Drawing.Point(133, 71);
            this.process_name_radio.Name = "process_name_radio";
            this.process_name_radio.Size = new System.Drawing.Size(91, 17);
            this.process_name_radio.TabIndex = 8;
            this.process_name_radio.TabStop = true;
            this.process_name_radio.Tag = "find_process_by";
            this.process_name_radio.Text = "process name";
            this.process_name_radio.UseVisualStyleBackColor = true;
            this.process_name_radio.CheckedChanged += new System.EventHandler(this.on_find_by_mode_change);
            //
            // pid_radio_button
            //
            this.pid_radio_button.AutoSize = true;
            this.pid_radio_button.Location = new System.Drawing.Point(245, 71);
            this.pid_radio_button.Name = "pid_radio_button";
            this.pid_radio_button.Size = new System.Drawing.Size(83, 17);
            this.pid_radio_button.TabIndex = 9;
            this.pid_radio_button.Tag = "find_process_by";
            this.pid_radio_button.Text = "process PID";
            this.pid_radio_button.UseVisualStyleBackColor = true;
            //
            // find_by_label
            //
            this.find_by_label.AutoSize = true;
            this.find_by_label.Location = new System.Drawing.Point(40, 71);
            this.find_by_label.Name = "find_by_label";
            this.find_by_label.Size = new System.Drawing.Size(44, 13);
            this.find_by_label.TabIndex = 10;
            this.find_by_label.Text = "Find by:";
            //
            // disk_io_panel
            //
            this.disk_io_panel.Controls.Add(this.data_bytes_sec_label);
            this.disk_io_panel.Controls.Add(this.data_bytes_sec);
            this.disk_io_panel.Controls.Add(this.write_bytes_sec_label);
            this.disk_io_panel.Controls.Add(this.write_bytes_sec);
            this.disk_io_panel.Controls.Add(this.read_bytes_sec_label);
            this.disk_io_panel.Controls.Add(this.read_bytes_sec);
            this.disk_io_panel.Controls.Add(this.data_op_sec_label);
            this.disk_io_panel.Controls.Add(this.data_op_sec);
            this.disk_io_panel.Controls.Add(this.write_op_sec_label);
            this.disk_io_panel.Controls.Add(this.write_op_sec);
            this.disk_io_panel.Controls.Add(this.read_op_sec_label);
            this.disk_io_panel.Controls.Add(this.read_op_sec);
            this.disk_io_panel.Location = new System.Drawing.Point(43, 164);
            this.disk_io_panel.Name = "disk_io_panel";
            this.disk_io_panel.Size = new System.Drawing.Size(477, 98);
            this.disk_io_panel.TabIndex = 11;
            this.disk_io_panel.TabStop = false;
            this.disk_io_panel.Text = "Disk IO";
            //
            // data_bytes_sec_label
            //
            this.data_bytes_sec_label.AutoSize = true;
            this.data_bytes_sec_label.Location = new System.Drawing.Point(254, 67);
            this.data_bytes_sec_label.Name = "data_bytes_sec_label";
            this.data_bytes_sec_label.Size = new System.Drawing.Size(69, 13);
            this.data_bytes_sec_label.TabIndex = 12;
            this.data_bytes_sec_label.Text = "Data Bytes/s";
            //
            // data_bytes_sec
            //
            this.data_bytes_sec.Location = new System.Drawing.Point(348, 65);
            this.data_bytes_sec.Name = "data_bytes_sec";
            this.data_bytes_sec.ReadOnly = true;
            this.data_bytes_sec.Size = new System.Drawing.Size(116, 20);
            this.data_bytes_sec.TabIndex = 11;
            //
            // write_bytes_sec_label
            //
            this.write_bytes_sec_label.AutoSize = true;
            this.write_bytes_sec_label.Location = new System.Drawing.Point(253, 45);
            this.write_bytes_sec_label.Name = "write_bytes_sec_label";
            this.write_bytes_sec_label.Size = new System.Drawing.Size(71, 13);
            this.write_bytes_sec_label.TabIndex = 10;
            this.write_bytes_sec_label.Text = "Write Bytes/s";
            //
            // write_bytes_sec
            //
            this.write_bytes_sec.Location = new System.Drawing.Point(348, 42);
            this.write_bytes_sec.Name = "write_bytes_sec";
            this.write_bytes_sec.ReadOnly = true;
            this.write_bytes_sec.Size = new System.Drawing.Size(116, 20);
            this.write_bytes_sec.TabIndex = 9;
            //
            // read_bytes_sec_label
            //
            this.read_bytes_sec_label.AutoSize = true;
            this.read_bytes_sec_label.Location = new System.Drawing.Point(253, 24);
            this.read_bytes_sec_label.Name = "read_bytes_sec_label";
            this.read_bytes_sec_label.Size = new System.Drawing.Size(72, 13);
            this.read_bytes_sec_label.TabIndex = 8;
            this.read_bytes_sec_label.Text = "Read Bytes/s";
            //
            // read_bytes_sec
            //
            this.read_bytes_sec.Location = new System.Drawing.Point(348, 19);
            this.read_bytes_sec.Name = "read_bytes_sec";
            this.read_bytes_sec.ReadOnly = true;
            this.read_bytes_sec.Size = new System.Drawing.Size(116, 20);
            this.read_bytes_sec.TabIndex = 7;
            //
            // data_op_sec_label
            //
            this.data_op_sec_label.AutoSize = true;
            this.data_op_sec_label.Location = new System.Drawing.Point(11, 67);
            this.data_op_sec_label.Name = "data_op_sec_label";
            this.data_op_sec_label.Size = new System.Drawing.Size(94, 13);
            this.data_op_sec_label.TabIndex = 6;
            this.data_op_sec_label.Text = "Data Operations/s";
            //
            // data_op_sec
            //
            this.data_op_sec.Location = new System.Drawing.Point(136, 65);
            this.data_op_sec.Name = "data_op_sec";
            this.data_op_sec.ReadOnly = true;
            this.data_op_sec.Size = new System.Drawing.Size(110, 20);
            this.data_op_sec.TabIndex = 5;
            //
            // write_op_sec_label
            //
            this.write_op_sec_label.AutoSize = true;
            this.write_op_sec_label.Location = new System.Drawing.Point(11, 46);
            this.write_op_sec_label.Name = "write_op_sec_label";
            this.write_op_sec_label.Size = new System.Drawing.Size(96, 13);
            this.write_op_sec_label.TabIndex = 4;
            this.write_op_sec_label.Text = "Write Operations/s";
            //
            // write_op_sec
            //
            this.write_op_sec.Location = new System.Drawing.Point(136, 42);
            this.write_op_sec.Name = "write_op_sec";
            this.write_op_sec.ReadOnly = true;
            this.write_op_sec.Size = new System.Drawing.Size(110, 20);
            this.write_op_sec.TabIndex = 3;
            //
            // read_op_sec_label
            //
            this.read_op_sec_label.AutoSize = true;
            this.read_op_sec_label.Location = new System.Drawing.Point(10, 26);
            this.read_op_sec_label.Name = "read_op_sec_label";
            this.read_op_sec_label.Size = new System.Drawing.Size(97, 13);
            this.read_op_sec_label.TabIndex = 2;
            this.read_op_sec_label.Text = "Read Operations/s";
            //
            // read_op_sec
            //
            this.read_op_sec.Location = new System.Drawing.Point(136, 19);
            this.read_op_sec.Name = "read_op_sec";
            this.read_op_sec.ReadOnly = true;
            this.read_op_sec.Size = new System.Drawing.Size(110, 20);
            this.read_op_sec.TabIndex = 1;
            //
            // network_io_panel
            //
            this.network_io_panel.Controls.Add(this.process_network_traffic_label);
            this.network_io_panel.Controls.Add(this.total_network_traffic_label);
            this.network_io_panel.Controls.Add(this.process_bytes_received_label);
            this.network_io_panel.Controls.Add(this.process_bytes_received);
            this.network_io_panel.Controls.Add(this.process_bytes_sent_label);
            this.network_io_panel.Controls.Add(this.process_bytes_sent);
            this.network_io_panel.Controls.Add(this.total_bytes_received_label);
            this.network_io_panel.Controls.Add(this.total_bytes_received);
            this.network_io_panel.Controls.Add(this.total_bytes_sent_label);
            this.network_io_panel.Controls.Add(this.total_bytes_sent);
            this.network_io_panel.Location = new System.Drawing.Point(43, 268);
            this.network_io_panel.Name = "network_io_panel";
            this.network_io_panel.Size = new System.Drawing.Size(477, 104);
            this.network_io_panel.TabIndex = 13;
            this.network_io_panel.TabStop = false;
            this.network_io_panel.Text = "Network IO";
            //
            // process_bytes_received_label
            //
            this.process_bytes_received_label.AutoSize = true;
            this.process_bytes_received_label.Location = new System.Drawing.Point(253, 71);
            this.process_bytes_received_label.Name = "process_bytes_received_label";
            this.process_bytes_received_label.Size = new System.Drawing.Size(92, 13);
            this.process_bytes_received_label.TabIndex = 10;
            this.process_bytes_received_label.Text = "Bytes Received/s";
            //
            // process_bytes_received
            //
            this.process_bytes_received.Location = new System.Drawing.Point(348, 68);
            this.process_bytes_received.Name = "process_bytes_received";
            this.process_bytes_received.ReadOnly = true;
            this.process_bytes_received.Size = new System.Drawing.Size(116, 20);
            this.process_bytes_received.TabIndex = 9;
            //
            // process_bytes_sent_label
            //
            this.process_bytes_sent_label.AutoSize = true;
            this.process_bytes_sent_label.Location = new System.Drawing.Point(253, 50);
            this.process_bytes_sent_label.Name = "process_bytes_sent_label";
            this.process_bytes_sent_label.Size = new System.Drawing.Size(68, 13);
            this.process_bytes_sent_label.TabIndex = 8;
            this.process_bytes_sent_label.Text = "Bytes Sent/s";
            //
            // process_bytes_sent
            //
            this.process_bytes_sent.Location = new System.Drawing.Point(348, 45);
            this.process_bytes_sent.Name = "process_bytes_sent";
            this.process_bytes_sent.ReadOnly = true;
            this.process_bytes_sent.Size = new System.Drawing.Size(116, 20);
            this.process_bytes_sent.TabIndex = 7;
            //
            // total_bytes_received_label
            //
            this.total_bytes_received_label.AutoSize = true;
            this.total_bytes_received_label.Location = new System.Drawing.Point(11, 68);
            this.total_bytes_received_label.Name = "total_bytes_received_label";
            this.total_bytes_received_label.Size = new System.Drawing.Size(92, 13);
            this.total_bytes_received_label.TabIndex = 4;
            this.total_bytes_received_label.Text = "Bytes Received/s";
            //
            // total_bytes_received
            //
            this.total_bytes_received.Location = new System.Drawing.Point(136, 68);
            this.total_bytes_received.Name = "total_bytes_received";
            this.total_bytes_received.ReadOnly = true;
            this.total_bytes_received.Size = new System.Drawing.Size(110, 20);
            this.total_bytes_received.TabIndex = 3;
            //
            // total_bytes_sent_label
            //
            this.total_bytes_sent_label.AutoSize = true;
            this.total_bytes_sent_label.Location = new System.Drawing.Point(10, 48);
            this.total_bytes_sent_label.Name = "total_bytes_sent_label";
            this.total_bytes_sent_label.Size = new System.Drawing.Size(68, 13);
            this.total_bytes_sent_label.TabIndex = 2;
            this.total_bytes_sent_label.Text = "Bytes Sent/s";
            //
            // total_bytes_sent
            //
            this.total_bytes_sent.Location = new System.Drawing.Point(136, 45);
            this.total_bytes_sent.Name = "total_bytes_sent";
            this.total_bytes_sent.ReadOnly = true;
            this.total_bytes_sent.Size = new System.Drawing.Size(110, 20);
            this.total_bytes_sent.TabIndex = 1;
            //
            // network_adapter_label
            //
            this.network_adapter_label.AutoSize = true;
            this.network_adapter_label.Location = new System.Drawing.Point(40, 20);
            this.network_adapter_label.Name = "network_adapter_label";
            this.network_adapter_label.Size = new System.Drawing.Size(90, 13);
            this.network_adapter_label.TabIndex = 15;
            this.network_adapter_label.Text = "Network Adapter:";
            //
            // network_adapter_combo_box
            //
            this.network_adapter_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.network_adapter_combo_box.FormattingEnabled = true;
            this.network_adapter_combo_box.Location = new System.Drawing.Point(133, 16);
            this.network_adapter_combo_box.Name = "network_adapter_combo_box";
            this.network_adapter_combo_box.Size = new System.Drawing.Size(387, 21);
            this.network_adapter_combo_box.Sorted = true;
            this.network_adapter_combo_box.TabIndex = 16;
            this.network_adapter_combo_box.SelectedIndexChanged += new System.EventHandler(this.Network_adapter_combo_box_SelectedIndexChanged);
            //
            // unit_combo_box
            //
            this.unit_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unit_combo_box.FormattingEnabled = true;
            this.unit_combo_box.Items.AddRange(new object[] {
            "bps",
            "Bps",
            "kbps",
            "KiBps",
            "Mbps",
            "MiBps",
            "Gbps",
            "GiBps"});
            this.unit_combo_box.Location = new System.Drawing.Point(133, 99);
            this.unit_combo_box.Name = "unit_combo_box";
            this.unit_combo_box.Size = new System.Drawing.Size(70, 21);
            this.unit_combo_box.TabIndex = 18;
            //
            // bytes_unit_label
            //
            this.bytes_unit_label.AutoSize = true;
            this.bytes_unit_label.Location = new System.Drawing.Point(40, 102);
            this.bytes_unit_label.Name = "bytes_unit_label";
            this.bytes_unit_label.Size = new System.Drawing.Size(29, 13);
            this.bytes_unit_label.TabIndex = 17;
            this.bytes_unit_label.Text = "Unit:";
            //
            // total_network_traffic_label
            //
            this.total_network_traffic_label.AutoSize = true;
            this.total_network_traffic_label.Location = new System.Drawing.Point(10, 25);
            this.total_network_traffic_label.Name = "total_network_traffic_label";
            this.total_network_traffic_label.Size = new System.Drawing.Size(150, 13);
            this.total_network_traffic_label.TabIndex = 11;
            this.total_network_traffic_label.Text = "Total Network Adapter Traffic:";
            //
            // process_network_traffic_label
            //
            this.process_network_traffic_label.AutoSize = true;
            this.process_network_traffic_label.Location = new System.Drawing.Point(253, 25);
            this.process_network_traffic_label.Name = "process_network_traffic_label";
            this.process_network_traffic_label.Size = new System.Drawing.Size(124, 13);
            this.process_network_traffic_label.TabIndex = 12;
            this.process_network_traffic_label.Text = "Process Network Traffic:";
            //
            // pid_combo_box
            //
            this.pid_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pid_combo_box.FormattingEnabled = true;
            this.pid_combo_box.Location = new System.Drawing.Point(442, 42);
            this.pid_combo_box.Name = "pid_combo_box";
            this.pid_combo_box.Size = new System.Drawing.Size(78, 21);
            this.pid_combo_box.TabIndex = 19;
            //
            // MainWindow
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 395);
            this.Controls.Add(this.pid_combo_box);
            this.Controls.Add(this.unit_combo_box);
            this.Controls.Add(this.bytes_unit_label);
            this.Controls.Add(this.network_adapter_combo_box);
            this.Controls.Add(this.network_adapter_label);
            this.Controls.Add(this.network_io_panel);
            this.Controls.Add(this.disk_io_panel);
            this.Controls.Add(this.find_by_label);
            this.Controls.Add(this.pid_radio_button);
            this.Controls.Add(this.process_name_radio);
            this.Controls.Add(this.success_picture);
            this.Controls.Add(this.error_picture);
            this.Controls.Add(this.instance_name_label);
            this.Controls.Add(this.process_instance);
            this.Controls.Add(this.start_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Process Performance Watcher";
            ((System.ComponentModel.ISupportInitialize)(this.error_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.success_picture)).EndInit();
            this.disk_io_panel.ResumeLayout(false);
            this.disk_io_panel.PerformLayout();
            this.network_io_panel.ResumeLayout(false);
            this.network_io_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.TextBox process_instance;
        private System.Windows.Forms.Label instance_name_label;
        private System.Windows.Forms.PictureBox error_picture;
        private System.Windows.Forms.PictureBox success_picture;
        private System.Windows.Forms.RadioButton process_name_radio;
        private System.Windows.Forms.RadioButton pid_radio_button;
        private System.Windows.Forms.Label find_by_label;
        private System.Windows.Forms.GroupBox disk_io_panel;
        private System.Windows.Forms.Label write_bytes_sec_label;
        private System.Windows.Forms.TextBox write_bytes_sec;
        private System.Windows.Forms.Label read_bytes_sec_label;
        private System.Windows.Forms.TextBox read_bytes_sec;
        private System.Windows.Forms.Label data_op_sec_label;
        private System.Windows.Forms.TextBox data_op_sec;
        private System.Windows.Forms.Label write_op_sec_label;
        private System.Windows.Forms.TextBox write_op_sec;
        private System.Windows.Forms.Label read_op_sec_label;
        private System.Windows.Forms.TextBox read_op_sec;
        private System.Windows.Forms.Label data_bytes_sec_label;
        private System.Windows.Forms.TextBox data_bytes_sec;
        private System.Windows.Forms.GroupBox network_io_panel;
        private System.Windows.Forms.Label process_bytes_received_label;
        private System.Windows.Forms.TextBox process_bytes_received;
        private System.Windows.Forms.Label process_bytes_sent_label;
        private System.Windows.Forms.TextBox process_bytes_sent;
        private System.Windows.Forms.Label total_bytes_received_label;
        private System.Windows.Forms.TextBox total_bytes_received;
        private System.Windows.Forms.Label total_bytes_sent_label;
        private System.Windows.Forms.TextBox total_bytes_sent;
        private System.Diagnostics.PerformanceCounter io_disk_perf_write;
        private System.Diagnostics.PerformanceCounter net_io_bytes_sent;
        private System.Diagnostics.PerformanceCounter net_io_bytes_recv;
        private System.Windows.Forms.Label network_adapter_label;
        private System.Windows.Forms.ComboBox network_adapter_combo_box;
        private ComboBox unit_combo_box;
        private Label bytes_unit_label;
        private Label process_network_traffic_label;
        private Label total_network_traffic_label;
        private ComboBox pid_combo_box;
    }
}

