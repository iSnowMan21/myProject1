using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionAPIGUI
{
    internal class Film : Search
    {
        bool checkBox = false;

        public Film(bool checkBox, string title, string year, string imdbID, string type, string poster) : base(title, year, imdbID, type, poster)
        {
            this.checkBox = checkBox;
        }
    }
}
