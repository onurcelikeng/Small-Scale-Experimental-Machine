namespace DSSEM.View
{
    partial class StartScreenView
    {

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreenView));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assemblyCodeListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectBase = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spTextBox = new System.Windows.Forms.TextBox();
            this.ırTextBox = new System.Windows.Forms.TextBox();
            this.r4TextBox = new System.Windows.Forms.TextBox();
            this.r2TextBox = new System.Windows.Forms.TextBox();
            this.r1TextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.inputRegisterTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.arTextBox = new System.Windows.Forms.TextBox();
            this.pcTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.microOperationListBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.stackSementDataGridView = new System.Windows.Forms.DataGridView();
            this.adressStackSegmentDataGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueStackSegmentDataGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSegmentDataGridView = new System.Windows.Forms.DataGridView();
            this.adressDataSegmentDataGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataSegmentDataGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeSegmentDataGridView = new System.Windows.Forms.DataGridView();
            this.adressCodeSegmentDataGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueCodeSegmentDataGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDataGridView = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackSementDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSegmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeSegmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelDataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "(*.asm)|*.asm|(*.basm)|*.basm";
            this.openFileDialog.Title = "Select Assembly File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveButton,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveButton.Size = new System.Drawing.Size(152, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1254, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startDebugToolStripMenuItem,
            this.nextToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // startDebugToolStripMenuItem
            // 
            this.startDebugToolStripMenuItem.Image = global::DSSEM.Properties.Resources.play_button_green_16;
            this.startDebugToolStripMenuItem.Name = "startDebugToolStripMenuItem";
            this.startDebugToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.startDebugToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.startDebugToolStripMenuItem.Text = "Start Debug";
            this.startDebugToolStripMenuItem.Click += new System.EventHandler(this.startDebugButton_Click);
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Image = global::DSSEM.Properties.Resources.arrow_step_over_icon;
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.nextToolStripMenuItem.Text = "Next Instruction";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.NextInstructionButton_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guideToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.guideToolStripMenuItem.Text = "Guide";
            this.guideToolStripMenuItem.Click += new System.EventHandler(this.guideButtonClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // assemblyCodeListBox
            // 
            this.assemblyCodeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.assemblyCodeListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.assemblyCodeListBox.FormattingEnabled = true;
            this.assemblyCodeListBox.HorizontalScrollbar = true;
            this.assemblyCodeListBox.ItemHeight = 16;
            this.assemblyCodeListBox.Location = new System.Drawing.Point(6, 19);
            this.assemblyCodeListBox.Name = "assemblyCodeListBox";
            this.assemblyCodeListBox.Size = new System.Drawing.Size(205, 212);
            this.assemblyCodeListBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Conversion Type :";
            // 
            // selectBase
            // 
            this.selectBase.FormattingEnabled = true;
            this.selectBase.Items.AddRange(new object[] {
            "Binary",
            "Octal",
            "Decimal",
            "Hexadecimal"});
            this.selectBase.Location = new System.Drawing.Point(108, 33);
            this.selectBase.Name = "selectBase";
            this.selectBase.Size = new System.Drawing.Size(121, 21);
            this.selectBase.TabIndex = 19;
            this.selectBase.SelectedIndexChanged += new System.EventHandler(this.selectBase_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Image = global::DSSEM.Properties.Resources.play_button_green_16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(235, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 20;
            this.button1.Tag = "";
            this.button1.Text = "Step Instruction";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.startDebugButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.spTextBox);
            this.groupBox1.Controls.Add(this.ırTextBox);
            this.groupBox1.Controls.Add(this.r4TextBox);
            this.groupBox1.Controls.Add(this.r2TextBox);
            this.groupBox1.Controls.Add(this.r1TextBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.inputRegisterTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.arTextBox);
            this.groupBox1.Controls.Add(this.pcTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(235, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 260);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registers";
            // 
            // spTextBox
            // 
            this.spTextBox.Location = new System.Drawing.Point(325, 147);
            this.spTextBox.Name = "spTextBox";
            this.spTextBox.ReadOnly = true;
            this.spTextBox.Size = new System.Drawing.Size(100, 20);
            this.spTextBox.TabIndex = 45;
            // 
            // ırTextBox
            // 
            this.ırTextBox.Location = new System.Drawing.Point(325, 118);
            this.ırTextBox.Name = "ırTextBox";
            this.ırTextBox.ReadOnly = true;
            this.ırTextBox.Size = new System.Drawing.Size(100, 20);
            this.ırTextBox.TabIndex = 44;
            // 
            // r4TextBox
            // 
            this.r4TextBox.Location = new System.Drawing.Point(325, 177);
            this.r4TextBox.Name = "r4TextBox";
            this.r4TextBox.ReadOnly = true;
            this.r4TextBox.Size = new System.Drawing.Size(100, 20);
            this.r4TextBox.TabIndex = 43;
            // 
            // r2TextBox
            // 
            this.r2TextBox.Location = new System.Drawing.Point(37, 148);
            this.r2TextBox.Name = "r2TextBox";
            this.r2TextBox.ReadOnly = true;
            this.r2TextBox.Size = new System.Drawing.Size(100, 20);
            this.r2TextBox.TabIndex = 41;
            // 
            // r1TextBox
            // 
            this.r1TextBox.Location = new System.Drawing.Point(38, 119);
            this.r1TextBox.Name = "r1TextBox";
            this.r1TextBox.ReadOnly = true;
            this.r1TextBox.Size = new System.Drawing.Size(100, 20);
            this.r1TextBox.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(220, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Stack Pointer";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(220, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Instruction Register";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(220, 184);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Accumulator";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "DR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "SC";
            // 
            // inputRegisterTextBox
            // 
            this.inputRegisterTextBox.Location = new System.Drawing.Point(325, 29);
            this.inputRegisterTextBox.Name = "inputRegisterTextBox";
            this.inputRegisterTextBox.Size = new System.Drawing.Size(100, 20);
            this.inputRegisterTextBox.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Input Register";
            // 
            // arTextBox
            // 
            this.arTextBox.Location = new System.Drawing.Point(38, 177);
            this.arTextBox.Name = "arTextBox";
            this.arTextBox.ReadOnly = true;
            this.arTextBox.Size = new System.Drawing.Size(100, 20);
            this.arTextBox.TabIndex = 29;
            // 
            // pcTextBox
            // 
            this.pcTextBox.Location = new System.Drawing.Point(37, 29);
            this.pcTextBox.Name = "pcTextBox";
            this.pcTextBox.ReadOnly = true;
            this.pcTextBox.Size = new System.Drawing.Size(100, 20);
            this.pcTextBox.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "AR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "PC";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.microOperationListBox);
            this.groupBox2.Location = new System.Drawing.Point(746, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 276);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Micro Operations";
            // 
            // microOperationListBox
            // 
            this.microOperationListBox.FormattingEnabled = true;
            this.microOperationListBox.Location = new System.Drawing.Point(13, 19);
            this.microOperationListBox.Name = "microOperationListBox";
            this.microOperationListBox.Size = new System.Drawing.Size(467, 238);
            this.microOperationListBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.stackSementDataGridView);
            this.groupBox3.Controls.Add(this.dataSegmentDataGridView);
            this.groupBox3.Controls.Add(this.codeSegmentDataGridView);
            this.groupBox3.Controls.Add(this.labelDataGridView);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(235, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1007, 198);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Memories";
            // 
            // stackSementDataGridView
            // 
            this.stackSementDataGridView.AllowUserToAddRows = false;
            this.stackSementDataGridView.AllowUserToDeleteRows = false;
            this.stackSementDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.stackSementDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.stackSementDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stackSementDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.adressStackSegmentDataGridView,
            this.valueStackSegmentDataGridView});
            this.stackSementDataGridView.Location = new System.Drawing.Point(751, 35);
            this.stackSementDataGridView.Name = "stackSementDataGridView";
            this.stackSementDataGridView.Size = new System.Drawing.Size(240, 157);
            this.stackSementDataGridView.TabIndex = 8;
            // 
            // adressStackSegmentDataGridView
            // 
            this.adressStackSegmentDataGridView.HeaderText = "Adress";
            this.adressStackSegmentDataGridView.Name = "adressStackSegmentDataGridView";
            this.adressStackSegmentDataGridView.ReadOnly = true;
            // 
            // valueStackSegmentDataGridView
            // 
            this.valueStackSegmentDataGridView.HeaderText = "Data";
            this.valueStackSegmentDataGridView.Name = "valueStackSegmentDataGridView";
            this.valueStackSegmentDataGridView.ReadOnly = true;
            // 
            // dataSegmentDataGridView
            // 
            this.dataSegmentDataGridView.AllowUserToAddRows = false;
            this.dataSegmentDataGridView.AllowUserToDeleteRows = false;
            this.dataSegmentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataSegmentDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataSegmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSegmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.adressDataSegmentDataGridView,
            this.valueDataSegmentDataGridView});
            this.dataSegmentDataGridView.Location = new System.Drawing.Point(505, 35);
            this.dataSegmentDataGridView.Name = "dataSegmentDataGridView";
            this.dataSegmentDataGridView.Size = new System.Drawing.Size(240, 157);
            this.dataSegmentDataGridView.TabIndex = 7;
            // 
            // adressDataSegmentDataGridView
            // 
            this.adressDataSegmentDataGridView.HeaderText = "Adress";
            this.adressDataSegmentDataGridView.Name = "adressDataSegmentDataGridView";
            this.adressDataSegmentDataGridView.ReadOnly = true;
            // 
            // valueDataSegmentDataGridView
            // 
            this.valueDataSegmentDataGridView.HeaderText = "Data";
            this.valueDataSegmentDataGridView.Name = "valueDataSegmentDataGridView";
            this.valueDataSegmentDataGridView.ReadOnly = true;
            // 
            // codeSegmentDataGridView
            // 
            this.codeSegmentDataGridView.AllowUserToAddRows = false;
            this.codeSegmentDataGridView.AllowUserToDeleteRows = false;
            this.codeSegmentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.codeSegmentDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.codeSegmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.codeSegmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.adressCodeSegmentDataGridView,
            this.valueCodeSegmentDataGridView});
            this.codeSegmentDataGridView.Location = new System.Drawing.Point(259, 35);
            this.codeSegmentDataGridView.Name = "codeSegmentDataGridView";
            this.codeSegmentDataGridView.Size = new System.Drawing.Size(240, 157);
            this.codeSegmentDataGridView.TabIndex = 6;
            // 
            // adressCodeSegmentDataGridView
            // 
            this.adressCodeSegmentDataGridView.HeaderText = "Adress";
            this.adressCodeSegmentDataGridView.Name = "adressCodeSegmentDataGridView";
            this.adressCodeSegmentDataGridView.ReadOnly = true;
            // 
            // valueCodeSegmentDataGridView
            // 
            this.valueCodeSegmentDataGridView.HeaderText = "Data";
            this.valueCodeSegmentDataGridView.Name = "valueCodeSegmentDataGridView";
            this.valueCodeSegmentDataGridView.ReadOnly = true;
            // 
            // labelDataGridView
            // 
            this.labelDataGridView.AllowUserToAddRows = false;
            this.labelDataGridView.AllowUserToDeleteRows = false;
            this.labelDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.labelDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.adressColumn});
            this.labelDataGridView.Location = new System.Drawing.Point(13, 35);
            this.labelDataGridView.Name = "labelDataGridView";
            this.labelDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.labelDataGridView.Size = new System.Drawing.Size(240, 157);
            this.labelDataGridView.TabIndex = 5;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 99;
            // 
            // adressColumn
            // 
            this.adressColumn.HeaderText = "Adress";
            this.adressColumn.Name = "adressColumn";
            this.adressColumn.ReadOnly = true;
            this.adressColumn.Width = 98;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(748, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stack Segment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data Segment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Code Segment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Labels";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Controls.Add(this.assemblyCodeListBox);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox4.Location = new System.Drawing.Point(12, 63);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(217, 239);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Assembly Code";
            // 
            // button2
            // 
            this.button2.Image = global::DSSEM.Properties.Resources.arrow_step_over_icon;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(362, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Step MicroOperation";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.NextInstructionButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 309);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(217, 212);
            this.listBox1.TabIndex = 26;
            // 
            // StartScreenView
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1254, 534);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectBase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StartScreenView";
            this.Text = "DSSEM";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackSementDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSegmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeSegmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelDataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveButton;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListBox assemblyCodeListBox;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDebugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectBase;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView stackSementDataGridView;
        private System.Windows.Forms.DataGridView dataSegmentDataGridView;
        private System.Windows.Forms.DataGridView codeSegmentDataGridView;
        private System.Windows.Forms.DataGridView labelDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn adressCodeSegmentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueCodeSegmentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn adressStackSegmentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueStackSegmentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn adressDataSegmentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataSegmentDataGridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox arTextBox;
        private System.Windows.Forms.TextBox pcTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox inputRegisterTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adressColumn;
        private System.Windows.Forms.TextBox r1TextBox;
        private System.Windows.Forms.TextBox r2TextBox;
        private System.Windows.Forms.TextBox r4TextBox;
        private System.Windows.Forms.TextBox ırTextBox;
        private System.Windows.Forms.TextBox spTextBox;
        private System.Windows.Forms.ListBox microOperationListBox;
    }
}