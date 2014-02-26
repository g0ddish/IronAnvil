using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SB_Item_Creator
{
    public partial class SaveArmour : Form
    {
        public SaveArmour()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1.Update();
            if (MessageBox.Show("Are you sure you want to save " + f1.itemname + " as a Helmet?", "You sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              
                    if (!System.IO.Directory.Exists(f1.LoadedModPath + "\\items")) {
                        System.IO.Directory.CreateDirectory(f1.LoadedModPath + "\\items");
                    }
                    if (!System.IO.Directory.Exists(f1.LoadedModPath + "\\items\\armors"))
                    {
                        System.IO.Directory.CreateDirectory(f1.LoadedModPath + "\\items\\armors");
                    }
                    string safename = System.Text.RegularExpressions.Regex.Replace(f1.itemname, @"[^a-zA-Z0-9]", "").ToLowerInvariant();
                    System.IO.File.WriteAllText(f1.LoadedModPath + "\\items\\armors\\" + safename + ".head", f1.jsondata);
                    MessageBox.Show(f1.itemname + " written successfully!");
                    this.Close();
            }
        }

        private Form1 f1;
        private void SaveArmour_Load(object sender, EventArgs e)
        {
            Form1 parent = (Form1)this.Owner;
            f1 = parent;
            if (System.IO.Directory.Exists(f1.LoadedModPath))
            { }
            else
            {
                MessageBox.Show("No Mod Path Loaded");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Update();
            if (MessageBox.Show("Are you sure you want to save " + f1.itemname + " as a Chest?", "You sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (!System.IO.Directory.Exists(f1.LoadedModPath + "\\items"))
                {
                    System.IO.Directory.CreateDirectory(f1.LoadedModPath + "\\items");
                }
                if (!System.IO.Directory.Exists(f1.LoadedModPath + "\\items\\armors"))
                {
                    System.IO.Directory.CreateDirectory(f1.LoadedModPath + "\\items\\armors");
                }
                string safename = System.Text.RegularExpressions.Regex.Replace(f1.itemname, @"[^a-zA-Z0-9]", "").ToLowerInvariant();
                System.IO.File.WriteAllText(f1.LoadedModPath + "\\items\\armors\\" + safename + ".chest", f1.jsondata);
                MessageBox.Show(f1.itemname + " written successfully!");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f1.Update();
            if (MessageBox.Show("Are you sure you want to save " + f1.itemname + " as a Legs?", "You sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (!System.IO.Directory.Exists(f1.LoadedModPath + "\\items"))
                {
                    System.IO.Directory.CreateDirectory(f1.LoadedModPath + "\\items");
                }
                if (!System.IO.Directory.Exists(f1.LoadedModPath + "\\items\\armors"))
                {
                    System.IO.Directory.CreateDirectory(f1.LoadedModPath + "\\items\\armors");
                }
                string safename = System.Text.RegularExpressions.Regex.Replace(f1.itemname, @"[^a-zA-Z0-9]", "").ToLowerInvariant();
                System.IO.File.WriteAllText(f1.LoadedModPath + "\\items\\armors\\" + safename + ".legs", f1.jsondata);
                MessageBox.Show(f1.itemname + " written successfully!");
                this.Close();
            }
        }
    }
}
