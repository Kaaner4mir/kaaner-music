using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
        

        public main_form()
        {
            InitializeComponent();
            _toolTip.InitialDelay = 1000;

            #region Tooltips

            _toolTip.SetToolTip(btn_play, "Play");
            _toolTip.SetToolTip(btn_resume, "Resume");
            _toolTip.SetToolTip(btn_previous_song, "Play the previous song");
            _toolTip.SetToolTip(btn_next_song, "Play the next song");

            #endregion
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

        private void btn_play_Click(object sender, EventArgs e)
        {
            btn_play.Visible = false;
            btn_resume.Visible = true;
        }

        private void btn_resume_Click(object sender, EventArgs e)
        {
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

    }
}
