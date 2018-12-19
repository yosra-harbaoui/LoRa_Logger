namespace LoRa_Logger.Models
{
    public sealed class Maximum
    {
        public int Number { get; set; }
        public int Rssi { get; set; }

        public Maximum(int number, int rssi)
        {
            Number = number;
            Rssi = rssi;
        }
    }
}
