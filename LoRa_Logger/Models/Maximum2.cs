namespace LoRa_Logger.Models
{
    public sealed class Maximum2
    {
        public string Floor { get; set; }
        public int Number { get; set; }
        public double MaxDistance { get; set; }

        public Maximum2(string floor, int number, double maxDistance)
        {
            Floor = floor;
            Number = number;
            MaxDistance = maxDistance;
        }
    }
}
