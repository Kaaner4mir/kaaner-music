using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaanerMusic
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Önce Splash Screen'i göster
            Application.Run(new SplashForm());
            
            // Splash kapandıktan sonra Ana Form'u aç
            Application.Run(new main_form());
        }
    }
}
