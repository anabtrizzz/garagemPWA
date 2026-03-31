namespace testeGaragem.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string MarcaModelo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public int Ano { get; set; }

        // Relacionamento: Um veículo pertence a um cliente
        public int ClienteId { get; set; }
        public Cliente? Proprietario { get; set; }
    }
}