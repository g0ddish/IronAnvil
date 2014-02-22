using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class ItemBuilder
    {
        ArrayList SAL = new ArrayList();
        public ItemBuilder(){
        SAL.Add("{");
        }

        public string Output() {
            string output = "";
            int count = SAL.Count;
            int i = 0;
            foreach(string s in SAL){
                i++;
                if (i != count)
                {
                    output = output + s + "," + Environment.NewLine;
                }
                else {
                    output = output + s + Environment.NewLine;
                }
            }
            output = output + "}";
            return output;
        
        }

        public void AddName(string itemname) {
            SAL.Add("\"itemName\" : \"" + itemname.Replace(" ", string.Empty).ToLower() + "\"");
            SetShortDesc(itemname);
        }
        public void SetIcon(string path){
            SAL.Add("\"inventoryIcon\" : \"" + path + "\"");
        }
        public void SetDropCollisions(string col1, string col2, string col3, string col4){
            SAL.Add("\"dropCollision\" : [" + col1 + ", " + col2 + ", " + col3 + ", " + col4 + "]");
        }
        public void SetRarity(string rare){
            SAL.Add("\"rarity\" : \"" + rare + "\"");
        }
        public void SetMaxStack(string max){
            SAL.Add("\"maxStack\" : " + max + "");
        }
        public void SetDesc(string desc){
            SAL.Add("\"description\" : \"" + desc + "\"");
        }
        public void SetShortDesc(string desc){
            SAL.Add("\"shortdescription\" : \"" + desc + "\"");
        }
        public void SetInspectionKind(string kind){
            SAL.Add("\"inspectionKind\" : \"" + kind + "\"");
        }
        public void SetPrice(string price) {
            SAL.Add("\"price\" : \"" + price + "\"");
        }
        public void SetRace() { 
        }
        public void SetDesc(string race, string desc) {
            switch (race) { 
                case("Apex"):
                    SAL.Add("\"apexDescription\" : \"" + desc + "\"");
                    break;
                case ("Avian"):
                    SAL.Add("\"avianDescription\" : \"" + desc + "\"");
                    break;
                case ("Floran"):
                    SAL.Add("\"floranDescription\" : \"" + desc + "\"");
                    break;
                case ("Glitch"):
                    SAL.Add("\"glitchDescription\" : \"" + desc + "\"");
                    break;
                case ("Human"):
                    SAL.Add("\"humanDescription\" : \"" + desc + "\"");
                    break;
                case ("Hylotl"):
                    SAL.Add("\"hylotlDescription\" : \"" + desc + "\"");
                    break;
            
            }
        }
        public void SetMainDesc(string desc)
        {
            SAL.Add("\"description\" : \"" + desc + "\"");
        }

        public void SetStatusEffects(ArrayList statuses){
            string build = " \"statusEffects\" : [" + Environment.NewLine;
            foreach (StatusEffect effect in statuses)
            {   
                build = build + "  {" + Environment.NewLine;
                build = build + "   \"kind\" : \"" + effect.GetKind() + "\"," + Environment.NewLine;
                build = build + "   \"amount\" : " + effect.GetAmount() +  Environment.NewLine;
                build = build + "  }," + Environment.NewLine;
            }
            build = build + " ]";
            SAL.Add(build);
        }
        public void SetColorOptions(){
        }



    }
}
