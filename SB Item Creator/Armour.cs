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
        [JsonProperty("itemName")]
        public string RefrenceName { get; set; }
        [JsonProperty("inventoryIcon")]
        public string IconPath { get; set; }
        [JsonProperty("dropCollision")]
        public float[] Collisions { get; set; }
        [JsonProperty("maxStack")]
        public int MaxStack;
        [JsonProperty("rarity")]
        public string Rarity { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("shortdescription")]
        public string Name { get; set; }
        [JsonProperty("inspectionKind")]
        public string InspectionKind { get; set; }

        [JsonProperty("statusEffects")]
        public ArrayList StatusEffectsString { get; set; }

        private ArrayList Test() {
            ArrayList test = new ArrayList();
          //  StatusEffect se = JsonConvert.DeserializeObject<StatusEffect>(StatusEffectsString);
            return test;
        }



       
     
    }
}