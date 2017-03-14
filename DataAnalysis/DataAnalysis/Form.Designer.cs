namespace DataAnalysis {
    partial class Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusterizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxMinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kMeansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kMeansModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classificatinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perceptronToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thDimentionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(491, 260);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintEvent);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 288);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.trackBar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 260);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(491, 28);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar.Location = new System.Drawing.Point(52, 3);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(436, 22);
            this.trackBar.TabIndex = 1;
            this.trackBar.TabStop = false;
            this.trackBar.Value = 50;
            this.trackBar.ValueChanged += new System.EventHandler(this.TrackBarValueChanged);
            this.trackBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrackBarKeyDownEvent);
            this.trackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TrackBarKeyUpEvent);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(3, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(43, 28);
            this.label.TabIndex = 2;
            this.label.Text = "Param:";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem,
            this.algorithmToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.visualizationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(491, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // activeToolStripMenuItem
            // 
            this.activeToolStripMenuItem.Checked = true;
            this.activeToolStripMenuItem.CheckOnClick = true;
            this.activeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            this.activeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.activeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.activeToolStripMenuItem.Text = "Active";
            this.activeToolStripMenuItem.Click += new System.EventHandler(this.activeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // algorithmToolStripMenuItem
            // 
            this.algorithmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clusterizationToolStripMenuItem,
            this.classificatinToolStripMenuItem});
            this.algorithmToolStripMenuItem.Name = "algorithmToolStripMenuItem";
            this.algorithmToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.algorithmToolStripMenuItem.Text = "Algorithm";
            // 
            // clusterizationToolStripMenuItem
            // 
            this.clusterizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maxMinToolStripMenuItem,
            this.kMeansToolStripMenuItem,
            this.kMeansModToolStripMenuItem});
            this.clusterizationToolStripMenuItem.Name = "clusterizationToolStripMenuItem";
            this.clusterizationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clusterizationToolStripMenuItem.Text = "Clusterization";
            // 
            // maxMinToolStripMenuItem
            // 
            this.maxMinToolStripMenuItem.Checked = true;
            this.maxMinToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.maxMinToolStripMenuItem.Name = "maxMinToolStripMenuItem";
            this.maxMinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.maxMinToolStripMenuItem.Text = "Max-Min";
            this.maxMinToolStripMenuItem.Click += new System.EventHandler(this.maxMinToolStripMenuItem_Click);
            // 
            // kMeansToolStripMenuItem
            // 
            this.kMeansToolStripMenuItem.Name = "kMeansToolStripMenuItem";
            this.kMeansToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kMeansToolStripMenuItem.Text = "K-Means";
            this.kMeansToolStripMenuItem.Click += new System.EventHandler(this.kMeansToolStripMenuItem_Click);
            // 
            // kMeansModToolStripMenuItem
            // 
            this.kMeansModToolStripMenuItem.Name = "kMeansModToolStripMenuItem";
            this.kMeansModToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kMeansModToolStripMenuItem.Text = "Max-Min Mod";
            this.kMeansModToolStripMenuItem.Click += new System.EventHandler(this.maxMinModToolStripMenuItem_Click);
            // 
            // classificatinToolStripMenuItem
            // 
            this.classificatinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perceptronToolStripMenuItem});
            this.classificatinToolStripMenuItem.Name = "classificatinToolStripMenuItem";
            this.classificatinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.classificatinToolStripMenuItem.Text = "Classification";
            // 
            // perceptronToolStripMenuItem
            // 
            this.perceptronToolStripMenuItem.Name = "perceptronToolStripMenuItem";
            this.perceptronToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.perceptronToolStripMenuItem.Text = "Perceptron";
            this.perceptronToolStripMenuItem.Click += new System.EventHandler(this.perceptronToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.randomizeToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // randomizeToolStripMenuItem
            // 
            this.randomizeToolStripMenuItem.Name = "randomizeToolStripMenuItem";
            this.randomizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.randomizeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.randomizeToolStripMenuItem.Text = "Randomize";
            this.randomizeToolStripMenuItem.Click += new System.EventHandler(this.randomizeToolStripMenuItem_Click);
            // 
            // visualizationToolStripMenuItem
            // 
            this.visualizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perspectiveToolStripMenuItem,
            this.thDimentionToolStripMenuItem,
            this.showInfoToolStripMenuItem,
            this.axesToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.visualizationToolStripMenuItem.Name = "visualizationToolStripMenuItem";
            this.visualizationToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.visualizationToolStripMenuItem.Text = "Visualization";
            // 
            // perspectiveToolStripMenuItem
            // 
            this.perspectiveToolStripMenuItem.Checked = true;
            this.perspectiveToolStripMenuItem.CheckOnClick = true;
            this.perspectiveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.perspectiveToolStripMenuItem.Name = "perspectiveToolStripMenuItem";
            this.perspectiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.perspectiveToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.perspectiveToolStripMenuItem.Text = "Perspective";
            this.perspectiveToolStripMenuItem.Click += new System.EventHandler(this.perspectiveToolStripMenuItem_Click);
            // 
            // thDimentionToolStripMenuItem
            // 
            this.thDimentionToolStripMenuItem.Checked = true;
            this.thDimentionToolStripMenuItem.CheckOnClick = true;
            this.thDimentionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.thDimentionToolStripMenuItem.Name = "thDimentionToolStripMenuItem";
            this.thDimentionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.thDimentionToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.thDimentionToolStripMenuItem.Text = "4th Dimension";
            this.thDimentionToolStripMenuItem.Click += new System.EventHandler(this.thDimentionToolStripMenuItem_Click);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Checked = true;
            this.showInfoToolStripMenuItem.CheckOnClick = true;
            this.showInfoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.showInfoToolStripMenuItem.Text = "Show Info";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // axesToolStripMenuItem
            // 
            this.axesToolStripMenuItem.Checked = true;
            this.axesToolStripMenuItem.CheckOnClick = true;
            this.axesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.axesToolStripMenuItem.Name = "axesToolStripMenuItem";
            this.axesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.axesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.axesToolStripMenuItem.Text = "Show Axes";
            this.axesToolStripMenuItem.Click += new System.EventHandler(this.axesToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 312);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.Name = "Form";
            this.Text = "Data Analysis";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUpEvent);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem algorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perspectiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clusterizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxMinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kMeansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classificatinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perceptronToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem axesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thDimentionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kMeansModToolStripMenuItem;
    }
}

