namespace Tankstelle
{
    partial class Form1
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
            this.pb_byte = new System.Windows.Forms.ProgressBar();
            this.b_reset = new System.Windows.Forms.Button();
            this.b_start = new System.Windows.Forms.Button();
            this.gb_choose = new System.Windows.Forms.GroupBox();
            this.lProg = new System.Windows.Forms.Label();
            this.lOS = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.b_windows = new System.Windows.Forms.Button();
            this.b_linux_rpm_x86 = new System.Windows.Forms.Button();
            this.b_linux_rpm_x86_64 = new System.Windows.Forms.Button();
            this.b_linux_deb_x86 = new System.Windows.Forms.Button();
            this.b_linux_deb_x86_64 = new System.Windows.Forms.Button();
            this.b_macos_x86 = new System.Windows.Forms.Button();
            this.b_macos_x86_64 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.b_main = new System.Windows.Forms.Button();
            this.b_help = new System.Windows.Forms.Button();
            this.pb_number = new System.Windows.Forms.ProgressBar();
            this.picboxLogo = new System.Windows.Forms.PictureBox();
            this.picFlagDE = new System.Windows.Forms.PictureBox();
            this.picFlagEN = new System.Windows.Forms.PictureBox();
            this.floatingPictures = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureCopyFinished = new System.Windows.Forms.PictureBox();
            this.gb_choose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFlagDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFlagEN)).BeginInit();
            this.floatingPictures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCopyFinished)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_byte
            // 
            this.pb_byte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_byte.BackColor = System.Drawing.Color.Red;
            this.pb_byte.ForeColor = System.Drawing.Color.Black;
            this.pb_byte.Location = new System.Drawing.Point(15, 590);
            this.pb_byte.Maximum = 10000;
            this.pb_byte.Name = "pb_byte";
            this.pb_byte.Size = new System.Drawing.Size(1296, 24);
            this.pb_byte.Step = 500;
            this.pb_byte.TabIndex = 4;
            this.pb_byte.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // b_reset
            // 
            this.b_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.b_reset.Location = new System.Drawing.Point(906, 620);
            this.b_reset.Name = "b_reset";
            this.b_reset.Size = new System.Drawing.Size(402, 154);
            this.b_reset.TabIndex = 9;
            this.b_reset.Text = "Reset";
            this.b_reset.UseVisualStyleBackColor = false;
            this.b_reset.Click += new System.EventHandler(this.b_reset_Click);
            this.b_reset.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // b_start
            // 
            this.b_start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.b_start.Location = new System.Drawing.Point(12, 620);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(888, 154);
            this.b_start.TabIndex = 1;
            this.b_start.Text = "Start";
            this.b_start.UseVisualStyleBackColor = false;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            this.b_start.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // gb_choose
            // 
            this.gb_choose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_choose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_choose.Controls.Add(this.lProg);
            this.gb_choose.Controls.Add(this.lOS);
            this.gb_choose.Controls.Add(this.splitContainer1);
            this.gb_choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_choose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gb_choose.Location = new System.Drawing.Point(13, 401);
            this.gb_choose.Name = "gb_choose";
            this.gb_choose.Size = new System.Drawing.Size(1296, 183);
            this.gb_choose.TabIndex = 8;
            this.gb_choose.TabStop = false;
            this.gb_choose.Text = "Choose";
            this.gb_choose.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // lProg
            // 
            this.lProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lProg.AutoSize = true;
            this.lProg.Location = new System.Drawing.Point(11, 144);
            this.lProg.Name = "lProg";
            this.lProg.Size = new System.Drawing.Size(87, 24);
            this.lProg.TabIndex = 3;
            this.lProg.Text = "Program:";
            this.lProg.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // lOS
            // 
            this.lOS.AutoSize = true;
            this.lOS.Location = new System.Drawing.Point(11, 54);
            this.lOS.Name = "lOS";
            this.lOS.Size = new System.Drawing.Size(161, 24);
            this.lOS.TabIndex = 2;
            this.lOS.Text = "Operating system:";
            this.lOS.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(178, 13);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1112, 164);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.Resize += new System.EventHandler(this.splitContainerResize);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.b_windows);
            this.flowLayoutPanel1.Controls.Add(this.b_linux_rpm_x86);
            this.flowLayoutPanel1.Controls.Add(this.b_linux_rpm_x86_64);
            this.flowLayoutPanel1.Controls.Add(this.b_linux_deb_x86);
            this.flowLayoutPanel1.Controls.Add(this.b_linux_deb_x86_64);
            this.flowLayoutPanel1.Controls.Add(this.b_macos_x86);
            this.flowLayoutPanel1.Controls.Add(this.b_macos_x86_64);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1112, 82);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.resizePanel);
            // 
            // b_windows
            // 
            this.b_windows.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_windows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_windows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_windows.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_windows.Location = new System.Drawing.Point(3, 3);
            this.b_windows.Name = "b_windows";
            this.b_windows.Size = new System.Drawing.Size(150, 74);
            this.b_windows.TabIndex = 0;
            this.b_windows.Text = "Windows\r\n(All)";
            this.b_windows.UseVisualStyleBackColor = false;
            this.b_windows.Click += new System.EventHandler(this.changeColor);
            this.b_windows.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // b_linux_rpm_x86
            // 
            this.b_linux_rpm_x86.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_linux_rpm_x86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_linux_rpm_x86.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_linux_rpm_x86.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_linux_rpm_x86.Location = new System.Drawing.Point(159, 5);
            this.b_linux_rpm_x86.Name = "b_linux_rpm_x86";
            this.b_linux_rpm_x86.Size = new System.Drawing.Size(150, 70);
            this.b_linux_rpm_x86.TabIndex = 10;
            this.b_linux_rpm_x86.Text = "Linux\r\n(rpm x86)";
            this.b_linux_rpm_x86.UseVisualStyleBackColor = false;
            this.b_linux_rpm_x86.Click += new System.EventHandler(this.changeColor);
            this.b_linux_rpm_x86.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // b_linux_rpm_x86_64
            // 
            this.b_linux_rpm_x86_64.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_linux_rpm_x86_64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_linux_rpm_x86_64.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_linux_rpm_x86_64.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_linux_rpm_x86_64.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_linux_rpm_x86_64.Location = new System.Drawing.Point(315, 9);
            this.b_linux_rpm_x86_64.Name = "b_linux_rpm_x86_64";
            this.b_linux_rpm_x86_64.Size = new System.Drawing.Size(150, 62);
            this.b_linux_rpm_x86_64.TabIndex = 12;
            this.b_linux_rpm_x86_64.Text = "Linux\r\n(rpm x86_64)";
            this.b_linux_rpm_x86_64.UseVisualStyleBackColor = false;
            this.b_linux_rpm_x86_64.Click += new System.EventHandler(this.changeColor);
            this.b_linux_rpm_x86_64.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // b_linux_deb_x86
            // 
            this.b_linux_deb_x86.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_linux_deb_x86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_linux_deb_x86.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_linux_deb_x86.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_linux_deb_x86.Location = new System.Drawing.Point(471, 9);
            this.b_linux_deb_x86.Name = "b_linux_deb_x86";
            this.b_linux_deb_x86.Size = new System.Drawing.Size(150, 62);
            this.b_linux_deb_x86.TabIndex = 11;
            this.b_linux_deb_x86.Text = "Linux\r\n(deb x86)";
            this.b_linux_deb_x86.UseVisualStyleBackColor = false;
            this.b_linux_deb_x86.Click += new System.EventHandler(this.changeColor);
            this.b_linux_deb_x86.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // b_linux_deb_x86_64
            // 
            this.b_linux_deb_x86_64.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_linux_deb_x86_64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_linux_deb_x86_64.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_linux_deb_x86_64.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_linux_deb_x86_64.Location = new System.Drawing.Point(627, 10);
            this.b_linux_deb_x86_64.Name = "b_linux_deb_x86_64";
            this.b_linux_deb_x86_64.Size = new System.Drawing.Size(150, 59);
            this.b_linux_deb_x86_64.TabIndex = 13;
            this.b_linux_deb_x86_64.Text = "Linux\r\n(deb x86_64)";
            this.b_linux_deb_x86_64.UseVisualStyleBackColor = false;
            this.b_linux_deb_x86_64.Click += new System.EventHandler(this.changeColor);
            this.b_linux_deb_x86_64.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // b_macos_x86
            // 
            this.b_macos_x86.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_macos_x86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_macos_x86.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_macos_x86.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_macos_x86.Location = new System.Drawing.Point(783, 10);
            this.b_macos_x86.Name = "b_macos_x86";
            this.b_macos_x86.Size = new System.Drawing.Size(150, 59);
            this.b_macos_x86.TabIndex = 6;
            this.b_macos_x86.Text = "Mac OS\r\n(x86)";
            this.b_macos_x86.UseVisualStyleBackColor = false;
            this.b_macos_x86.Click += new System.EventHandler(this.changeColor);
            this.b_macos_x86.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // b_macos_x86_64
            // 
            this.b_macos_x86_64.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_macos_x86_64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_macos_x86_64.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_macos_x86_64.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_macos_x86_64.Location = new System.Drawing.Point(939, 6);
            this.b_macos_x86_64.Name = "b_macos_x86_64";
            this.b_macos_x86_64.Size = new System.Drawing.Size(150, 68);
            this.b_macos_x86_64.TabIndex = 7;
            this.b_macos_x86_64.Text = "Mac OS\r\n(x86_64)";
            this.b_macos_x86_64.UseVisualStyleBackColor = false;
            this.b_macos_x86_64.Click += new System.EventHandler(this.changeColor);
            this.b_macos_x86_64.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.b_main);
            this.flowLayoutPanel2.Controls.Add(this.b_help);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1112, 81);
            this.flowLayoutPanel2.TabIndex = 5;
            this.flowLayoutPanel2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            this.flowLayoutPanel2.Resize += new System.EventHandler(this.resizePanel);
            // 
            // b_main
            // 
            this.b_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_main.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_main.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_main.Location = new System.Drawing.Point(3, 3);
            this.b_main.Name = "b_main";
            this.b_main.Size = new System.Drawing.Size(129, 65);
            this.b_main.TabIndex = 1;
            this.b_main.Text = "Main program";
            this.b_main.UseVisualStyleBackColor = false;
            this.b_main.Click += new System.EventHandler(this.changeColor);
            this.b_main.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // b_help
            // 
            this.b_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.b_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_help.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_help.Location = new System.Drawing.Point(138, 3);
            this.b_help.Name = "b_help";
            this.b_help.Size = new System.Drawing.Size(272, 65);
            this.b_help.TabIndex = 5;
            this.b_help.Text = "Help / Langpack";
            this.b_help.UseVisualStyleBackColor = false;
            this.b_help.Click += new System.EventHandler(this.changeColor);
            this.b_help.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // pb_number
            // 
            this.pb_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_number.BackColor = System.Drawing.Color.Red;
            this.pb_number.ForeColor = System.Drawing.Color.Black;
            this.pb_number.Location = new System.Drawing.Point(15, 590);
            this.pb_number.Name = "pb_number";
            this.pb_number.Size = new System.Drawing.Size(1296, 24);
            this.pb_number.Step = 1;
            this.pb_number.TabIndex = 10;
            this.pb_number.Visible = false;
            this.pb_number.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // picboxLogo
            // 
            this.picboxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picboxLogo.Location = new System.Drawing.Point(86, 3);
            this.picboxLogo.Name = "picboxLogo";
            this.picboxLogo.Size = new System.Drawing.Size(256, 77);
            this.picboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxLogo.TabIndex = 11;
            this.picboxLogo.TabStop = false;
            this.picboxLogo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // picFlagDE
            // 
            this.picFlagDE.Location = new System.Drawing.Point(3, 3);
            this.picFlagDE.Name = "picFlagDE";
            this.picFlagDE.Size = new System.Drawing.Size(77, 46);
            this.picFlagDE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFlagDE.TabIndex = 12;
            this.picFlagDE.TabStop = false;
            this.picFlagDE.Click += new System.EventHandler(this.changeL10n);
            this.picFlagDE.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // picFlagEN
            // 
            this.picFlagEN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picFlagEN.Location = new System.Drawing.Point(348, 3);
            this.picFlagEN.Name = "picFlagEN";
            this.picFlagEN.Size = new System.Drawing.Size(125, 54);
            this.picFlagEN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFlagEN.TabIndex = 13;
            this.picFlagEN.TabStop = false;
            this.picFlagEN.Click += new System.EventHandler(this.changeL10n);
            this.picFlagEN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // floatingPictures
            // 
            this.floatingPictures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.floatingPictures.Controls.Add(this.picFlagDE);
            this.floatingPictures.Controls.Add(this.picboxLogo);
            this.floatingPictures.Controls.Add(this.picFlagEN);
            this.floatingPictures.Location = new System.Drawing.Point(12, 12);
            this.floatingPictures.Name = "floatingPictures";
            this.floatingPictures.Size = new System.Drawing.Size(1297, 383);
            this.floatingPictures.TabIndex = 14;
            this.floatingPictures.SizeChanged += new System.EventHandler(this.adaptflagsSize);
            this.floatingPictures.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // pictureCopyFinished
            // 
            this.pictureCopyFinished.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureCopyFinished.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureCopyFinished.Location = new System.Drawing.Point(0, 0);
            this.pictureCopyFinished.Name = "pictureCopyFinished";
            this.pictureCopyFinished.Size = new System.Drawing.Size(1321, 786);
            this.pictureCopyFinished.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCopyFinished.TabIndex = 14;
            this.pictureCopyFinished.TabStop = false;
            this.pictureCopyFinished.Visible = false;
            this.pictureCopyFinished.Click += new System.EventHandler(this.pictureCopyFinished_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(163)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(1321, 786);
            this.Controls.Add(this.gb_choose);
            this.Controls.Add(this.floatingPictures);
            this.Controls.Add(this.pb_number);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.b_reset);
            this.Controls.Add(this.pb_byte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureCopyFinished);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(770, 786);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LibreOffice Tankstelle";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keypressedExit);
            this.gb_choose.ResumeLayout(false);
            this.gb_choose.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFlagDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFlagEN)).EndInit();
            this.floatingPictures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCopyFinished)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_byte;
        private System.Windows.Forms.Button b_reset;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.GroupBox gb_choose;
        private System.Windows.Forms.Button b_windows;
        private System.Windows.Forms.Button b_macos_x86;
        private System.Windows.Forms.Button b_linux_rpm_x86;
        private System.Windows.Forms.Button b_linux_deb_x86;
        private System.Windows.Forms.Button b_linux_deb_x86_64;
        private System.Windows.Forms.Button b_macos_x86_64;
        private System.Windows.Forms.Button b_linux_rpm_x86_64;
        private System.Windows.Forms.Button b_help;
        private System.Windows.Forms.Label lProg;
        private System.Windows.Forms.Label lOS;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button b_main;
        private System.Windows.Forms.ProgressBar pb_number;
        private System.Windows.Forms.PictureBox picboxLogo;
        private System.Windows.Forms.PictureBox picFlagDE;
        private System.Windows.Forms.PictureBox picFlagEN;
        private System.Windows.Forms.FlowLayoutPanel floatingPictures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureCopyFinished;
    }
}

