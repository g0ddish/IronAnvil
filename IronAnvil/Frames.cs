using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class Frames
    {
        [JsonProperty("body", Required = Required.Always)]
        public string Body { get; set; }
        [JsonProperty("backSleeve", Required = Required.Always)]
        public string BackS { get; set; }
        [JsonProperty("frontSleeve", Required = Required.Always)]
        public string FrontS { get; set; }
    }
}
