using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class ArmourHead : ArmourLegs
    {
        [JsonProperty("mask")]
        public string Mask { get; set; }
    }
}
