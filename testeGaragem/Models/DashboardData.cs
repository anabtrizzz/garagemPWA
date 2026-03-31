namespace testeGaragem.Models
{
    public class DashboardData
    {
        // O valor total de todas as O.S. somadas
        public decimal TotalFaturado { get; set; }

        // A contagem total de quantas O.S. existem no sistema
        public int QuantidadeOS { get; set; }

        // Uma lista que agrupa as informações de cada status (Aberta, Finalizada, etc.)
        // Isso é o que alimenta o @foreach no seu HTML
        public List<StatusInfo> StatusContagem { get; set; } = new List<StatusInfo>();
    }

    public class StatusInfo
    {
        // Nome do status (ex: "Aberta", "Em Progresso")
        public string Nome { get; set; } = string.Empty;

        // Quantidade de veículos com esse status
        public int Quantidade { get; set; }

        // A cor que será usada na barra de progresso (ex: "yellow", "green", "blue")
        public string Cor { get; set; } = "yellow";
    }
}
