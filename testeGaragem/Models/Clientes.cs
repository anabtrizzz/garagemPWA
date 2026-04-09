namespace testeGaragem.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Tipo { get; set; } = "Padrão"; // Padrão, Premium
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
