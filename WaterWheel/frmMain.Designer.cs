namespace WaterWheel
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartAnimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGraphViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyParameterValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBucketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBucketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.addBucketToolStripMenuItem,
            this.removeBucketToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartAnimationToolStripMenuItem,
            this.newGraphViewToolStripMenuItem,
            this.modifyParameterValuesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // restartAnimationToolStripMenuItem
            // 
            this.restartAnimationToolStripMenuItem.Name = "restartAnimationToolStripMenuItem";
            this.restartAnimationToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.restartAnimationToolStripMenuItem.Text = "Restart animation";
            this.restartAnimationToolStripMenuItem.Click += new System.EventHandler(this.restartAnimationToolStripMenuItem_Click);
            // 
            // newGraphViewToolStripMenuItem
            // 
            this.newGraphViewToolStripMenuItem.Name = "newGraphViewToolStripMenuItem";
            this.newGraphViewToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.newGraphViewToolStripMenuItem.Text = "New Graph View";
            this.newGraphViewToolStripMenuItem.Click += new System.EventHandler(this.newGraphViewToolStripMenuItem_Click);
            // 
            // modifyParameterValuesToolStripMenuItem
            // 
            this.modifyParameterValuesToolStripMenuItem.Name = "modifyParameterValuesToolStripMenuItem";
            this.modifyParameterValuesToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.modifyParameterValuesToolStripMenuItem.Text = "Modify Parameter Values";
            this.modifyParameterValuesToolStripMenuItem.Click += new System.EventHandler(this.modifyParameterValuesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // addBucketToolStripMenuItem
            // 
            this.addBucketToolStripMenuItem.Name = "addBucketToolStripMenuItem";
            this.addBucketToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.addBucketToolStripMenuItem.Text = "Add Bucket";
            this.addBucketToolStripMenuItem.Click += new System.EventHandler(this.addBucketToolStripMenuItem_Click);
            // 
            // removeBucketToolStripMenuItem
            // 
            this.removeBucketToolStripMenuItem.Name = "removeBucketToolStripMenuItem";
            this.removeBucketToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.removeBucketToolStripMenuItem.Text = "Remove Bucket";
            this.removeBucketToolStripMenuItem.Click += new System.EventHandler(this.removeBucketToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 442);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Chaotic Waterwheel";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBucketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeBucketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartAnimationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyParameterValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGraphViewToolStripMenuItem;
    }
}

