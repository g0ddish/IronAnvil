using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class ModInfoNoMeta
    {
        [JsonProperty("name")]
        public string ModName { get; set; }
           [JsonProperty("version")]
        public string GameVersion { get; set; }
           [JsonProperty("path")]
        public string Path { get; set; }
           [JsonProperty("modauthor")]
        public string ModAuthor { get; set; }
           [JsonProperty("modversion")]
        public string ModVersion { get; set; }
           [JsonProperty("moddescription")]
        public string ModDescription { get; set; }
    }
}
