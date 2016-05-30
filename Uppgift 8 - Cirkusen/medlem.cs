using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_8___Cirkusen
{
    public class medlem
    {
        public int medlemsid { get; set; }
        public string förnamn { get; set; }
        public string efternamn { get; set; }

        public string NamnDisplay
        {
            get
            {
                return medlemsid + " - " + förnamn + " " + efternamn;
            }
        }
    }
}
