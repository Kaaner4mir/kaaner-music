    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    namespace KaanerMusic
    {
        public class Song
        {
            [JsonProperty("Name")]
            public string Title { get; set; }
            
            public string Artist { get; set; } = "Unknown Artist"; // Default as not in DB
            
            [JsonProperty("Link")]
            public string FileUrl { get; set; }

            // Helper to display in ListBox
            public override string ToString()
            {
                return $"{Title}"; // Removed Artist from generic connect string since it might be empty
            }
        }
    }
