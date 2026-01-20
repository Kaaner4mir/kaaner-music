using Newtonsoft.Json;

// Gereksiz using ifadeleri temizlendi.

namespace KaanerMusic
{
    /// <summary>
    /// Song data model class.
    /// Represents data coming from and going to JSON/GitHub.
    /// </summary>
    public class Song
    {
        [JsonProperty("Name")]
        public string Title { get; set; }
        
        public string Artist { get; set; } = "Unknown Artist";
        
        [JsonProperty("Link")]
        public string FileUrl { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Called when object is displayed in controls like ListBox.
        /// </summary>
        /// <returns>Text to appear on screen (Song Title only).</returns>
        public override string ToString()
        {
            return $"{Title}"; 
        }
    }
}
