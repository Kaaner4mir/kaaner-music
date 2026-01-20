using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace KaanerMusic
{
    /// <summary>
    /// Main Form class. Manages the user interface and core logic of the application.
    /// </summary>
    public partial class main_form : Form
    {
        // Windows API constants required for dragging borderless forms
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        /// <summary>
        /// API call to process Windows messages.
        /// </summary>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// API call to release mouse capture.
        /// </summary>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Tooltip object
        ToolTip _toolTip = new ToolTip();
        
        private MusicPlayer _musicPlayer;
        
        private List<Song> _songs;
        
        private Song _currentSong;

        // HTTP client to fetch data from GitHub
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Constructor method of the form.
        /// </summary>
        public main_form()
        {
            InitializeComponent();
            _toolTip.InitialDelay = 1000;

            #region Tooltips
            _toolTip.SetToolTip(btn_play, "Play");
            _toolTip.SetToolTip(btn_resume, "Pause");
            _toolTip.SetToolTip(btn_previous_song, "Previous Song");
            _toolTip.SetToolTip(btn_next_song, "Next Song");
            _toolTip.SetToolTip(btn_sort_artist, "Sort by Artist");
            _toolTip.SetToolTip(btn_sort_title, "Sort by Song Title");
            #endregion

            _musicPlayer = new MusicPlayer();
            _musicPlayer.PlaybackStopped += OnMusicPlaybackStopped;

            lst_songs.SelectedIndexChanged += Lst_songs_SelectedIndexChanged;

            LoadSongsFromGitHub();
        }

        /// <summary>
        /// Fetches 'songs.json' from GitHub and populates the list.
        /// </summary>
        private async void LoadSongsFromGitHub()
        {
            try
            {
                string songsJsonUrl = "https://raw.githubusercontent.com/Kaaner4mir/kaaner-music/main/Songs/songs.json";
                
                string urlWithNoCache = $"{songsJsonUrl}?t={DateTime.Now.Ticks}";

                string jsonContent = await _httpClient.GetStringAsync(urlWithNoCache);
                
                _songs = JsonConvert.DeserializeObject<List<Song>>(jsonContent);

                if (_songs != null && _songs.Count > 0)
                {
                    lst_songs.Items.Clear();
                    foreach (var s in _songs)
                    {
                        lst_songs.Items.Add(s);
                    }
                }
            }
            catch (HttpRequestException)
            {
                // No internet or file not uploaded yet
                MessageBox.Show("Could not fetch song list from GitHub.\nPlease ensure 'songs.json' is uploaded to GitHub.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading songs: {ex.Message}");
            }
        } // End LoadSongsFromGitHub

        /// <summary>
        /// Automatically plays the next song when current finishes.
        /// </summary>
        private void OnMusicPlaybackStopped(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => 
            {
                btn_next_song_Click(sender, e);
            }));
        }

        /// <summary>
        /// Triggered when a song is selected from the list.
        /// </summary>
        private void Lst_songs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_songs.SelectedItem is Song selectedSong)
            {
                _currentSong = selectedSong;
                lbl_title.Text = $"{selectedSong.Artist} - {selectedSong.Title}";
                
                PlaySong(_currentSong);
            }
        }

        /// <summary>
        /// Plays the specified song.
        /// </summary>
        /// <param name="song">Song object to play.</param>
        private void PlaySong(Song song)
        {
            if (song != null && !string.IsNullOrEmpty(song.FileUrl))
            {
                _musicPlayer.Play(song.FileUrl);
                timer_progress.Start();
                
                if (!string.IsNullOrEmpty(song.ImageUrl))
                {
                    pic_album_art.LoadAsync(song.ImageUrl);
                }
                else
                {
                   pic_album_art.Image = null;
                }
                
                btn_play.Visible = false;
                btn_resume.Visible = true;
            }
        }

        #region Button Events

        /// <summary>
        /// Closes the application.
        /// </summary>
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Minimizes the application to taskbar.
        /// </summary>
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Toggles between maximize and restore.
        /// </summary>
        private void btn_restore_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }



        /// <summary>
        /// Code for Play button.
        /// </summary>
        private void btn_play_Click(object sender, EventArgs e)
        {
            if (_currentSong != null)
            {
                _musicPlayer.Play(_currentSong.FileUrl);
                timer_progress.Start();

                btn_play.Visible = false;
                btn_resume.Visible = true;
            }
            else
            {
                 if (lst_songs.Items.Count > 0)
                 {
                     lst_songs.SelectedIndex = 0;
                 }
            }
        }

        /// <summary>
        /// Code for Pause button.
        /// </summary>
        private void btn_resume_Click(object sender, EventArgs e)
        {
            _musicPlayer.Pause();
            timer_progress.Stop();
            
            btn_resume.Visible = false;
            btn_play.Visible = true;
        }

        #region Progress Bar Logic

        private bool _isDraggingProgress = false;

        private void timer_progress_Tick(object sender, EventArgs e)
        {
            if (!_isDraggingProgress && _musicPlayer != null)
            {
                double current = _musicPlayer.GetCurrentPosition();
                double total = _musicPlayer.GetDuration();

                if (total > 0)
                {
                    track_progress.Maximum = (int)total;
                    
                    if (current <= total)
                        track_progress.Value = (int)current;
                }
            }
        }

        private void track_progress_Scroll(object sender, EventArgs e)
        {
            // Could update time label while scrolling if exists
        }

        private void track_progress_MouseDown(object sender, MouseEventArgs e)
        {
            _isDraggingProgress = true;
            
            // Click to Seek
            double dblValue = ((double)e.X / (double)track_progress.Width) * (track_progress.Maximum - track_progress.Minimum);
            int newValue = (int)dblValue;

            if (newValue >= track_progress.Minimum && newValue <= track_progress.Maximum)
            {
                track_progress.Value = newValue;
            }
        }

        private void track_progress_MouseUp(object sender, MouseEventArgs e)
        {
            _isDraggingProgress = false;
            
            if (_musicPlayer != null)
            {
                _musicPlayer.SetPosition(track_progress.Value);
            }
        }

        private void btn_sort_artist_Click(object sender, EventArgs e)
        {
            if (_songs != null && _songs.Count > 0)
            {
                _songs = _songs.OrderBy(s => s.Artist).ToList();
                RefreshSongList();
            }
        }

        private void btn_sort_title_Click(object sender, EventArgs e)
        {
            if (_songs != null && _songs.Count > 0)
            {
                _songs = _songs.OrderBy(s => s.Title).ToList();
                RefreshSongList();
            }
        }

        private void RefreshSongList()
        {
            lst_songs.Items.Clear();
            foreach (var s in _songs)
            {
                lst_songs.Items.Add(s);
            }
        }

        #endregion

        /// <summary>
        /// Code for Next Song button.
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
                    lst_songs.SelectedIndex = 0; // Loop back to start
                }
            }
        }

        /// <summary>
        /// Code for Previous Song button.
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
                    lst_songs.SelectedIndex = lst_songs.Items.Count - 1; // Go to end
                }
            }
        }

        #endregion

        #region Panel Events

        /// <summary>
        /// Allows dragging the window by holding the title bar.
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
        /// Adjusts volume when volume bar is scrolled.
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
