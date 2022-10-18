namespace TecAlliance.Carpool.Business.Models
{
    public class Carpool
    {
        public string? Name { get; set; }
        public string? Nachname { get; set; }
        public string? Anmeldename { get; set; }
        public string? Gender { get; set; }
        public int Alter { get; set; }
        public string? AutoBezeichnung { get; set; }
        public int FreeSeat { get; set; }
        public bool Fahrers { get; set; }
        public string? WohnOrt { get; set; }
        public string? ZielOrt { get; set; }
        public DateTime Abfahrtzeit { get; set; }

    }
}
