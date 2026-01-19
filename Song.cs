using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaanerMusic
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string FileUrl { get; set; }

        // Helper to display in ListBox
        public override string ToString()
        {
            return $"{Artist} - {Title}";
        }
    }
}
