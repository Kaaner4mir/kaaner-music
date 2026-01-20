using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

// Gereksiz 'using' ifadeleri temizlendi.
// FireSharp yerine System.Net.Http (HttpClient) kullanılıyor.

namespace KaanerMusic
{
    /// <summary>
    /// Ana Form sınıfı (Main Form). Uygulamanın kullanıcı arayüzünü ve temel mantığını yönetir.
    /// </summary>
    public partial class main_form : Form
    {
        // Pencereleri kenarlıksız (borderless) yapınca sürükleyebilmek için gerekli Windows API sabitleri
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        /// <summary>
        /// Windows mesajlarını işlemek için API çağrısı.
        /// </summary>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Fare yakalamayı serbest bırakmak için API çağrısı.
        /// </summary>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // İpucu kutucuğu (Tooltip) nesnesi
        ToolTip _toolTip = new ToolTip();
        
        // Müzik çalar mantığını yöneten nesne
        private MusicPlayer _musicPlayer;
        
        // Şarkı listesini tutan liste
        private List<Song> _songs;
        
        // O an çalan şarkı nesnesi
        private Song _currentSong;

        // GitHub üzerinden veri çekmek için HTTP istemcisi
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Formun yapıcı metodu (Constructor).
        /// </summary>
        public main_form()
        {
            InitializeComponent();
            _toolTip.InitialDelay = 1000; // Tooltip gecikmesi

            #region Tooltips (İpuçları)
            // Butonların üzerine gelince çıkacak yazıları ayarlar
            _toolTip.SetToolTip(btn_play, "Oynat");
            _toolTip.SetToolTip(btn_resume, "Duraklat");
            _toolTip.SetToolTip(btn_previous_song, "Önceki Şarkı");
            _toolTip.SetToolTip(btn_next_song, "Sonraki Şarkı");
            _toolTip.SetToolTip(btn_admin_sync, "Şarkı Listesini Oluştur (Admin)");
            #endregion

            // Mantık sınıflarını başlatır
            _musicPlayer = new MusicPlayer();
            _musicPlayer.PlaybackStopped += OnMusicPlaybackStopped; // Otomatik geçiş için olay

            // Olayları (Events) bağlar
            lst_songs.SelectedIndexChanged += Lst_songs_SelectedIndexChanged;

            // Şarkıları GitHub'dan yükler
            LoadSongsFromGitHub();
        }

        /// <summary>
        /// GitHub üzerinden 'songs.json' dosyasını çeker ve listeyi doldurur.
        /// </summary>
        private async void LoadSongsFromGitHub()
        {
            try
            {
                // GitHub üzerindeki raw songs.json dosyasının adresi
                string songsJsonUrl = "https://raw.githubusercontent.com/Kaaner4mir/kaaner-music/main/Songs/songs.json";
                
                // Cache (önbellek) sorununu aşmak için timestamp ekliyoruz
                string urlWithNoCache = $"{songsJsonUrl}?t={DateTime.Now.Ticks}";

                // JSON verisini indir
                string jsonContent = await _httpClient.GetStringAsync(urlWithNoCache);
                
                // JSON'ı listeye çevir
                _songs = JsonConvert.DeserializeObject<List<Song>>(jsonContent);

                // Şarkı listesi oluştuysa arayüze ekler
                if (_songs != null && _songs.Count > 0)
                {
                    lst_songs.Items.Clear(); // Önce listeyi temizle
                    foreach (var s in _songs)
                    {
                        lst_songs.Items.Add(s); // ListBox'a ekle (Song.ToString() metodunu kullanır)
                    }
                }
            }
            catch (HttpRequestException)
            {
                // İnternet yok veya dosya henüz yüklenmemiş olabilir
                MessageBox.Show("Şarkı listesi GitHub'dan çekilemedi.\nLütfen 'songs.json' dosyasının GitHub'a yüklendiğinden emin olun.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şarkılar yüklenirken hata oluştu: {ex.Message}");
            }
        } // End LoadSongsFromGitHub

        /// <summary>
        /// Şarkı bitince otomatik olarak sonrakine geçer.
        /// </summary>
        private void OnMusicPlaybackStopped(object sender, EventArgs e)
        {
            // Thread çakışmasını önlemek için UI thread üzerinde çalıştır
            this.Invoke(new Action(() => 
            {
                // Sanki Sonraki Şarkı butonuna basılmış gibi davran
                btn_next_song_Click(sender, e);
            }));
        }

        /// <summary>
        /// Listeden bir şarkı seçildiğinde tetiklenir.
        /// </summary>
        private void Lst_songs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen öğeyi 'Song' tipine dönüştürür
            if (lst_songs.SelectedItem is Song selectedSong)
            {
                _currentSong = selectedSong;
                // Başlık etiketini günceller: Sanatçı - Şarkı Adı
                lbl_title.Text = $"{selectedSong.Artist} - {selectedSong.Title}";
                
                // Seçilince otomatik oynat
                PlaySong(_currentSong);
            }
        }

