using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_8___Cirkusen
{
    public class aktivitet
    {
        public int aktivitetsid { get; set; } 
        public int förnamn { get; set; }     // HÅLLER PÅ
        public string efternamn { get; set; }

        public string NamnDisplay
        {
            get
            {
                return aktivitetsid + " - " + förnamn + " " + efternamn;
            }
        }
    }
}
