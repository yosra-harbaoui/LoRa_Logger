namespace LoRa_Logger.Models
{
    /// <summary>
    /// Class that represents a floor of the school
    /// </summary>
    public sealed class Floor
    {
        public string Name { get; set; }

        public Floor(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}