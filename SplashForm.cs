using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KaanerMusic
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Elements", "logo.png");
            if (!File.Exists(logoPath))
            {
                logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\", "Elements", "logo.png");
            }

            if (File.Exists(logoPath))
            {
                using (Bitmap originalBitmap = new Bitmap(logoPath))
                {
                    int maxWidth = 500;
                    int maxHeight = 500;
                    double ratioX = (double)maxWidth / originalBitmap.Width;
                    double ratioY = (double)maxHeight / originalBitmap.Height;
                    double ratio = Math.Min(ratioX, ratioY);

                    int newWidth = (int)(originalBitmap.Width * ratio);
                    int newHeight = (int)(originalBitmap.Height * ratio);

                    Size targetSize = new Size(newWidth, newHeight);
                    using (Bitmap resizedBitmap = new Bitmap(originalBitmap, targetSize))
                    {
                        this.Size = targetSize;
                        
                        SelectBitmap(resizedBitmap);
                    }
                }
            }
        }

        private void timer_splash_Tick(object sender, EventArgs e)
        {
            timer_splash.Stop();
            this.Close();
        }


        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cp;
            }
        }

        private void SelectBitmap(Bitmap bitmap)
        {
            IntPtr screenDc = GetDC(IntPtr.Zero);
            IntPtr memDc = CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  
                oldBitmap = SelectObject(memDc, hBitmap);

                Size size = bitmap.Size;
                Point pointSource = new Point(0, 0);
                
                Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
                Point topPos = new Point(
                    (screenBounds.Width - size.Width) / 2,
                    (screenBounds.Height - size.Height) / 2
                );

                BLENDFUNCTION blend = new BLENDFUNCTION();
                blend.BlendOp = AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = 255;
                blend.AlphaFormat = AC_SRC_ALPHA;

                UpdateLayeredWindow(this.Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, ULW_ALPHA);
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    SelectObject(memDc, oldBitmap);
                    DeleteObject(hBitmap);
                }
                DeleteDC(memDc);
            }
        }



        #region WinAPI
        public const byte AC_SRC_OVER = 0x00;
        public const byte AC_SRC_ALPHA = 0x01;
        public const int ULW_ALPHA = 0x00000002;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject", SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC", SetLastError = true)]
        public static extern bool DeleteDC(IntPtr hDC);
        #endregion
    }
}
