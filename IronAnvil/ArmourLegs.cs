using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class ArmourLegs : Armour
    {
        [JsonProperty("maleFrames")]
        public string MaleFrames { get; set; }
        [JsonProperty("femaleFrames")]
        public string FemaleFrames { get; set; }

    }
}
