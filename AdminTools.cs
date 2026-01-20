using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace KaanerMusic
{
    public class AdminTools
    {
        private IFirebaseClient _client;
        private string _githubRawBaseUrl;
        private string _localSongsPath;

        public AdminTools(IFirebaseClient client)
        {
            _client = client;
            // Update this with your actual repo details if they differ
            // Format: https://raw.githubusercontent.com/{User}/{Repo}/{Branch}/{Folder}/
            _githubRawBaseUrl = "https://raw.githubusercontent.com/Kaaner4mir/kaaner-music/main/Songs/";
            
            // Assumes 'Songs' folder is in the project root (where the .exe runs, or one level up during dev)
            // In dev: bin\Debug\Songs might not exist, usually it's in project root.
            // Let's look for it in the project directory relative to execution
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            _localSongsPath = Path.Combine(projectPath, "Songs");
        }

        public async Task<int> SyncSongsToFirebase()
        {
            if (!Directory.Exists(_localSongsPath))
            {
                MessageBox.Show($"'Songs' folder not found at: {_localSongsPath}\nPlease create it and add MP3 files.");
                return 0;
            }

            var files = Directory.GetFiles(_localSongsPath, "*.mp3");
            if (files.Length == 0)
            {
                MessageBox.Show("No .mp3 files found in Songs folder.");
                return 0;
            }

            var songsToUpload = new Dictionary<string, Song>();
            
            foreach (var filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                string urlEncodedName = Uri.EscapeDataString(fileName); // Handle spaces etc.
                string fileUrl = _githubRawBaseUrl + urlEncodedName;

                // Simple metadata parsing (filename based for now to avoid extra Playback dep just for tags)
                // Format assumption: "Artist - Title.mp3" or just "Title.mp3"
                string title = Path.GetFileNameWithoutExtension(fileName);
                string artist = "Unknown Artist";

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

                // Use a safe key for Firebase (no special chars like ., $, #, [, ], /)
                string safeKey = Guid.NewGuid().ToString(); 
                songsToUpload.Add(safeKey, song);
            }

            // Upload to Firebase (Set implies overwrite 'Songs' node, or Update to append. 
            // For fresh sync, Set is cleaner but dangerous if we want to keep old data. 
            // Let's use Set for now as this is a master sync.)
            try
            {
                SetResponse response = await _client.SetAsync("Songs", songsToUpload);
                return songsToUpload.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firebase Upload Error: {ex.Message}");
                return 0;
            }
        }
    }
}
