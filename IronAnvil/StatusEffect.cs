using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class StatusEffect
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
      //  [JsonProperty("level")]
      //  public string Level { get; set; }
     
    }
}
