namespace testeGaragem.Models
{
    public class Peca
    {
        public int Id { get; set; }
        public string Nota { get; set; } = string.Empty; // Código ex: MT-55-SYNT
        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal PrecoVenda { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int EstoqueMinimo { get; set; } = 5;

        // Propriedade calculada para o visual da barra de progresso
        public double PorcentagemEstoque => QuantidadeEstoque > 50 ? 100 : (QuantidadeEstoque / 50.0) * 100;
    }
}