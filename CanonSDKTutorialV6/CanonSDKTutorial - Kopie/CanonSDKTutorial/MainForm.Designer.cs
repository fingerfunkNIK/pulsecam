namespace CanonPulse
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LiveViewPicBox = new System.Windows.Forms.PictureBox();
            this.LiveViewButton = new System.Windows.Forms.Button();
            this.CameraListBox = new System.Windows.Forms.ListBox();
            this.SessionButton = new System.Windows.Forms.Button();
            this.SessionLabel = new System.Windows.Forms.Label();
            this.InitGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.LiveViewGroupBox = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.snapshotBtn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.OK_btn = new System.Windows.Forms.Button();
            this.cb_verbose = new System.Windows.Forms.CheckBox();
            this.msgBox = new System.Windows.Forms.TextBox();
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.MainProgressBar = new System.Windows.Forms.ProgressBar();
            this.WBCoBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ISOCoBox = new System.Windows.Forms.ComboBox();
            this.TvCoBox = new System.Windows.Forms.ComboBox();
            this.AvCoBox = new System.Windows.Forms.ComboBox();
            this.SaveFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.print0_rb = new System.Windows.Forms.RadioButton();
            this.print2_rb = new System.Windows.Forms.RadioButton();
            this.print1_rb = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.timeUpDown = new System.Windows.Forms.NumericUpDown();
            this.sx = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sh = new System.Windows.Forms.NumericUpDown();
            this.sw = new System.Windows.Forms.NumericUpDown();
            this.sy = new System.Windows.Forms.NumericUpDown();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dh = new System.Windows.Forms.NumericUpDown();
            this.dw = new System.Windows.Forms.NumericUpDown();
            this.dy = new System.Windows.Forms.NumericUpDown();
            this.dx = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LiveViewPicBox)).BeginInit();
            this.InitGroupBox.SuspendLayout();
            this.LiveViewGroupBox.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SettingsGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sx)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sy)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LiveViewPicBox
            // 
            this.LiveViewPicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LiveViewPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LiveViewPicBox.Location = new System.Drawing.Point(10, 51);
            this.LiveViewPicBox.Name = "LiveViewPicBox";
            this.LiveViewPicBox.Size = new System.Drawing.Size(460, 271);
            this.LiveViewPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LiveViewPicBox.TabIndex = 1;
            this.LiveViewPicBox.TabStop = false;
            this.LiveViewPicBox.SizeChanged += new System.EventHandler(this.LiveViewPicBox_SizeChanged);
            this.LiveViewPicBox.Click += new System.EventHandler(this.LiveViewPicBox_Click);
            this.LiveViewPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LiveViewPicBox_MouseDown);
            // 
            // LiveViewButton
            // 
            this.LiveViewButton.Location = new System.Drawing.Point(343, 49);
            this.LiveViewButton.Name = "LiveViewButton";
            this.LiveViewButton.Size = new System.Drawing.Size(70, 22);
            this.LiveViewButton.TabIndex = 2;
            this.LiveViewButton.Text = "Start LV";
            this.LiveViewButton.UseVisualStyleBackColor = true;
            this.LiveViewButton.Click += new System.EventHandler(this.LiveViewButton_Click);
            // 
            // CameraListBox
            // 
            this.CameraListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.Location = new System.Drawing.Point(8, 35);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.Size = new System.Drawing.Size(121, 82);
            this.CameraListBox.TabIndex = 6;
            // 
            // SessionButton
            // 
            this.SessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SessionButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SessionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SessionButton.Location = new System.Drawing.Point(6, 123);
            this.SessionButton.Name = "SessionButton";
            this.SessionButton.Size = new System.Drawing.Size(129, 35);
            this.SessionButton.TabIndex = 7;
            this.SessionButton.Text = "connect camera";
            this.SessionButton.UseVisualStyleBackColor = false;
            this.SessionButton.Click += new System.EventHandler(this.SessionButton_Click);
            // 
            // SessionLabel
            // 
            this.SessionLabel.AutoSize = true;
            this.SessionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SessionLabel.Location = new System.Drawing.Point(6, 16);
            this.SessionLabel.Name = "SessionLabel";
            this.SessionLabel.Size = new System.Drawing.Size(110, 16);
            this.SessionLabel.TabIndex = 8;
            this.SessionLabel.Text = "No open session";
            // 
            // InitGroupBox
            // 
            this.InitGroupBox.Controls.Add(this.CameraListBox);
            this.InitGroupBox.Controls.Add(this.SessionLabel);
            this.InitGroupBox.Controls.Add(this.SessionButton);
            this.InitGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InitGroupBox.Name = "InitGroupBox";
            this.InitGroupBox.Size = new System.Drawing.Size(135, 158);
            this.InitGroupBox.TabIndex = 9;
            this.InitGroupBox.TabStop = false;
            this.InitGroupBox.Text = "Init";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.Location = new System.Drawing.Point(319, 41);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(31, 23);
            this.RefreshButton.TabIndex = 9;
            this.RefreshButton.Text = "↻";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // LiveViewGroupBox
            // 
            this.LiveViewGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LiveViewGroupBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.LiveViewGroupBox.Controls.Add(this.panel5);
            this.LiveViewGroupBox.Controls.Add(this.cb_verbose);
            this.LiveViewGroupBox.Controls.Add(this.msgBox);
            this.LiveViewGroupBox.Controls.Add(this.LiveViewPicBox);
            this.LiveViewGroupBox.Location = new System.Drawing.Point(12, 176);
            this.LiveViewGroupBox.Name = "LiveViewGroupBox";
            this.LiveViewGroupBox.Size = new System.Drawing.Size(739, 442);
            this.LiveViewGroupBox.TabIndex = 10;
            this.LiveViewGroupBox.TabStop = false;
            this.LiveViewGroupBox.Text = "LiveView";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.snapshotBtn);
            this.panel5.Controls.Add(this.cancel_btn);
            this.panel5.Controls.Add(this.OK_btn);
            this.panel5.Location = new System.Drawing.Point(10, 353);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(144, 67);
            this.panel5.TabIndex = 24;
            // 
            // snapshotBtn
            // 
            this.snapshotBtn.Location = new System.Drawing.Point(3, 3);
            this.snapshotBtn.Name = "snapshotBtn";
            this.snapshotBtn.Size = new System.Drawing.Size(61, 23);
            this.snapshotBtn.TabIndex = 10;
            this.snapshotBtn.Text = "selftimer";
            this.snapshotBtn.UseVisualStyleBackColor = true;
            this.snapshotBtn.Click += new System.EventHandler(this.snapshotBtn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(3, 32);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(61, 23);
            this.cancel_btn.TabIndex = 18;
            this.cancel_btn.Text = "cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // OK_btn
            // 
            this.OK_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.OK_btn.Location = new System.Drawing.Point(70, 32);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(61, 23);
            this.OK_btn.TabIndex = 17;
            this.OK_btn.Text = "OK";
            this.OK_btn.UseVisualStyleBackColor = true;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // cb_verbose
            // 
            this.cb_verbose.AutoSize = true;
            this.cb_verbose.Location = new System.Drawing.Point(489, 28);
            this.cb_verbose.Name = "cb_verbose";
            this.cb_verbose.Size = new System.Drawing.Size(64, 17);
            this.cb_verbose.TabIndex = 23;
            this.cb_verbose.Text = "verbose";
            this.cb_verbose.UseVisualStyleBackColor = true;
            // 
            // msgBox
            // 
            this.msgBox.CausesValidation = false;
            this.msgBox.Location = new System.Drawing.Point(476, 51);
            this.msgBox.Multiline = true;
            this.msgBox.Name = "msgBox";
            this.msgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.msgBox.Size = new System.Drawing.Size(263, 271);
            this.msgBox.TabIndex = 12;
            // 
            // SettingsGroupBox
            // 
            this.SettingsGroupBox.Controls.Add(this.MainProgressBar);
            this.SettingsGroupBox.Controls.Add(this.WBCoBox);
            this.SettingsGroupBox.Controls.Add(this.label3);
            this.SettingsGroupBox.Controls.Add(this.label2);
            this.SettingsGroupBox.Controls.Add(this.label5);
            this.SettingsGroupBox.Controls.Add(this.label1);
            this.SettingsGroupBox.Controls.Add(this.ISOCoBox);
            this.SettingsGroupBox.Controls.Add(this.TvCoBox);
            this.SettingsGroupBox.Controls.Add(this.AvCoBox);
            this.SettingsGroupBox.Location = new System.Drawing.Point(331, 18);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.Size = new System.Drawing.Size(42, 26);
            this.SettingsGroupBox.TabIndex = 11;
            this.SettingsGroupBox.TabStop = false;
            this.SettingsGroupBox.Text = "Settings";
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.Location = new System.Drawing.Point(6, 100);
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(130, 20);
            this.MainProgressBar.TabIndex = 8;
            // 
            // WBCoBox
            // 
            this.WBCoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WBCoBox.FormattingEnabled = true;
            this.WBCoBox.Items.AddRange(new object[] {
            "Auto",
            "Daylight",
            "Cloudy",
            "Tangsten",
            "Fluorescent",
            "Strobe",
            "White Paper",
            "Shade"});
            this.WBCoBox.Location = new System.Drawing.Point(6, 129);
            this.WBCoBox.Name = "WBCoBox";
            this.WBCoBox.Size = new System.Drawing.Size(110, 21);
            this.WBCoBox.TabIndex = 7;
            this.WBCoBox.SelectedIndexChanged += new System.EventHandler(this.WBCoBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "ISO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tv";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(133, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "WB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Av";
            // 
            // ISOCoBox
            // 
            this.ISOCoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ISOCoBox.FormattingEnabled = true;
            this.ISOCoBox.Location = new System.Drawing.Point(6, 73);
            this.ISOCoBox.Name = "ISOCoBox";
            this.ISOCoBox.Size = new System.Drawing.Size(94, 21);
            this.ISOCoBox.TabIndex = 0;
            this.ISOCoBox.SelectedIndexChanged += new System.EventHandler(this.ISOCoBox_SelectedIndexChanged);
            // 
            // TvCoBox
            // 
            this.TvCoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TvCoBox.FormattingEnabled = true;
            this.TvCoBox.Location = new System.Drawing.Point(6, 46);
            this.TvCoBox.Name = "TvCoBox";
            this.TvCoBox.Size = new System.Drawing.Size(94, 21);
            this.TvCoBox.TabIndex = 0;
            this.TvCoBox.SelectedIndexChanged += new System.EventHandler(this.TvCoBox_SelectedIndexChanged);
            // 
            // AvCoBox
            // 
            this.AvCoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AvCoBox.FormattingEnabled = true;
            this.AvCoBox.Location = new System.Drawing.Point(6, 19);
            this.AvCoBox.Name = "AvCoBox";
            this.AvCoBox.Size = new System.Drawing.Size(94, 21);
            this.AvCoBox.TabIndex = 0;
            this.AvCoBox.SelectedIndexChanged += new System.EventHandler(this.AvCoBox_SelectedIndexChanged);
            // 
            // SaveFolderBrowser
            // 
            this.SaveFolderBrowser.Description = "Save Images To...";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.print0_rb);
            this.panel2.Controls.Add(this.print2_rb);
            this.panel2.Controls.Add(this.print1_rb);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(584, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 45);
            this.panel2.TabIndex = 14;
            // 
            // print0_rb
            // 
            this.print0_rb.AutoSize = true;
            this.print0_rb.Location = new System.Drawing.Point(7, 18);
            this.print0_rb.Name = "print0_rb";
            this.print0_rb.Size = new System.Drawing.Size(31, 17);
            this.print0_rb.TabIndex = 3;
            this.print0_rb.TabStop = true;
            this.print0_rb.Text = "0";
            this.print0_rb.UseVisualStyleBackColor = true;
            this.print0_rb.CheckedChanged += new System.EventHandler(this.print0_rb_CheckedChanged);
            // 
            // print2_rb
            // 
            this.print2_rb.AutoSize = true;
            this.print2_rb.Location = new System.Drawing.Point(81, 19);
            this.print2_rb.Name = "print2_rb";
            this.print2_rb.Size = new System.Drawing.Size(31, 17);
            this.print2_rb.TabIndex = 2;
            this.print2_rb.TabStop = true;
            this.print2_rb.Text = "2";
            this.print2_rb.UseVisualStyleBackColor = true;
            // 
            // print1_rb
            // 
            this.print1_rb.AutoSize = true;
            this.print1_rb.Location = new System.Drawing.Point(44, 19);
            this.print1_rb.Name = "print1_rb";
            this.print1_rb.Size = new System.Drawing.Size(31, 17);
            this.print1_rb.TabIndex = 1;
            this.print1_rb.TabStop = true;
            this.print1_rb.Text = "1";
            this.print1_rb.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "num copies to print";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(328, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(133, 46);
            this.panel4.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "self timer length";
            // 
            // timeUpDown
            // 
            this.timeUpDown.Location = new System.Drawing.Point(331, 47);
            this.timeUpDown.Name = "timeUpDown";
            this.timeUpDown.Size = new System.Drawing.Size(120, 20);
            this.timeUpDown.TabIndex = 19;
            // 
            // sx
            // 
            this.sx.Location = new System.Drawing.Point(44, 29);
            this.sx.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.sx.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.sx.Name = "sx";
            this.sx.Size = new System.Drawing.Size(69, 20);
            this.sx.TabIndex = 23;
            this.sx.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sx.ValueChanged += new System.EventHandler(this.sx_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.sh);
            this.panel1.Controls.Add(this.sw);
            this.panel1.Controls.Add(this.sy);
            this.panel1.Controls.Add(this.sx);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(431, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 39);
            this.panel1.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "height";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "width";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "source";
            // 
            // sh
            // 
            this.sh.Location = new System.Drawing.Point(47, 135);
            this.sh.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.sh.Name = "sh";
            this.sh.Size = new System.Drawing.Size(69, 20);
            this.sh.TabIndex = 26;
            this.sh.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.sh.ValueChanged += new System.EventHandler(this.sh_ValueChanged);
            // 
            // sw
            // 
            this.sw.Location = new System.Drawing.Point(47, 100);
            this.sw.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.sw.Name = "sw";
            this.sw.Size = new System.Drawing.Size(69, 20);
            this.sw.TabIndex = 25;
            this.sw.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.sw.ValueChanged += new System.EventHandler(this.sw_ValueChanged);
            // 
            // sy
            // 
            this.sy.Location = new System.Drawing.Point(44, 67);
            this.sy.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.sy.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.sy.Name = "sy";
            this.sy.Size = new System.Drawing.Size(69, 20);
            this.sy.TabIndex = 24;
            this.sy.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sy.ValueChanged += new System.EventHandler(this.sy_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.dh);
            this.panel3.Controls.Add(this.dw);
            this.panel3.Controls.Add(this.dy);
            this.panel3.Controls.Add(this.dx);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(392, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(21, 44);
            this.panel3.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "height";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "width";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "y";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(12, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "x";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "destination";
            // 
            // dh
            // 
            this.dh.Location = new System.Drawing.Point(47, 135);
            this.dh.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.dh.Name = "dh";
            this.dh.Size = new System.Drawing.Size(69, 20);
            this.dh.TabIndex = 26;
            this.dh.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.dh.ValueChanged += new System.EventHandler(this.dh_ValueChanged);
            // 
            // dw
            // 
            this.dw.Location = new System.Drawing.Point(47, 100);
            this.dw.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.dw.Name = "dw";
            this.dw.Size = new System.Drawing.Size(69, 20);
            this.dw.TabIndex = 25;
            this.dw.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.dw.ValueChanged += new System.EventHandler(this.dw_ValueChanged);
            // 
            // dy
            // 
            this.dy.Location = new System.Drawing.Point(44, 67);
            this.dy.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.dy.Name = "dy";
            this.dy.Size = new System.Drawing.Size(69, 20);
            this.dy.TabIndex = 24;
            this.dy.ValueChanged += new System.EventHandler(this.dy_ValueChanged);
            // 
            // dx
            // 
            this.dx.Location = new System.Drawing.Point(44, 29);
            this.dx.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.dx.Name = "dx";
            this.dx.Size = new System.Drawing.Size(69, 20);
            this.dx.TabIndex = 23;
            this.dx.ValueChanged += new System.EventHandler(this.dx_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(356, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(172, 18);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(65, 25);
            this.versionLabel.TabIndex = 35;
            this.versionLabel.Text = "v 2.05";
            this.versionLabel.Click += new System.EventHandler(this.label17_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(303, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 73);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 631);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.timeUpDown);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.LiveViewButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.SettingsGroupBox);
            this.Controls.Add(this.LiveViewGroupBox);
            this.Controls.Add(this.InitGroupBox);
            this.Controls.Add(this.RefreshButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(616, 657);
            this.Name = "MainForm";
            this.Text = "pepsi pulse camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.LiveViewPicBox)).EndInit();
            this.InitGroupBox.ResumeLayout(false);
            this.InitGroupBox.PerformLayout();
            this.LiveViewGroupBox.ResumeLayout(false);
            this.LiveViewGroupBox.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sx)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sy)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LiveViewPicBox;
        private System.Windows.Forms.Button LiveViewButton;
        private System.Windows.Forms.ListBox CameraListBox;
        private System.Windows.Forms.Button SessionButton;
        private System.Windows.Forms.Label SessionLabel;
        private System.Windows.Forms.GroupBox InitGroupBox;
        private System.Windows.Forms.GroupBox LiveViewGroupBox;
        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.ComboBox ISOCoBox;
        private System.Windows.Forms.ComboBox TvCoBox;
        private System.Windows.Forms.ComboBox AvCoBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog SaveFolderBrowser;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ComboBox WBCoBox;
        private System.Windows.Forms.Label label5;
  
        private System.Windows.Forms.ProgressBar MainProgressBar;
        private System.Windows.Forms.TextBox msgBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton print0_rb;
        private System.Windows.Forms.RadioButton print2_rb;
        private System.Windows.Forms.RadioButton print1_rb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown timeUpDown;
        private System.Windows.Forms.CheckBox cb_verbose;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button snapshotBtn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.NumericUpDown sx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown sh;
        private System.Windows.Forms.NumericUpDown sw;
        private System.Windows.Forms.NumericUpDown sy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown dh;
        private System.Windows.Forms.NumericUpDown dw;
        private System.Windows.Forms.NumericUpDown dy;
        private System.Windows.Forms.NumericUpDown dx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

