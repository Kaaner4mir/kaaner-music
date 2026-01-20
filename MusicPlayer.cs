using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace KaanerMusic
{
    public class MusicPlayer
    {
        private IWavePlayer _outputDevice;
        private MediaFoundationReader _audioFile;
        private string _currentUrl;

        public MusicPlayer()
        {
            // Constructor
        }

        public void Play(string url)
        {
            try 
            {
                // If resuming same song
                if (_currentUrl == url && _outputDevice != null && _outputDevice.PlaybackState == PlaybackState.Paused)
                {
                    _outputDevice.Play();
                    return;
                }

                // If playing new song or stopped
                Stop();

                _currentUrl = url;
                _audioFile = new MediaFoundationReader(url);
                _outputDevice = new WaveOutEvent();
                _outputDevice.Init(_audioFile);
                _outputDevice.Play();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Playback error: {ex.Message}");
            }
        }

        public void Pause()
        {
            if (_outputDevice != null)
            {
                _outputDevice.Pause();
            }
        }

        public void Stop()
        {
            if (_outputDevice != null)
            {
                _outputDevice.Stop();
                _outputDevice.Dispose();
                _outputDevice = null;
            }
            if (_audioFile != null)
            {
                _audioFile.Dispose();
                _audioFile = null;
            }
            _currentUrl = null;
        }

        public void SetVolume(int volume)
        {
            // WMP used 0-100, NAudio WaveOutEvent.Volume is 0.0-1.0
            // Note: WaveOutEvent.Volume is obsolete in some versions but still properties on AudioFileReader exist.
            // With MediaFoundationReader, we don't have direct Volume property easily accessible 
            // without wrapping in a sample provider, but `WaveOutEvent.Volume` works on the device level for some APIs.
            
            if (_outputDevice is WaveOutEvent waveOut)
            {
                waveOut.Volume = volume / 100f;
            }
        }

        public double GetCurrentPosition()
        {
            return _audioFile != null ? _audioFile.CurrentTime.TotalSeconds : 0;
        }

        public double GetDuration()
        {
            return _audioFile != null ? _audioFile.TotalTime.TotalSeconds : 0;
        }

        public string GetDurationString()
        {
            return _audioFile != null ? _audioFile.TotalTime.ToString(@"mm\:ss") : "00:00";
        }

        public void SetPosition(double position)
        {
            if (_audioFile != null)
            {
                _audioFile.CurrentTime = TimeSpan.FromSeconds(position);
            }
        }
    }
}
