using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SB_Item_Creator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string path = System.IO.Path.Combine(Value.directory,"mods");
        string path2 = System.IO.Path.Combine(Value.directory, "assets");




        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
