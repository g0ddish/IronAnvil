using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class ArmourChest : Armour
    {
        [JsonProperty("maleFrames", Required = Required.Always,
           NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> MFrames { get; set; }
        [JsonProperty("femaleFrames", Required = Required.Always,
            NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> FFrames { get; set; }

    }
}
