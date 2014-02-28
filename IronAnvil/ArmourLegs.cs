using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class ArmourLegs : Armour
    {
        [JsonProperty("maleFrames", Required = Required.Always,
           NullValueHandling = NullValueHandling.Ignore)]
        public string MaleFrames { get; set; }
        [JsonProperty("femaleFrames", Required = Required.Always,
           NullValueHandling = NullValueHandling.Ignore)]
        public string FemaleFrames { get; set; }

    }
}
