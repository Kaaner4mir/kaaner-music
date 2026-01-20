using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using NAudio.Wave;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KaanerMusic
{
    public partial class main_form : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        ToolTip _toolTip = new ToolTip();
        
        // Firebase conf
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "ba8CuMlIlcVL70L0L9LR0Q4Z2aGSO4GUQUKiML0R", // Replace with your actual secret
            BasePath = "https://kaaner-music-default-rtdb.firebaseio.com/"       
        };
        IFirebaseClient client;

        // Logic
        private MusicPlayer _musicPlayer;
        private List<Song> _songs;
        private Song _currentSong;

        public main_form()
        {
            InitializeComponent();
            _toolTip.InitialDelay = 1000;

            #region Tooltips

            _toolTip.SetToolTip(btn_play, "Play");
            _toolTip.SetToolTip(btn_resume, "Pause"); // Changed description to match logic
            _toolTip.SetToolTip(btn_previous_song, "Play the previous song");
            _toolTip.SetToolTip(btn_next_song, "Play the next song");

            #endregion

            // Initialize Logic
            _musicPlayer = new MusicPlayer();
            client = new FireSharp.FirebaseClient(config);

            // Bind Events
            lst_songs.SelectedIndexChanged += Lst_songs_SelectedIndexChanged;

            // Load Data
            LoadSongs();
        }

        private async void LoadSongs()
        {
            if (client == null)
            {
                MessageBox.Show("Firebase connection failed.");
                return;
            }

            try
            {
                FirebaseResponse response = await client.GetAsync("Songs"); // Assuming 'Songs' node
                if (response.Body != "null")
                {
                    try
                    {
                        // Firebase integer keys often return an array [null, song1, song2]
                        var songList = response.ResultAs<List<Song>>();
                        if (songList != null)
                        {
                            _songs = songList.Where(s => s != null).ToList();
                        }
                    }
                    catch
                    {
                        // If List fails, try Dictionary
                        var songsDict = response.ResultAs<Dictionary<string, Song>>();
                        if (songsDict != null)
                        {
                            _songs = new List<Song>(songsDict.Values);
                        }
                    }

                    if (_songs != null)
                    {
                        lst_songs.Items.Clear();
                        foreach (var s in _songs)
                        {
                            lst_songs.Items.Add(s); // Uses Song.ToString()
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading songs: {ex.Message}");
            }
        }

        private void Lst_songs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_songs.SelectedItem is Song selectedSong)
            {
                _currentSong = selectedSong;
                lbl_title.Text = $"{selectedSong.Artist} - {selectedSong.Title}";
                
                // Auto-play when selected
                PlaySong(_currentSong);
            }
        }

        private void PlaySong(Song song)
        {
            if (song != null && !string.IsNullOrEmpty(song.FileUrl))
            {
                _musicPlayer.Play(song.FileUrl);
                // Update UI state
                btn_play.Visible = false;
                btn_resume.Visible = true;
            }
        }

        #region Buttons events

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private async void btn_admin_sync_Click(object sender, EventArgs e)
        {
            var adminTools = new AdminTools(client);
            int count = await adminTools.SyncSongsToFirebase();
            if (count > 0)
            {
                MessageBox.Show($"Successfully synced {count} songs to DB!");
                // Reload list
                LoadSongs();
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            // Resume or Play current
            if (_currentSong != null)
            {
                _musicPlayer.Play(_currentSong.FileUrl); // Logic in MusicPlayer handles resume if paused
                btn_play.Visible = false;
                btn_resume.Visible = true;
            }
            else
            {
                 // If nothing selected, maybe select first?
                 if (lst_songs.Items.Count > 0)
                 {
                     lst_songs.SelectedIndex = 0;
                 }
            }
        }

        private void btn_resume_Click(object sender, EventArgs e)
        {
            // Using this as Pause button based on toggle logic
            _musicPlayer.Pause();
            btn_resume.Visible = false;
            btn_play.Visible = true;
        }

        #endregion

        #region Panel events

        private void pnl_titlebar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        private void track_volume_Scroll(object sender, EventArgs e)
        {
            if (_musicPlayer != null)
            {
                _musicPlayer.SetVolume(track_volume.Value);
            }
        }
    }
}
