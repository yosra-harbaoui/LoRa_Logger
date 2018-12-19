using System.Collections.Generic;

namespace LoRa_Logger.Models
{
    public sealed class Formula
    {
        public string Floor { get; set; }
        public int Number { get; set; }
        public List<double> Distances { get; set; }

        public Formula()
        {
            Distances = new List<double>();
        }

        public Formula(string floor, int number) : this()
        {
            Floor = floor;
            Number = number;
        }
    }
}