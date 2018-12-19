namespace LoRa_Logger.Models
{
    /// <summary>
    /// Class that represents a vector of measure
    /// </summary>
    public sealed class Gateway
    {
        public string Name { get; set; }
        public string Eui { get; set; }
        public int Rssi { get; set; }

        public Gateway(string name, string eui)
        {
            Name = name;
            Eui = eui;
            Rssi = -999;
        }
    }
}