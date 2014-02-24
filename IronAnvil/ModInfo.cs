using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class ModInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("dependencies")]
        public ArrayList Dependencies = new ArrayList();
        [JsonProperty("metadata")]
        public MetaData MD { get; set; }
     


        public ModInfo(string path) {
           
        }

        public ModInfo()
        {
            // TODO: Complete member initialization
        }
    }
}
