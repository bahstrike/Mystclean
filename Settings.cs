using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mystclean
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            Load();
        }

        private void blocksFromOrigin_TextUpdate(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            int dummy;
            if (cb.Text != "Infinite" && (!int.TryParse(cb.Text, out dummy) || dummy <= 0))
            {
                cb.Text = "Infinite";
                cb.SelectAll();
            }
        }

        private void defaults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset to defaults?", "Defaults", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;

            scanPlayers.Checked = true;
            scanEntities.Checked = true;
            scanOverworld.Checked = true;
            scanNether.Checked = true;
            scanEnd.Checked = true;
            scanTwilight.Checked = true;
            scanAges.Checked = true;
            scanOrigin.Text = "0, 0";
            blocksFromOrigin.Text = "Infinite";
            scanHeight.Text = "0 to 256";
            rememberWorld.Checked = false;
            LastWorldPath = string.Empty;

            Save();
        }

        public Ini.IniFile ini = new Ini.IniFile(Path.Combine(Directory.GetCurrentDirectory(), "settings.ini"));

        public string LastWorldPath = string.Empty;

        public void Load()
        {
            rememberWorld.Checked = ini.IniReadValue("General", "RememberWorld", "0") == "1";
            LastWorldPath = ini.IniReadValue("General", "LastWorldPath", "");

            scanPlayers.Checked = ini.IniReadValue("Options", "Players", "1") == "1";
            scanEntities.Checked = ini.IniReadValue("Options", "Entities", "1") == "1";

            scanOverworld.Checked = ini.IniReadValue("Dimensions", "Overworld", "1") == "1";
            scanNether.Checked = ini.IniReadValue("Dimensions", "Nether", "1") == "1";
            scanEnd.Checked = ini.IniReadValue("Dimensions", "End", "1") == "1";
            scanTwilight.Checked = ini.IniReadValue("Dimensions", "Twilight", "1") == "1";
            scanAges.Checked = ini.IniReadValue("Dimensions", "Ages", "1") == "1";

            scanOrigin.Text = ini.IniReadValue("HomeBase", "Origin", "0, 0");
            blocksFromOrigin.Text = ini.IniReadValue("HomeBase", "Distance", "Infinite");
            scanHeight.Text = ini.IniReadValue("HomeBase", "Height", "0 to 256");
        }

        public void Save()
        {
            ini.IniWriteValue("General", "RememberWorld", rememberWorld.Checked ? "1" : "0");
            ini.IniWriteValue("General", "LastWorldPath", LastWorldPath);

            ini.IniWriteValue("Options", "Players", scanPlayers.Checked ? "1" : "0");
            ini.IniWriteValue("Options", "Entities", scanEntities.Checked ? "1" : "0");
            
            ini.IniWriteValue("Dimensions", "Overworld", scanOverworld.Checked ? "1" : "0");
            ini.IniWriteValue("Dimensions", "Nether", scanNether.Checked ? "1" : "0");
            ini.IniWriteValue("Dimensions", "End", scanEnd.Checked ? "1" : "0");
            ini.IniWriteValue("Dimensions", "Twilight", scanTwilight.Checked ? "1" : "0");
            ini.IniWriteValue("Dimensions", "Ages", scanAges.Checked ? "1" : "0");

            ini.IniWriteValue("HomeBase", "Origin", scanOrigin.Text);
            ini.IniWriteValue("HomeBase", "Distance", blocksFromOrigin.Text);
            ini.IniWriteValue("HomeBase", "Height", scanHeight.Text);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }
    }
}
