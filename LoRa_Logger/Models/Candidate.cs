namespace LoRa_Logger.Models
{
    public sealed class Candidate
    {
        public string Floor { get; set; }
        public int Number { get; set; }
        public double Result { get; set; }

        public Candidate(string floor, int number, double result)
        {
            Floor = floor;
            Number = number;
            Result = result;
        }
    }
}