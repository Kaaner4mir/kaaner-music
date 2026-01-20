using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace KaanerMusic
{
    /// <summary>
    /// Yönetici Araçları sınıfı.
    /// Yerel dosyaları tarayıp 'songs.json' çalma listesi dosyasını oluşturur.
    /// </summary>
    public class AdminTools
    {
        // GitHub Raw dosya URL kalıbı
        private string _githubRawBaseUrl;
        
        // Yerel şarkıların bulunduğu klasör yolu
        private string _localSongsPath;

        /// <summary>
        /// Yapıcı metot (Constructor).
        /// </summary>
        public AdminTools()
        {
            // GitHub üzerindeki "Songs" klasörünün ham (Raw) veri adresi.
            // Format: https://raw.githubusercontent.com/{Kullanıcı}/{Repo}/{Branch}/{Klasör}/
            _githubRawBaseUrl = "https://raw.githubusercontent.com/Kaaner4mir/kaaner-music/main/Songs/";
            
            // Şarkıların bulunduğu yerel klasör yolunu belirler.
            // Çalışma dizininden 2 üst klasöre (Proje kök dizini) ve oradan 'Songs' klasörüne bakar.
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            _localSongsPath = Path.Combine(projectPath, "Songs");
        }

        /// <summary>
        /// Yerel 'Songs' klasöründeki MP3 dosyalarını tarar ve 'songs.json' dosyasını oluşturur.
        /// </summary>
        /// <returns>Oluşturulan listedeki şarkı sayısı.</returns>
        public Task<int> GeneratePlaylistJson()
        {
            // Klasör kontrolü
            if (!Directory.Exists(_localSongsPath))
            {
                MessageBox.Show($"'Songs' klasörü bulunamadı: {_localSongsPath}\nLütfen klasörü oluşturun ve içine MP3 dosyalarını atın.");
                return Task.FromResult(0);
            }

            // MP3 dosyalarını bul
            var files = Directory.GetFiles(_localSongsPath, "*.mp3");
            if (files.Length == 0)
            {
                MessageBox.Show("'Songs' klasöründe hiç .mp3 dosyası bulunamadı.");
                return Task.FromResult(0);
            }

            // Oluşturulacak şarkı listesi
            var playlist = new List<Song>();
            
            foreach (var filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                
                // URL uyumlu hale getir (boşlukları %20 yap vs.)
                string urlEncodedName = Uri.EscapeDataString(fileName); 
                string fileUrl = _githubRawBaseUrl + urlEncodedName;

                // Basit metadata ayrıştırma (Dosya adına göre)
                // Format: "Artist - Title.mp3" veya "Title.mp3"
                string title = Path.GetFileNameWithoutExtension(fileName);
                string artist = "Bilinmeyen Sanatçı";

                if (title.Contains("-"))
                {
                    var parts = title.Split('-');
                    if (parts.Length >= 2)
                    {
                        artist = parts[0].Trim();
                        title = string.Join("-", parts.Skip(1)).Trim();
                    }
                }

                var song = new Song
                {
                    Title = title,
                    Artist = artist,
                    FileUrl = fileUrl
                };

                playlist.Add(song);
            }

            try
            {
                // Listeyi JSON formatına çevir
                string jsonOutput = JsonConvert.SerializeObject(playlist, Formatting.Indented);
                
                // songs.json dosyasına yaz
                string jsonPath = Path.Combine(_localSongsPath, "songs.json");
                File.WriteAllText(jsonPath, jsonOutput);
                
                return Task.FromResult(playlist.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"JSON Oluşturma Hatası: {ex.Message}");
                return Task.FromResult(0);
            }
        }
    }
}
