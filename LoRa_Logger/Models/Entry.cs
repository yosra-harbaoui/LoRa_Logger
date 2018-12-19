using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LoRa_Logger.Models
{
    public sealed class Entry
    {
        private string time;

        public Entry()
        {
            Measures = new List<Measure>();
        }

        //public Floor Floor { get; set; }
        public string Floor { get; set; }
        public int Number { get; set; }
        public int UL1 { get; set; }
        public int UL2 { get; set; }
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = DateTime.Parse(value).ToString();
            }
        }

        [Browsable(false)]
        public List<Measure> Measures { get; set; }
        
        public override string ToString()
        {
            return "Entry: " + Floor + " " + Number + " " + UL1 + " " + UL2 + " " + Time;
        }
    }
}