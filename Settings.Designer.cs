namespace Mystclean
{
    partial class Settings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scanTwilight = new System.Windows.Forms.CheckBox();
            this.scanAges = new System.Windows.Forms.CheckBox();
            this.scanEnd = new System.Windows.Forms.CheckBox();
            this.scanNether = new System.Windows.Forms.CheckBox();
            this.scanOverworld = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.scanEntities = new System.Windows.Forms.CheckBox();
            this.scanPlayers = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.scanHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.blocksFromOrigin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.defaults = new System.Windows.Forms.Button();
            this.scanOrigin = new System.Windows.Forms.ComboBox();
            this.rememberWorld = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scanTwilight);
            this.groupBox1.Controls.Add(this.scanAges);
            this.groupBox1.Controls.Add(this.scanEnd);
            this.groupBox1.Controls.Add(this.scanNether);
            this.groupBox1.Controls.Add(this.scanOverworld);
            this.groupBox1.Location = new System.Drawing.Point(211, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimensions to Scan";
            // 
            // scanTwilight
            // 
            this.scanTwilight.AutoSize = true;
            this.scanTwilight.Checked = true;
            this.scanTwilight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scanTwilight.Location = new System.Drawing.Point(6, 88);
            this.scanTwilight.Name = "scanTwilight";
            this.scanTwilight.Size = new System.Drawing.Size(94, 17);
            this.scanTwilight.TabIndex = 4;
            this.scanTwilight.Text = "Twilight Forest";
            this.scanTwilight.UseVisualStyleBackColor = true;
            // 
            // scanAges
            // 
            this.scanAges.AutoSize = true;
            this.scanAges.Checked = true;
            this.scanAges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scanAges.Location = new System.Drawing.Point(6, 111);
            this.scanAges.Name = "scanAges";
            this.scanAges.Size = new System.Drawing.Size(96, 17);
            this.scanAges.TabIndex = 3;
            this.scanAges.Text = "Mystcraft Ages";
            this.scanAges.UseVisualStyleBackColor = true;
            // 
            // scanEnd
            // 
            this.scanEnd.AutoSize = true;
            this.scanEnd.Checked = true;
            this.scanEnd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scanEnd.Location = new System.Drawing.Point(6, 65);
            this.scanEnd.Name = "scanEnd";
            this.scanEnd.Size = new System.Drawing.Size(45, 17);
            this.scanEnd.TabIndex = 2;
            this.scanEnd.Text = "End";
            this.scanEnd.UseVisualStyleBackColor = true;
            // 
            // scanNether
            // 
            this.scanNether.AutoSize = true;
            this.scanNether.Checked = true;
            this.scanNether.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scanNether.Location = new System.Drawing.Point(6, 42);
            this.scanNether.Name = "scanNether";
            this.scanNether.Size = new System.Drawing.Size(58, 17);
            this.scanNether.TabIndex = 1;
            this.scanNether.Text = "Nether";
            this.scanNether.UseVisualStyleBackColor = true;
            // 
            // scanOverworld
            // 
            this.scanOverworld.AutoSize = true;
            this.scanOverworld.Checked = true;
            this.scanOverworld.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scanOverworld.Location = new System.Drawing.Point(6, 19);
            this.scanOverworld.Name = "scanOverworld";
            this.scanOverworld.Size = new System.Drawing.Size(74, 17);
            this.scanOverworld.TabIndex = 0;
            this.scanOverworld.Text = "Overworld";
            this.scanOverworld.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.scanEntities);
            this.groupBox2.Controls.Add(this.scanPlayers);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 46);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scan Options";
            // 
            // scanEntities
            // 
            this.scanEntities.AutoSize = true;
            this.scanEntities.Checked = true;
            this.scanEntities.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scanEntities.Location = new System.Drawing.Point(85, 19);
            this.scanEntities.Name = "scanEntities";
            this.scanEntities.Size = new System.Drawing.Size(60, 17);
            this.scanEntities.TabIndex = 6;
            this.scanEntities.Text = "Entities";
            this.scanEntities.UseVisualStyleBackColor = true;
            // 
            // scanPlayers
            // 
            this.scanPlayers.AutoSize = true;
            this.scanPlayers.Checked = true;
            this.scanPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scanPlayers.Location = new System.Drawing.Point(6, 19);
            this.scanPlayers.Name = "scanPlayers";
            this.scanPlayers.Size = new System.Drawing.Size(60, 17);
            this.scanPlayers.TabIndex = 5;
            this.scanPlayers.Text = "Players";
            this.scanPlayers.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.scanOrigin);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.scanHeight);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.blocksFromOrigin);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 86);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Home Base";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Scan origin:";
            // 
            // scanHeight
            // 
            this.scanHeight.Location = new System.Drawing.Point(131, 60);
            this.scanHeight.Name = "scanHeight";
            this.scanHeight.Size = new System.Drawing.Size(55, 20);
            this.scanHeight.TabIndex = 3;
            this.scanHeight.Text = "0 to 256";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height:";
            // 
            // blocksFromOrigin
            // 
            this.blocksFromOrigin.FormattingEnabled = true;
            this.blocksFromOrigin.Items.AddRange(new object[] {
            "Infinite",
            "150",
            "500",
            "1000",
            "2500",
            "5000",
            "10000"});
            this.blocksFromOrigin.Location = new System.Drawing.Point(131, 37);
            this.blocksFromOrigin.Name = "blocksFromOrigin";
            this.blocksFromOrigin.Size = new System.Drawing.Size(55, 21);
            this.blocksFromOrigin.TabIndex = 1;
            this.blocksFromOrigin.Text = "Infinite";
            this.blocksFromOrigin.TextUpdate += new System.EventHandler(this.blocksFromOrigin_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Blocks from origin:";
            // 
            // defaults
            // 
            this.defaults.Location = new System.Drawing.Point(12, 156);
            this.defaults.Name = "defaults";
            this.defaults.Size = new System.Drawing.Size(75, 23);
            this.defaults.TabIndex = 3;
            this.defaults.Text = "Defaults";
            this.defaults.UseVisualStyleBackColor = true;
            this.defaults.Click += new System.EventHandler(this.defaults_Click);
            // 
            // scanOrigin
            // 
            this.scanOrigin.FormattingEnabled = true;
            this.scanOrigin.Items.AddRange(new object[] {
            "0, 0",
            "player"});
            this.scanOrigin.Location = new System.Drawing.Point(131, 14);
            this.scanOrigin.Name = "scanOrigin";
            this.scanOrigin.Size = new System.Drawing.Size(55, 21);
            this.scanOrigin.TabIndex = 7;
            this.scanOrigin.Text = "0, 0";
            // 
            // rememberWorld
            // 
            this.rememberWorld.AutoSize = true;
            this.rememberWorld.Location = new System.Drawing.Point(240, 160);
            this.rememberWorld.Name = "rememberWorld";
            this.rememberWorld.Size = new System.Drawing.Size(105, 17);
            this.rememberWorld.TabIndex = 4;
            this.rememberWorld.Text = "Remember world";
            this.rememberWorld.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 190);
            this.Controls.Add(this.rememberWorld);
            this.Controls.Add(this.defaults);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.CheckBox scanTwilight;
        public System.Windows.Forms.CheckBox scanAges;
        public System.Windows.Forms.CheckBox scanEnd;
        public System.Windows.Forms.CheckBox scanNether;
        public System.Windows.Forms.CheckBox scanOverworld;
        public System.Windows.Forms.CheckBox scanEntities;
        public System.Windows.Forms.CheckBox scanPlayers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox blocksFromOrigin;
        public System.Windows.Forms.TextBox scanHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button defaults;
        public System.Windows.Forms.ComboBox scanOrigin;
        public System.Windows.Forms.CheckBox rememberWorld;
    }
}