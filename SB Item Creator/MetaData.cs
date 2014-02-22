using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class MetaData
    {

       [JsonProperty("author")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
  
     


        public MetaData(string path) {
           
        }

        public MetaData()
        {
            // TODO: Complete member initialization
        }
    }
}
