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
        public int träningsgrupp { get; set; } 
        public string beskrivning { get; set; }
        public string datum { get; set; }
        public string klockslag { get; set; }
        public string plats { get; set; }
/*
        public string aktivitetDisplay
        {
            get
            {
                return aktivitetsid + " - " + förnamn + " " + efternamn;
            }
            
        }*/
    
    }
}
