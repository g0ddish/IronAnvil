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
using Newtonsoft.Json.Linq;

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
            item = itemTypebox.SelectedItem.ToString();
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
            //  ItemBuilder item = new ItemBuilder();
            float[] coll = new float[4];
            int i = 1;
            ArrayList sees = new ArrayList();
            switch (itemTypebox.Text)
            {

                case ("Armour"):
                    switch (typetxt.Text)
                    {
                        case "chest":
                            ArmourChest chest = new ArmourChest();
                            chest.RefrenceName = itemNametxtbox.Text.Replace(" ", string.Empty).ToLower().Replace("'", string.Empty);
                            chest.Name = itemNametxtbox.Text;
                            chest.IconPath = invicotxt.Text;
                            
                            
                            coll[0] = float.Parse(dropCol1.Text);
                            coll[1] = float.Parse(dropCol2.Text);
                            coll[2] = float.Parse(dropCol3.Text);
                            coll[3] = float.Parse(dropCol4.Text);
                            chest.Collisions = coll;
                            chest.MaxStack = Convert.ToInt32(maxstack.Value);
                            chest.Rarity = raritybox.Text;
                            chest.Description = Description.Text;
                            chest.InspectionKind = "armor";
                            Frames male = new Frames();
                            male.Body = maleframetxt.Text;
                            male.BackS = backmtxt.Text;
                            male.FrontS = frontmtxt.Text;
                            Frames female = new Frames();
                            female.Body = femaleframetxt.Text;
                            female.BackS = backftxt.Text;
                            female.FrontS = frontftxt.Text;
                            chest.MFrames = male;
                            chest.FFrames = female;
                  
                            //ah.StatusEffectsString
                           
                     
                            foreach (DataGridViewRow se in armourStatusEffects.Rows)
                            {
                                if (se.Cells[0].Value != null && se.Cells[1].Value != null)
                                {
                                    se.Cells[0].FormattedValue.ToString();
                                    StatusEffect see = new StatusEffect();
                                    see.Kind = se.Cells[0].Value.ToString();
                                    string str = se.Cells[i].Value.ToString();
                                    see.Amount = Convert.ToInt32(str);
                                    System.Console.Write(str);
                                    // see.Amount = a;
                                    //  i++;
                                    try
                                    {
                                        //  see.Level = se.Cells[2].Value.ToString();
                                        sees.Add(see);
                                    }
                                    catch (Exception l)
                                    {
                                        sees.Add(see);
                                    }


                                }
                                chest.StatusEffectsString = sees;

                                var json = JsonConvert.SerializeObject(chest, Formatting.Indented);
                                Console.Write(json);
                                rawcode.Text = json;
                            }
                            break;
                        case "head":
                            ArmourHead ahead = new ArmourHead();
                            ahead.RefrenceName = itemNametxtbox.Text.Replace(" ", string.Empty).ToLower().Replace("'", string.Empty);
                            ahead.Name = itemNametxtbox.Text;
                            ahead.IconPath = invicotxt.Text;
                            ahead.Mask = masktxtbox.Text;
                            
                            coll[0] = float.Parse(dropCol1.Text);
                            coll[1] = float.Parse(dropCol2.Text);
                            coll[2] = float.Parse(dropCol3.Text);
                            coll[3] = float.Parse(dropCol4.Text);
                            ahead.Collisions = coll;
                            ahead.MaxStack = Convert.ToInt32(maxstack.Value);
                            ahead.Rarity = raritybox.Text;
                            ahead.Description = Description.Text;
                            ahead.InspectionKind = "armor";
                            ahead.MaleFrames = maleframetxt.Text;
                            ahead.FemaleFrames = femaleframetxt.Text;
                            //ah.StatusEffectsString
                           
                     
                            foreach (DataGridViewRow se in armourStatusEffects.Rows)
                            {
                                if (se.Cells[0].Value != null && se.Cells[1].Value != null)
                                {
                                    se.Cells[0].FormattedValue.ToString();
                                    StatusEffect see = new StatusEffect();
                                    see.Kind = se.Cells[0].Value.ToString();
                                    string str = se.Cells[i].Value.ToString();
                                    see.Amount = Convert.ToInt32(str);
                                    System.Console.Write(str);
                                    // see.Amount = a;
                                    //  i++;
                                    try
                                    {
                                        //  see.Level = se.Cells[2].Value.ToString();
                                        sees.Add(see);
                                    }
                                    catch (Exception l)
                                    {
                                        sees.Add(see);
                                    }


                                }
                                ahead.StatusEffectsString = sees;

                                var json = JsonConvert.SerializeObject(ahead, Formatting.Indented);
                                Console.Write(json);
                                rawcode.Text = json;
                            }
                            break;
                        case "pants":
                            ArmourLegs ah = new ArmourLegs();
                            ah.RefrenceName = itemNametxtbox.Text.Replace(" ", string.Empty).ToLower().Replace("'", string.Empty);
                            ah.Name = itemNametxtbox.Text;
                            ah.IconPath = invicotxt.Text;

                            
                            coll[0] = float.Parse(dropCol1.Text);
                            coll[1] = float.Parse(dropCol2.Text);
                            coll[2] = float.Parse(dropCol3.Text);
                            coll[3] = float.Parse(dropCol4.Text);
                            ah.Collisions = coll;
                            ah.MaxStack = Convert.ToInt32(maxstack.Value);
                            ah.Rarity = raritybox.Text;
                            ah.Description = Description.Text;
                            ah.InspectionKind = "armor";
                            ah.MaleFrames = maleframetxt.Text;
                            ah.FemaleFrames = femaleframetxt.Text;
                            //ah.StatusEffectsString
                            
                           
                            foreach (DataGridViewRow se in armourStatusEffects.Rows)
                            {
                                if (se.Cells[0].Value != null && se.Cells[1].Value != null)
                                {
                                    se.Cells[0].FormattedValue.ToString();
                                    StatusEffect see = new StatusEffect();
                                    see.Kind = se.Cells[0].Value.ToString();
                                    string str = se.Cells[i].Value.ToString();
                                    see.Amount = Convert.ToInt32(str);
                                    System.Console.Write(str);
                                    // see.Amount = a;
                                    //  i++;
                                    try
                                    {
                                        //  see.Level = se.Cells[2].Value.ToString();
                                        sees.Add(see);
                                    }
                                    catch (Exception l)
                                    {
                                        sees.Add(see);
                                    }


                                }
                                ah.StatusEffectsString = sees;

                                var json = JsonConvert.SerializeObject(ah, Formatting.Indented);
                                Console.Write(json);
                                rawcode.Text = json;
                            }

                            break;
                        case ("Coin"):
                            break;
                        case ("Generic"):
                            break;
                        case ("Gun"):
                            break;
                        case ("Instrument"):
                            break;
                        case ("Material"):
                            break;
                        case ("Shield"):
                            break;
                        case ("Melee"):
                            break;
                        case ("Throwable"):
                            break;
                        case ("Tool"):
                            break;
                        default:
                            break;

                    }
                    break;


            }
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

        private string StarboundPath;
        private string AssetFolder;
        private void Form1_Load(object sender, EventArgs e)
        {
          

            this.listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_MouseDoubleClick);
            this.listBox2.MouseDoubleClick += new MouseEventHandler(listBox2_MouseDoubleClick);

            if (File.Exists(Environment.CurrentDirectory + "\\config.cfg"))
            {
                string[] lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\config.cfg");
                AssetFolder = lines[0];
                StarboundPath = lines[1];
            }
            else      //FIRST RUN BELOW IN THIS ELSE
            {
                if (File.Exists("C:\\Program Files (x86)\\Steam\\Steam.exe"))  //Checks for steam installion and bit
                {
                    folderBrowserDialog1.SelectedPath = "C:\\Program Files (x86)\\Steam\\SteamApps\\common\\Starbound\\";
                    StarboundPath = folderBrowserDialog1.SelectedPath;
                }
                else if (File.Exists("C:\\Program Files\\Steam\\Steam.exe"))
                {
                    folderBrowserDialog1.SelectedPath = "C:\\Program Files\\Steam\\SteamApps\\common\\Starbound\\";
                    StarboundPath = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Starbound not found on C Drive");
                    Application.Exit();
                }
                if (!Directory.Exists(folderBrowserDialog1.SelectedPath + "assets\\unpacked"))          //Looks for unpacked assets and unpack
                {
                    MessageBox.Show(
                      @"
                    This program requires the Starbound data. 
                    Run asset_unpacket.bat in SteamApps\common\Starbound\win32 
                    or if you've already extracted it select select the Starbound folder");
                    if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        AssetFolder = folderBrowserDialog1.SelectedPath;
                        Console.Write(AssetFolder);
                        if (Directory.Exists(AssetFolder + "\\items") || Directory.Exists(AssetFolder + "\\animations"))
                        {
                            AssetFolder = folderBrowserDialog1.SelectedPath;
                            string[] data = { AssetFolder, StarboundPath };
                            string path2 = Environment.CurrentDirectory + "\\config.cfg";
                            System.IO.File.WriteAllLines(path2, data);
                            System.Console.Write(AssetFolder);
                        }
                        else {
                            MessageBox.Show("This is not an asset folder");
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    AssetFolder = folderBrowserDialog1.SelectedPath + "assets\\unpacked";
                    if (Directory.Exists(AssetFolder + "\\items") || Directory.Exists(AssetFolder + "\\animations"))
                    {
                        AssetFolder = folderBrowserDialog1.SelectedPath;
                        string[] data = { AssetFolder, StarboundPath };
                        string path2 = Environment.CurrentDirectory + "\\config.cfg";
                        System.IO.File.WriteAllLines(path2, data);
                        System.Console.Write(AssetFolder);
                    }
                    else
                    {
                        MessageBox.Show("This is not an asset folder");
                        Application.Exit();
                    }
                }
               
            }
                String[] allfiles = System.IO.Directory.GetFiles(StarboundPath + "mods", "*.modinfo", System.IO.SearchOption.AllDirectories);
                int i = 0;
                foreach (string remove in allfiles)
                {
                    allfiles[i] = remove.Replace(StarboundPath + "mods\\", string.Empty);
                    i++;
                }
                string path = AssetFolder;
                String[] allfile = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories);
                String[] items2 = allfile.Select(x => x.Replace(path, string.Empty)).ToArray();
                listBox1.DataSource = items2;

                object[] objCollection = new object[listBox1.Items.Count];
                listBox1.Items.CopyTo(objCollection, 0);
                String search = textBox6.Text;
                foreach (object str in objCollection)
                {

                    allfs.Add(str.ToString());
                }

                
                listBox2.DataSource = allfiles;
            
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

       private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
              
                string moditemdata = File.ReadAllText(AssetFolder + listBox1.SelectedItem.ToString());
                string itemextention = Path.GetExtension(AssetFolder + listBox1.SelectedItem.ToString());
           string path =Path.GetDirectoryName(AssetFolder + listBox1.SelectedItem.ToString());
           switch(itemextention){
               case(".chest"):
                   itemTypebox.Text = "Armour";
                    AddDefaultTabs();
                   tabControl1.TabPages.Add(Armour);
                   ArmourChest chest = JsonConvert.DeserializeObject<ArmourChest>(moditemdata);
                   itemNametxtbox.Text = chest.Name;
                   maxstack.Value = chest.MaxStack;
                   raritybox.Text = chest.Rarity;
                   dropCol1.Text = chest.Collisions[0].ToString();
                   dropCol2.Text = chest.Collisions[1].ToString();
                   dropCol3.Text = chest.Collisions[2].ToString();
                   dropCol4.Text = chest.Collisions[3].ToString();
                   itemTypebox.Text = "Armour";

                   string[] file = chest.IconPath.Split(':');
                   invicopicbox.Image = Image.FromFile(path + "\\" + file[0]);

                   invicotxt.Text = file[0];
                   typetxt.Text = file[1];
                   maleframetxt.Text = chest.MFrames.Body;
                   
                  // d.Text = chest.MFrames.Body;
                   maleframetxt.Text = chest.MFrames.Body;
                   backmtxt.Text = chest.MFrames.BackS;
                   frontmtxt.Text = chest.MFrames.FrontS;


                   femaleframetxt.Text = chest.FFrames.Body;
                   frontftxt.Text = chest.FFrames.FrontS;
                   backftxt.Text = chest.FFrames.BackS;

                   maleframebox.Image = Image.FromFile(path + "\\" + chest.MFrames.Body);
                   backmpic.Image = Image.FromFile(path + "\\" + chest.MFrames.BackS);
                   frontmpic.Image = Image.FromFile(path + "\\" + chest.MFrames.FrontS);

                   femaleframebox.Image = Image.FromFile(path + "\\" + chest.FFrames.Body);
                   this.armourStatusEffects.Rows.Clear();
                   foreach (JObject se in chest.StatusEffectsString)
                   {
                       JToken token = (JToken)se;
                       string kind = (string)token.SelectToken("kind");
                       int amount = (int)token.SelectToken("amount");
                       if (token.SelectToken("level") != null)
                       {

                           int level = (int)token.SelectToken("level");
                           this.armourStatusEffects.Rows.Add(kind, amount, level);
                          
                       }
                       else { 
                          this.armourStatusEffects.Rows.Add(kind, amount);
                       }
                       
                    
                     
                       System.Console.WriteLine(kind);
                   }
                   
                   break;
               case(".legs"):
                   AddDefaultTabs();
                   tabControl1.TabPages.Add(Armour);
                   ArmourLegs legs = JsonConvert.DeserializeObject<ArmourLegs>(moditemdata);
                   itemNametxtbox.Text = legs.Name;
                   maxstack.Value = legs.MaxStack;
                   raritybox.Text = legs.Rarity;
                   dropCol1.Text = legs.Collisions[0].ToString();
                   dropCol2.Text = legs.Collisions[1].ToString();
                   dropCol3.Text = legs.Collisions[2].ToString();
                   dropCol4.Text = legs.Collisions[3].ToString();
                   itemTypebox.Text = "Armour";
                   
                    string[] filez =  legs.IconPath.Split(':');
                   invicopicbox.Image = Image.FromFile(path + "\\" + filez[0]);

                   invicotxt.Text = filez[0];
                   typetxt.Text = filez[1];
                   maleframetxt.Text = legs.MaleFrames;
                   femaleframetxt.Text = legs.FemaleFrames;
                   maleframebox.Image = Image.FromFile(path + "\\" + legs.MaleFrames);
                   femaleframebox.Image = Image.FromFile(path + "\\" + legs.FemaleFrames);
                   this.armourStatusEffects.Rows.Clear();
                   foreach(JObject se in legs.StatusEffectsString){
                       JToken token = (JToken)se;
                       string kind = (string)token.SelectToken("kind");
                       int amount = (int)token.SelectToken("amount");
                       if (token.SelectToken("level") != null)
                       {

                           int level = (int)token.SelectToken("level");
                           this.armourStatusEffects.Rows.Add(kind, amount, level);
                          
                       }
                       else { 
                          this.armourStatusEffects.Rows.Add(kind, amount);
                       }
                       
                    
                     
                       System.Console.WriteLine(kind);
                   }
                   
                   
                   break;
               case(".head"):
                     AddDefaultTabs();
                   tabControl1.TabPages.Add(Armour);
                   ArmourHead head = JsonConvert.DeserializeObject<ArmourHead>(moditemdata);
                   itemTypebox.Text = "Armour";
                   facemaskpic.Image = Image.FromFile(path + "\\" + head.Mask);
                   masktxtbox.Text = head.Mask;
                   itemNametxtbox.Text = head.Name;
                   maxstack.Value = head.MaxStack;
                   raritybox.Text = head.Rarity;
                   dropCol1.Text = head.Collisions[0].ToString();
                   dropCol2.Text = head.Collisions[1].ToString();
                   dropCol3.Text = head.Collisions[2].ToString();
                   dropCol4.Text = head.Collisions[3].ToString();
                   itemTypebox.Text = "Armour";

                   string[] files = head.IconPath.Split(':');
                   invicopicbox.Image = Image.FromFile(path + "\\" + files[0]);

                   invicotxt.Text = files[0];
                   typetxt.Text = files[1];
                   maleframetxt.Text = head.MaleFrames;
                   femaleframetxt.Text = head.FemaleFrames;
                   maleframebox.Image = Image.FromFile(path + "\\" + head.MaleFrames);
                   femaleframebox.Image = Image.FromFile(path + "\\" + head.FemaleFrames);
                   this.armourStatusEffects.Rows.Clear();
                   foreach (JObject se in head.StatusEffectsString)
                   {
                       JToken token = (JToken)se;
                       string kind = (string)token.SelectToken("kind");
                       int amount = (int)token.SelectToken("amount");
                       if (token.SelectToken("level") != null)
                       {

                           int level = (int)token.SelectToken("level");
                           this.armourStatusEffects.Rows.Add(kind, amount, level);
                          
                       }
                       else { 
                          this.armourStatusEffects.Rows.Add(kind, amount);
                       }
                       
                    
                     
                       System.Console.WriteLine(kind);
                   }
                   break;
           }


     
        }

        private void LoadArmour(object armour){
        switch(armour.GetType().ToString()){
            case("ArmourLegs"):
                ArmourLegs legs = (ArmourLegs)armour;
               
                break;
        }
        }

       private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
       {
             // MessageBox.Show(StarboundPath + "mods\\" + listBox2.SelectedItem.ToString());
              string modinfopath = File.ReadAllText(StarboundPath + "mods\\" + listBox2.SelectedItem.ToString());
              LoadedModPath = Path.GetDirectoryName(StarboundPath + "mods\\" + listBox2.SelectedItem.ToString());
              ModInfo data = JsonConvert.DeserializeObject<ModInfo>(modinfopath);
              LoadModInfo(data);
       }
       private string LoadedModPath;

       private void LoadModInfo(ModInfo data) {
           modauthortxtbox.Text = data.MD.Name;
           modnametxtbox.Text = data.Name;
           modpathtxtbox.Text = data.Path;
           moddesctxtbox.Text = data.MD.Description;
           moddependlist.DataSource = data.Dependencies;
           modversioncombobox.Text = data.Version;
           modselectlbl.Text = data.Name;
          // System.Console.Write(LoadedModPath);

       }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
          
        }

        private void amourStatusAddBtn_Click(object sender, EventArgs e)
        {
           
            this.armourStatusEffects.Rows.Add(amourStatusKind.Text, amourStatusAmount.Text);
        }

        private void tabControl1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
          //  ActiveForm.Icon = 
        }

    }
}