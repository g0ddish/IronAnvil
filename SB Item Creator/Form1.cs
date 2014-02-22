using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Collections;
using Newtonsoft.Json;
using System.Diagnostics;

namespace SB_Item_Creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string colorr="255",colorg="255",colorb="255",item;
        SolidBrush stringbrush = new SolidBrush(Color.Red);


        Color color;
        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog1 = new ColorDialog();
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
             
                colorr = ColorDialog1.Color.R.ToString();
                colorg = ColorDialog1.Color.G.ToString();
                colorb = ColorDialog1.Color.B.ToString();
                //button2.ForeColor = Color.FromArgb(ColorDialog1.Color.G, ColorDialog1.Color.B, ColorDialog1.Color.R);
                color = Color.FromArgb(110,ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            item = comboBox1.SelectedItem.ToString();
            raritybox.Enabled = false;
         
          //  checkedListBox1.Enabled = false;
            if (item == "Gun")
            {
                raritybox.Enabled = true;
              
            }
            else if (item == "Armour")
            {
                raritybox.Enabled = true;
                
                AddDefaultTabs();
                tabControl1.TabPages.Add(Armour);
               // tabControl1.TabPages.Add(Icon);
                tabControl1.TabPages.Add(Description);
                
            }
            else if (item == "Melee")
            {
                tabControl1.TabPages.Add(Melee);
                raritybox.Enabled = true;
            }
            else if (item == "Building Block")
            {
            }
            else if (item == "Shield")
            {
                raritybox.Enabled = true;
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue != CheckState.Checked)
            {
                return;
            }
           // CheckedListBox.CheckedIndexCollection selectedItems = this.checkedListBox1.CheckedIndices;
          //  if (selectedItems.Count > 0)
            {
        //        this.checkedListBox1.SetItemChecked(selectedItems[0], false);
            }
        }

        private void raritybox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Value.itemrarity = raritybox.SelectedItem.ToString().ToLower();
            //label2.Text = Value.itemrarity;  //Shows results on label2
        }

        private void maxstack_TextChanged(object sender, EventArgs e)
        {
            Value.maxstack = maxstack.Text; 
        }

        private void updatecode_Click(object sender, EventArgs e)
        {
            ItemBuilder item = new ItemBuilder();
            item.AddName(itemNametxtbox.Text);
            item.SetDropCollisions(dropCol1.Text, dropCol2.Text, dropCol3.Text, dropCol4.Text);
            item.SetMaxStack(Convert.ToString(maxstack.Value));
            ArrayList effects = new ArrayList();
            foreach (DataGridViewRow row in armourStatusEffects.Rows)
            {
                StatusEffect se = new StatusEffect(row.Cells[0].Value.ToString(), float.Parse(row.Cells[1].Value.ToString()));
                effects.Add(se);        
            }
            item.SetStatusEffects(effects);
            item.SetMainDesc(maindesc.Text);
            if (apexdesc.Text != string.Empty) {
                item.SetDesc("Apex", apexdesc.Text);
            }
            if (aviandesc.Text != string.Empty)
            {
                item.SetDesc("Avian", aviandesc.Text);
            }
            if (florandesc.Text != string.Empty)
            {
                item.SetDesc("Floran", florandesc.Text);
            }
            if (glitchdesc.Text != string.Empty)
            {
                item.SetDesc("Glitch", glitchdesc.Text);
            }
            if (humandesc.Text != string.Empty)
            {
                item.SetDesc("Human", humandesc.Text);
            }
            if (hylotldesc.Text != string.Empty)
            {
                item.SetDesc("Hylotl", hylotldesc.Text);
            }
  
            
           // armourStatusEffects.data
            //item.SetRarity()
          //  item.SetDesc();
          //  item.SetShortDesc();
            
            rawcode.Text = item.Output();
               
        }



        private void rawclear_Click(object sender, EventArgs e)
        {
            rawcode.Clear();
        }

        private String[] StatusEffects = { "Absorption", "Bandage",
           "Beserker",  "BounceBack","BrainReboot","Breath","BreathProtection","Chill","ClumsyProtection",
           "ColdProtection","DirectDamage","DirectPercentileDamage","Doping","Electroshock","Encumbered","Energy","EnergyIncrease","EnergyRegenModifier","EnergyRegenSuppressed","EnergyShield","ExplosiveDefense"
           ,"ExplosiveDefensePower","Fire","FlawedProtection","Food","FoodDepletionSuppressed","ForceField","Glide","Glow","GlowInitiator","Grabbed","Hawkeyes","Health","HealthIncrease","HealthInitiator","HealthProtection","JumpBoost",
           "JumpBoostInitiator","MollyHealing1","MollyHealing2","MollyHealing3","Nude","Overheated","PowerBoost","Protection","RedStim","ReduceFallDamage","RingOfPower","RunBoost","RunBoostInitiator","Shield",
           "ShieldSuppressed","Slow","Spiked","SugarRush","SwimBoost","TestBurning","TestMagma","TestPoison","Warmth","UnderCooled"         };




       private TabPage Main = new TabPage();
       private TabPage Armour = new TabPage();
       private TabPage Icon = new TabPage();
       private TabPage Gun = new TabPage();
       private TabPage Melee = new TabPage();
       private TabPage Projectile = new TabPage();
       private TabPage Recipe = new TabPage();
       private TabPage Description = new TabPage();
       private TabPage Code = new TabPage();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Program Files (x86)\\Steam\\Steam.exe"))
            {
                folderBrowserDialog1.SelectedPath = "C:\\Program Files (x86)\\Steam\\SteamApps\\common\\Starbound\\mods";
            }
            else if (File.Exists("C:\\Program Files\\Steam\\Steam.exe"))
            {
                folderBrowserDialog1.SelectedPath = "C:\\Program Files\\Steam\\SteamApps\\common\\Starbound\\mods";
            }
            if (!Directory.Exists(Environment.CurrentDirectory + "Data")) {
                MessageBox.Show("This requires the Starbound data to run please select the Starbound folder");
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Console.Write(folderBrowserDialog1.SelectedPath);
                 //   Process.Start();
                    Process proc = new Process();
                    proc.StartInfo.FileName = folderBrowserDialog1.SelectedPath + @"\win32\unpack_assets.bat";
                   



File.Copy(folderBrowserDialog1.SelectedPath + "assets/unpacked", Environment.CurrentDirectory + "Data");
    
                }
               }
            Main = tabControl1.TabPages["Maintab"];
            Armour = tabControl1.TabPages["ArmourTab"];
            Melee = tabControl1.TabPages["Meleetab"];
            Icon = tabControl1.TabPages["Iconmodeltab"];
            Gun = tabControl1.TabPages["Guntab"];
            Projectile = tabControl1.TabPages["Projectiletab"];
            Recipe = tabControl1.TabPages["Recipetab"];
            Description = tabControl1.TabPages["Descriptiontab"];
            Code = tabControl1.TabPages["Rawcodetab"];

            amourStatusKind.DataSource = StatusEffects;
            tabControl1.TabPages.Clear();

            tabControl1.TabPages.Add(Main);
            tabControl1.TabPages.Add(Code);
            tabControl1.TabPages.Add(Recipe);
        }

        private void AddDefaultTabs() {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(Main);
            tabControl1.TabPages.Add(Code);
            tabControl1.TabPages.Add(Recipe);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.armourStatusEffects.Rows.Clear();
            this.armourStatusEffects.Rows.Add("ColdProtection", "1");
            this.armourStatusEffects.Rows.Add("Protection", "3.75");
            this.armourStatusEffects.Rows.Add("HealthIncrease", "7.5");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (levelnum.Enabled == false)
            {
                levelnum.Enabled = true;
            }
            else {
                levelnum.Enabled = false;
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = image;
                invicontxtbox.Text = openFileDialog1.SafeFileName;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
          
          
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialog1.SelectedPath;
                openFileDialog1.FileName = string.Empty;
                    string path  = folderBrowserDialog1.SelectedPath;
                    String[] allfiles = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories);
                    String[] items2 = allfiles.Select(x => x.Replace(path, string.Empty)).ToArray();
                    listBox1.DataSource = items2;

                     object[] objCollection = new object[listBox1.Items.Count];
                listBox1.Items.CopyTo(objCollection, 0);
                String search = textBox6.Text;
                foreach (object str in objCollection)
                {
                 
                        allfs.Add(str.ToString());
                    }

                  
                modDatalbl.Text = path;
               string[] files = System.IO.Directory.GetFiles(path, "*.modinfo");
                    Console.Out.WriteLine(files[0]);
                    string modinfo = File.ReadAllText(files[0]);
                    ModInfo mi = JsonConvert.DeserializeObject<ModInfo>(modinfo);
                    modnametxtbox.Text = mi.Name;
                    modversioncombobox.Text = mi.Version;
                    modpathtxtbox.Text = mi.Path;
                    MetaData md = mi.MD;
                    modauthortxtbox.Text = md.Name;
                    moddesctxtbox.Text = md.Description;
                    Console.Out.WriteLine(mi.Name);
                    modDatalbl.Text = mi.Name + " By " + md.Name;
                    modDatalbl.ForeColor = Color.LimeGreen;
                    ModLoaded = true;
                }
        }
        private MetaData md;
        private ModInfo mi;

        private void modauthortxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private bool ModLoaded = false;
        private MetaData savemd = new MetaData();
        private ModInfo savemi = new ModInfo();
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (ModLoaded == true)
            {

                if (MessageBox.Show("Are you sure you want to save ModInfo?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {



                }
                else
                {

                    savemi.Name = modnametxtbox.Text;
                    savemi.Version = modversioncombobox.Text;
                    savemi.Path = modpathtxtbox.Text;
                    savemd.Name = modauthortxtbox.Text;
                    savemd.Description = moddesctxtbox.Text;
                    savemi.MD = savemd;


                    var json = JsonConvert.SerializeObject(savemi);

                    string path = folderBrowserDialog1.SelectedPath;
                    string[] files = System.IO.Directory.GetFiles(path, "*.modinfo");

                    System.IO.File.WriteAllText(@files[0], json);
                    Console.Out.WriteLine(json.ToString());
                    MessageBox.Show("Saved ModInfo");
                }
            }
            else { MessageBox.Show("No Mod loaded would you like to create one?"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog1.FileName);
                invicopicbox.Image = image;
                invicontxtbox.Text = openFileDialog1.SafeFileName;
            }
        }

        private void groupBox18_Enter(object sender, EventArgs e)
        {

        }

        private ArrayList allfs = new ArrayList();
        private ArrayList nw = new ArrayList();
        private void textBox6_TextChanged(object sender, KeyEventArgs e)
        {
         
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

                if (e.KeyChar == (char)Keys.Back)
                {
                    String search = textBox6.Text;
                    nw.Clear();
                    foreach (string str in allfs)
                    {
                        bool contains = str.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
                        if (contains)
                        {
                            nw.Add(str);
                        }
                    }
                    listBox1.DataSource = null;
                    listBox1.DataSource = nw;
                }else
                {
                    String search = textBox6.Text;
                    nw.Clear();
                    foreach (string str in allfs)
                    {
                       bool contains = str.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
                        if (contains){
                            nw.Add(str);
                        }
                    }
                    listBox1.DataSource = null;
                    listBox1.DataSource = nw;
                }   
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                nw.Clear();
                listBox1.DataSource = allfs;
            }
        }

        private void groupBox22_Enter(object sender, EventArgs e)
        {

        }

    }
}