        /// <summary>
        /// Belirtilen şarkıyı oynatır.
        /// </summary>
        /// <param name="song">Oynatılacak şarkı nesnesi.</param>
        private void PlaySong(Song song)
        {
            // Şarkı geçerliyse ve URL'si boş değilse
            if (song != null && !string.IsNullOrEmpty(song.FileUrl))
            {
                _musicPlayer.Play(song.FileUrl);
                
                // Butonların görünürlüğünü ayarlar
                btn_play.Visible = false;   // Play butonunu gizle
                btn_resume.Visible = true;  // Pause butonunu göster
            }
        }

        #region Buton Olayları (Button Events)

        /// <summary>
        /// Uygulamayı kapatır.
        /// </summary>
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Uygulamayı simge durumuna küçültür.
        /// </summary>
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Uygulamayı tam ekran yapar veya eski haline getirir.
        /// </summary>
        private void btn_restore_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Admin senkronizasyon (JSON Oluşturma) butonuna tıklanınca çalışır.
        /// </summary>
        private async void btn_admin_sync_Click(object sender, EventArgs e)
        {
            // Admin araçlarını başlat
            var adminTools = new AdminTools();
            
            // JSON dosyasını oluştur
            int count = await adminTools.GeneratePlaylistJson();
            
            if (count > 0)
            {
                MessageBox.Show($"Başarılı! {count} şarkı bulundu ve 'songs.json' oluşturuldu.\n\nLÜTFEN DİKKAT:\nBu değişikliklerin çalışması için 'Songs' klasörünü (içindeki songs.json ile birlikte) GitHub'a PUSH etmelisiniz.");
                // Burada hemen yüklemiyoruz çünkü GitHub'a gitmesi lazım, 
                // ama yerel test için manuel JSON okuma eklenebilir. 
                // Şimdilik kullanıcı GitHub'a yükleyince görecek.
            }
        }

        /// <summary>
        /// Oynat (Play) butonuna tıklanınca çalışır.
        /// </summary>
        private void btn_play_Click(object sender, EventArgs e)
        {
            // Eğer seçili bir şarkı varsa devam ettir veya oynat
            if (_currentSong != null)
            {
                _musicPlayer.Play(_currentSong.FileUrl); 
                btn_play.Visible = false;
                btn_resume.Visible = true;
            }
            else
            {
                 // Hiçbir şey seçili değilse, listedeki ilk şarkıyı seçmeye çalış
                 if (lst_songs.Items.Count > 0)
                 {
                     lst_songs.SelectedIndex = 0;
                 }
            }
        }

        /// <summary>
        /// Duraklat (Pause) butonuna tıklanınca çalışır.
        /// </summary>
        private void btn_resume_Click(object sender, EventArgs e)
        {
            // Müziği duraklatır
            _musicPlayer.Pause();
            // Butonları değiştir
            btn_resume.Visible = false;
            btn_play.Visible = true;
        }

        /// <summary>
        /// Sonraki şarkı butonuna tıklanınca çalışır.
        /// </summary>
        private void btn_next_song_Click(object sender, EventArgs e)
        {
            if (lst_songs.Items.Count > 0)
            {
                int currentIndex = lst_songs.SelectedIndex;
                if (currentIndex < lst_songs.Items.Count - 1)
                {
                    lst_songs.SelectedIndex = currentIndex + 1;
                }
                else
                {
                    lst_songs.SelectedIndex = 0; // Başa dön
                }
            }
        }

        /// <summary>
        /// Önceki şarkı butonuna tıklanınca çalışır.
        /// </summary>
        private void btn_previous_song_Click(object sender, EventArgs e)
        {
            if (lst_songs.Items.Count > 0)
            {
                int currentIndex = lst_songs.SelectedIndex;
                if (currentIndex > 0)
                {
                    lst_songs.SelectedIndex = currentIndex - 1;
                }
                else
                {
                    lst_songs.SelectedIndex = lst_songs.Items.Count - 1; // Sona git
                }
            }
        }

        #endregion

        #region Panel Olayları

        /// <summary>
        /// Başlık çubuğuna basılı tutarak pencereyi sürüklemeyi sağlar.
        /// </summary>
        private void pnl_titlebar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        /// <summary>
        /// Ses çubuğu kaydırılınca ses seviyesini ayarlar.
        /// </summary>
        private void track_volume_Scroll(object sender, EventArgs e)
        {
            if (_musicPlayer != null)
            {
                _musicPlayer.SetVolume(track_volume.Value);
            }
        }
    }
}
