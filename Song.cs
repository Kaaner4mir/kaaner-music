using Newtonsoft.Json;

// Gereksiz using ifadeleri temizlendi.

namespace KaanerMusic
{
    /// <summary>
    /// Şarkı veri modeli sınıfı.
    /// Firebase'den gelen ve giden veriyi temsil eder.
    /// </summary>
    public class Song
    {
        // JSON özelliğinin adı "Name" olarak eşleşir.
        [JsonProperty("Name")]
        public string Title { get; set; }
        
        // Sanatçı varsayılan olarak "Bilinmeyen" atanır.
        public string Artist { get; set; } = "Bilinmeyen Sanatçı";
        
        // JSON özelliğinin adı "Link" olarak eşleşir.
        // Şarkının internet üzerindeki (GitHub) indirme/okuma bağlantısı.
        [JsonProperty("Link")]
        public string FileUrl { get; set; }

        // Albüm kapağı resmi linki
        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// ListBox gibi kontrollerde nesne gösterilirken bu metot çağrılır.
        /// </summary>
        /// <returns>Ekranda görünecek metin (Sadece Şarkı Başlığı).</returns>
        public override string ToString()
        {
            return $"{Title}"; 
        }
    }
}
