namespace Mystclean
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.msgList = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.scanWorld = new System.Windows.Forms.ToolStripButton();
            this.cleanWorld = new System.Windows.Forms.ToolStripButton();
            this.settings = new System.Windows.Forms.ToolStripButton();
            this.tutorial = new System.Windows.Forms.ToolStripButton();
            this.logGroup = new System.Windows.Forms.GroupBox();
            this.map = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.worldGroup = new System.Windows.Forms.GroupBox();
            this.agesDelete = new System.Windows.Forms.ListBox();
            this.agesDeleteLabel = new System.Windows.Forms.Label();
            this.agesKeepLabel = new System.Windows.Forms.Label();
            this.agesKeep = new System.Windows.Forms.ListBox();
            this.ageMoveToDelete = new System.Windows.Forms.Button();
            this.ageMoveToKeep = new System.Windows.Forms.Button();
            this.selAgePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.selAgeName = new System.Windows.Forms.Label();
            this.selAgeDimension = new System.Windows.Forms.Label();
            this.selAgeSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.selAgeReferences = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            this.logGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.worldGroup.SuspendLayout();
            this.selAgePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgList
            // 
            this.msgList.FormattingEnabled = true;
            this.msgList.Location = new System.Drawing.Point(6, 19);
            this.msgList.Name = "msgList";
            this.msgList.Size = new System.Drawing.Size(412, 134);
            this.msgList.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanWorld,
            this.cleanWorld,
            this.settings,
            this.tutorial});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(588, 43);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // scanWorld
            // 
            this.scanWorld.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanWorld.Image = global::Mystclean.Properties.Resources.scanworld;
            this.scanWorld.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scanWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scanWorld.Name = "scanWorld";
            this.scanWorld.Size = new System.Drawing.Size(136, 40);
            this.scanWorld.Text = "Scan World";
            this.scanWorld.Click += new System.EventHandler(this.scanWorld_Click);
            // 
            // cleanWorld
            // 
            this.cleanWorld.Enabled = false;
            this.cleanWorld.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanWorld.Image = global::Mystclean.Properties.Resources.cleanworld;
            this.cleanWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cleanWorld.Name = "cleanWorld";
            this.cleanWorld.Size = new System.Drawing.Size(90, 40);
            this.cleanWorld.Text = "Clean";
            this.cleanWorld.Click += new System.EventHandler(this.cleanWorld_Click);
            // 
            // settings
            // 
            this.settings.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings.Image = global::Mystclean.Properties.Resources.settings;
            this.settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(112, 40);
            this.settings.Text = "Settings";
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // tutorial
            // 
            this.tutorial.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tutorial.Image = global::Mystclean.Properties.Resources.tutorial;
            this.tutorial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tutorial.Name = "tutorial";
            this.tutorial.Size = new System.Drawing.Size(107, 40);
            this.tutorial.Text = "Tutorial";
            this.tutorial.Click += new System.EventHandler(this.tutorial_Click);
            // 
            // logGroup
            // 
            this.logGroup.Controls.Add(this.map);
            this.logGroup.Controls.Add(this.msgList);
            this.logGroup.Location = new System.Drawing.Point(12, 239);
            this.logGroup.Name = "logGroup";
            this.logGroup.Size = new System.Drawing.Size(564, 159);
            this.logGroup.TabIndex = 2;
            this.logGroup.TabStop = false;
            this.logGroup.Text = "Log";
            // 
            // map
            // 
            this.map.Location = new System.Drawing.Point(424, 19);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(134, 134);
            this.map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.map.TabIndex = 1;
            this.map.TabStop = false;
            this.map.Paint += new System.Windows.Forms.PaintEventHandler(this.map_Paint);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(97, 404);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(479, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(12, 404);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(79, 23);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "READY";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // worldGroup
            // 
            this.worldGroup.Controls.Add(this.label1);
            this.worldGroup.Controls.Add(this.selAgePanel);
            this.worldGroup.Controls.Add(this.ageMoveToKeep);
            this.worldGroup.Controls.Add(this.ageMoveToDelete);
            this.worldGroup.Controls.Add(this.agesKeepLabel);
            this.worldGroup.Controls.Add(this.agesKeep);
            this.worldGroup.Controls.Add(this.agesDeleteLabel);
            this.worldGroup.Controls.Add(this.agesDelete);
            this.worldGroup.Enabled = false;
            this.worldGroup.Location = new System.Drawing.Point(12, 46);
            this.worldGroup.Name = "worldGroup";
            this.worldGroup.Size = new System.Drawing.Size(564, 187);
            this.worldGroup.TabIndex = 5;
            this.worldGroup.TabStop = false;
            this.worldGroup.Text = "World";
            // 
            // agesDelete
            // 
            this.agesDelete.FormattingEnabled = true;
            this.agesDelete.Location = new System.Drawing.Point(413, 34);
            this.agesDelete.Name = "agesDelete";
            this.agesDelete.Size = new System.Drawing.Size(143, 147);
            this.agesDelete.TabIndex = 0;
            this.agesDelete.SelectedIndexChanged += new System.EventHandler(this.agesDelete_SelectedIndexChanged);
            this.agesDelete.DoubleClick += new System.EventHandler(this.ageMoveToKeep_Click);
            // 
            // agesDeleteLabel
            // 
            this.agesDeleteLabel.AutoSize = true;
            this.agesDeleteLabel.Location = new System.Drawing.Point(410, 18);
            this.agesDeleteLabel.Name = "agesDeleteLabel";
            this.agesDeleteLabel.Size = new System.Drawing.Size(75, 13);
            this.agesDeleteLabel.TabIndex = 1;
            this.agesDeleteLabel.Text = "Ages to delete";
            // 
            // agesKeepLabel
            // 
            this.agesKeepLabel.AutoSize = true;
            this.agesKeepLabel.Location = new System.Drawing.Point(209, 18);
            this.agesKeepLabel.Name = "agesKeepLabel";
            this.agesKeepLabel.Size = new System.Drawing.Size(70, 13);
            this.agesKeepLabel.TabIndex = 3;
            this.agesKeepLabel.Text = "Ages to keep";
            // 
            // agesKeep
            // 
            this.agesKeep.FormattingEnabled = true;
            this.agesKeep.Location = new System.Drawing.Point(212, 34);
            this.agesKeep.Name = "agesKeep";
            this.agesKeep.Size = new System.Drawing.Size(143, 147);
            this.agesKeep.TabIndex = 2;
            this.agesKeep.SelectedIndexChanged += new System.EventHandler(this.agesKeep_SelectedIndexChanged);
            this.agesKeep.DoubleClick += new System.EventHandler(this.ageMoveToDelete_Click);
            // 
            // ageMoveToDelete
            // 
            this.ageMoveToDelete.Location = new System.Drawing.Point(361, 78);
            this.ageMoveToDelete.Name = "ageMoveToDelete";
            this.ageMoveToDelete.Size = new System.Drawing.Size(46, 23);
            this.ageMoveToDelete.TabIndex = 4;
            this.ageMoveToDelete.Text = ">";
            this.ageMoveToDelete.UseVisualStyleBackColor = true;
            this.ageMoveToDelete.Click += new System.EventHandler(this.ageMoveToDelete_Click);
            // 
            // ageMoveToKeep
            // 
            this.ageMoveToKeep.Location = new System.Drawing.Point(361, 107);
            this.ageMoveToKeep.Name = "ageMoveToKeep";
            this.ageMoveToKeep.Size = new System.Drawing.Size(46, 23);
            this.ageMoveToKeep.TabIndex = 5;
            this.ageMoveToKeep.Text = "<";
            this.ageMoveToKeep.UseVisualStyleBackColor = true;
            this.ageMoveToKeep.Click += new System.EventHandler(this.ageMoveToKeep_Click);
            // 
            // selAgePanel
            // 
            this.selAgePanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.selAgePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selAgePanel.Controls.Add(this.selAgeReferences);
            this.selAgePanel.Controls.Add(this.label5);
            this.selAgePanel.Controls.Add(this.selAgeSize);
            this.selAgePanel.Controls.Add(this.selAgeDimension);
            this.selAgePanel.Controls.Add(this.selAgeName);
            this.selAgePanel.Controls.Add(this.label4);
            this.selAgePanel.Controls.Add(this.label3);
            this.selAgePanel.Controls.Add(this.label2);
            this.selAgePanel.Location = new System.Drawing.Point(11, 34);
            this.selAgePanel.Name = "selAgePanel";
            this.selAgePanel.Size = new System.Drawing.Size(195, 147);
            this.selAgePanel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selected age info";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(29, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Dimension:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(29, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Size:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selAgeName
            // 
            this.selAgeName.Location = new System.Drawing.Point(94, 3);
            this.selAgeName.Name = "selAgeName";
            this.selAgeName.Size = new System.Drawing.Size(70, 14);
            this.selAgeName.TabIndex = 3;
            this.selAgeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selAgeDimension
            // 
            this.selAgeDimension.Location = new System.Drawing.Point(94, 17);
            this.selAgeDimension.Name = "selAgeDimension";
            this.selAgeDimension.Size = new System.Drawing.Size(70, 14);
            this.selAgeDimension.TabIndex = 4;
            this.selAgeDimension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selAgeSize
            // 
            this.selAgeSize.Location = new System.Drawing.Point(94, 31);
            this.selAgeSize.Name = "selAgeSize";
            this.selAgeSize.Size = new System.Drawing.Size(70, 14);
            this.selAgeSize.TabIndex = 5;
            this.selAgeSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "References";
            // 
            // selAgeReferences
            // 
            this.selAgeReferences.FormattingEnabled = true;
            this.selAgeReferences.Location = new System.Drawing.Point(3, 72);
            this.selAgeReferences.Name = "selAgeReferences";
            this.selAgeReferences.Size = new System.Drawing.Size(187, 69);
            this.selAgeReferences.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 439);
            this.Controls.Add(this.worldGroup);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.logGroup);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Myster Clean - bahstrike 2014";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.logGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.worldGroup.ResumeLayout(false);
            this.worldGroup.PerformLayout();
            this.selAgePanel.ResumeLayout(false);
            this.selAgePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox msgList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton scanWorld;
        private System.Windows.Forms.ToolStripButton cleanWorld;
        private System.Windows.Forms.GroupBox logGroup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.GroupBox worldGroup;
        private System.Windows.Forms.ToolStripButton settings;
        private System.Windows.Forms.ToolStripButton tutorial;
        private System.Windows.Forms.PictureBox map;
        private System.Windows.Forms.Button ageMoveToKeep;
        private System.Windows.Forms.Button ageMoveToDelete;
        private System.Windows.Forms.Label agesKeepLabel;
        private System.Windows.Forms.ListBox agesKeep;
        private System.Windows.Forms.Label agesDeleteLabel;
        private System.Windows.Forms.ListBox agesDelete;
        private System.Windows.Forms.Panel selAgePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox selAgeReferences;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label selAgeSize;
        private System.Windows.Forms.Label selAgeDimension;
        private System.Windows.Forms.Label selAgeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

