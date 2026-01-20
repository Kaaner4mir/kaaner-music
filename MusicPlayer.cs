using System;
using NAudio.Wave;

// Gereksiz using ifadeleri (System.Collections.Generic, Linq, Text, Threading.Tasks) kaldırıldı.

namespace KaanerMusic
{
    /// <summary>
    /// Müzik çalma işlemlerini yöneten sınıf.
    /// NAudio kütüphanesini kullanarak ses dosyalarını oynatır.
    /// </summary>
    public class MusicPlayer
    {
        // Ses çıkış cihazı (Hoparlör vs.)
        private IWavePlayer _outputDevice;
        
        // Ses dosyasını okuyan okuyucu (URL veya yerel dosya destekler)
        private MediaFoundationReader _audioFile;
        
        // Şu an çalınan şarkının URL'si (tekrar çalmayı önlemek veya devam etmek için)
        private string _currentUrl;

        /// <summary>
        /// Yapıcı metot (Constructor).
        /// </summary>
        public MusicPlayer()
        {
            // Başlangıç ayarları gerekirse buraya eklenebilir.
        }

        // Şarkı bittiğinde tetiklenecek olay
        public event EventHandler PlaybackStopped;

        /// <summary>
        /// Belirtilen URL'deki müzik dosyasını çalar.
        /// </summary>
        /// <param name="url">Çalınacak ses dosyasının adresi (Web URL veya Dosya Yolu).</param>
        public void Play(string url)
        {
            try 
            {
                // Eğer aynı şarkı duraklatılmışsa ve tekrar play denmişse, kaldığı yerden devam et.
                if (_currentUrl == url && _outputDevice != null && _outputDevice.PlaybackState == PlaybackState.Paused)
                {
                    _outputDevice.Play();
                    return;
                }

                // Yeni bir şarkıysa veya durmuşsa, önce mevcut olanı temizle
                Stop();

                _currentUrl = url;
                
                // Müzik dosyasını internetten veya diskten yükle
                _audioFile = new MediaFoundationReader(url);
                
                // Ses çıkış cihazını (Varsayılan ses kartı) oluştur
                var waveOut = new WaveOutEvent();
                waveOut.PlaybackStopped += OnPlaybackStopped;
                _outputDevice = waveOut;
                
                // Cihazı müzik dosyası ile başlat
                _outputDevice.Init(_audioFile);
                
                // Oynatmayı başlat
                _outputDevice.Play();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Oynatma hatası: {ex.Message}");
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            // Olayı dışarıya fırlat (Form1 yakalasın)
            PlaybackStopped?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Müziği duraklatır.
        /// </summary>
        public void Pause()
        {
            if (_outputDevice != null)
            {
                _outputDevice.Pause();
            }
        }

        /// <summary>
        /// Müziği tamamen durdurur ve kaynakları serbest bırakır.
        /// </summary>
        public void Stop()
        {
            // Ses cihazını durdur ve temizle
            if (_outputDevice != null)
            {
                // Önce olayı dinlemeyi bırak ki sonsuz döngüye girmesin
                if (_outputDevice is WaveOutEvent waveOut)
                {
                    waveOut.PlaybackStopped -= OnPlaybackStopped;
                }

                _outputDevice.Stop();
                _outputDevice.Dispose(); // Kaynakları işletim sistemine iade et
                _outputDevice = null;
            }
            // Ses dosyasını kapat ve temizle
            if (_audioFile != null)
            {
                _audioFile.Dispose();
                _audioFile = null;
            }
            _currentUrl = null;
        }

        /// <summary>
        /// Ses seviyesini ayarlar.
        /// </summary>
        /// <param name="volume">0 ile 100 arasında bir değer.</param>
        public void SetVolume(int volume)
        {
            // NAudio WaveOutEvent.Volume 0.0f ile 1.0f arasında değer alır.
            // Bu yüzden gelen 0-100 değerini 100'e bölüyoruz.
            if (_outputDevice is WaveOutEvent waveOut)
            {
                waveOut.Volume = volume / 100f;
            }
        }

        /// <summary>
        /// Şu anki çalma süresini saniye cinsinden döndürür.
        /// </summary>
        public double GetCurrentPosition()
        {
            return _audioFile != null ? _audioFile.CurrentTime.TotalSeconds : 0;
        }

        /// <summary>
        /// Şarkının toplam süresini saniye cinsinden döndürür.
        /// </summary>
        public double GetDuration()
        {
            return _audioFile != null ? _audioFile.TotalTime.TotalSeconds : 0;
        }

        /// <summary>
        /// Şarkı süresini "dk:sn" formatında metin olarak döndürür (Örn: 03:45).
        /// </summary>
        public string GetDurationString()
        {
            return _audioFile != null ? _audioFile.TotalTime.ToString(@"mm\:ss") : "00:00";
        }

        /// <summary>
        /// Şarkıyı belirli bir saniyeye sarar.
        /// </summary>
        /// <param name="position">Saniye cinsinden hedef pozisyon.</param>
        public void SetPosition(double position)
        {
            if (_audioFile != null)
            {
                // Pozisyonun toplam süreyi aşmamasını garantiye al
                if (position > _audioFile.TotalTime.TotalSeconds)
                {
                    position = _audioFile.TotalTime.TotalSeconds;
                }
                
                _audioFile.CurrentTime = TimeSpan.FromSeconds(position);
            }
        }
    }
}
