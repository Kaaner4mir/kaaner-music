using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace KaanerMusic
{
    public class MusicPlayer
    {
        private WindowsMediaPlayer _player;

        public MusicPlayer()
        {
            _player = new WindowsMediaPlayer();
            // AutoStart true means it plays as soon as URL is set. 
            // We can control this effectively by setting URL then playing.
            _player.settings.autoStart = true; 
        }

        public void Play(string url)
        {
            // If the same URL is already loaded, just play
            if (_player.URL == url && _player.playState == WMPPlayState.wmppsPaused)
            {
                _player.controls.play();
                return;
            }

            _player.URL = url;
            // WMP auto-plays when URL is set if autoStart is true
        }

        public void Pause()
        {
            _player.controls.pause();
        }

        public void Stop()
        {
            _player.controls.stop();
        }

        public void SetVolume(int volume)
        {
            // Volume is 0-100
            _player.settings.volume = volume;
        }

        public double GetCurrentPosition()
        {
            return _player.controls.currentPosition;
        }

        public double GetDuration()
        {
            // Note: Duration might not be available immediately after setting URL
            return _player.currentMedia != null ? _player.currentMedia.duration : 0;
        }

        public string GetDurationString()
        {
            return _player.currentMedia != null ? _player.currentMedia.durationString : "00:00";
        }

        public void SetPosition(double position)
        {
            _player.controls.currentPosition = position;
        }
    }
}
