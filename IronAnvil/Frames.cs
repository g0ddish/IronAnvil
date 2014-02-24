using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class Frames
    {
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("backSleeve")]
        public string BackS { get; set; }
        [JsonProperty("frontSleeve")]
        public string FrontS { get; set; }
    }
}
