using System.Collections.Generic;

namespace LoRa_Logger.Models
{
    /// <summary>
    /// Class that represents a vector of measure
    /// </summary>
    public sealed class Vector
    {
        public string Floor { get; set; }
        public int Number { get; set; }
        public List<Gateway> Gateways { get; set; }

        public Vector()
        {
            Gateways = new List<Gateway>();
        }

        public Vector(string floor, int number) : this()
        {
            Floor = floor;
            Number = number;
        }
    }
}