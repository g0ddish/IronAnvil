using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class Armour
    {
        [JsonProperty("itemName", Required=Required.Always)]
        public string RefrenceName { get; set; }
        [JsonProperty("inventoryIcon", Required = Required.Always)]
        public string IconPath { get; set; }
        [JsonProperty("dropCollision", Required = Required.Always)]
        public float[] Collisions { get; set; }
        [JsonProperty("maxStack", Required = Required.Always)]
        public int MaxStack;
        [JsonProperty("rarity", Required = Required.Always)]
        public string Rarity { get; set; }
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }
        [JsonProperty("shortdescription", Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty("inspectionKind", Required = Required.Always)]
        public string InspectionKind { get; set; }

        [JsonProperty("statusEffects", Required = Required.Always)]
        public ArrayList StatusEffectsString { get; set; }

        [JsonProperty("colorOptions", Required=Required.Default,
            NullValueHandling = NullValueHandling.Ignore)]
        public ArrayList ColorOptions { get; set; }


    

        public Armour() {
            ArrayList test = new ArrayList();
      //      string[] bob = { "hi", "whats", "up" };
         //   test.Add(bob);
          //  ColorOptions = test;
        }
        private ArrayList Test() {
            ArrayList test = new ArrayList();
          //  StatusEffect se = JsonConvert.DeserializeObject<StatusEffect>(StatusEffectsString);
            return test;
        }



       
     
    }
}