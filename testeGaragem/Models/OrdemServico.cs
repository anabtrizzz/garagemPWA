namespace testeGaragem.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public string NumeroOS { get; set; } // Ex: 4582
        public DateTime DataEntrada { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Aberta"; // Aberta, Em Progresso, Finalizada
        public decimal ValorTotal { get; set; }
        public string DescricaoServico { get; set; } = "";
        public DateTime DataEntrega { get; set; } = DateTime.Now.AddDays(1);

        // Relacionamentos
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
