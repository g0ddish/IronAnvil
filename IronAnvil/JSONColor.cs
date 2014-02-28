using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class JSONColor
    {
        [JsonProperty("ffca8a")]
        public string Color1 { get; set; }
        [JsonProperty("e0975c")]
        public string Color2 { get; set; }
        [JsonProperty("a85636")]
        public string Color3 { get; set; }
        [JsonProperty("6f2919")]
        public string Color4 { get; set; }
        public JSONColor() {
            Color1 = "1";
            Color2 = "2";
            Color3 = "3";
            Color4 = "4";

        }

    }
}
