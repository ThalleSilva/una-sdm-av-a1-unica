namespace ValeAtivos324123036.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public double CapacidadeProcessamento { get; set; }
        public DateTime DataUltimaManutencao { get; set; }
        public bool EmOperacao { get; set; }
    }
}
