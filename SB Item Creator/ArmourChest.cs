using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class ArmourChest : Armour
    {
        [JsonProperty("maleFrames")]
        public Frames MFrames { get; set; }
        [JsonProperty("femaleFrames")]
        public Frames FFrames { get; set; }

    }
}
