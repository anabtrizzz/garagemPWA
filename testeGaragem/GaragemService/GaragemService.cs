using testeGaragem.Models;

namespace testeGaragem.Services
{
    public class GaragemService
    {
        private List<Cliente> _clientes = new();
        private List<Veiculo> _veiculos = new();
        private List<Peca> _pecas = new();
        private List<OrdemServico> _ordens = new();

        public GaragemService()
        {
            SeedData();
        }

        private void SeedData()
        {
            // 1. Criando Clientes
            var c1 = new Cliente { Id = 1, Nome = "Ricardo Almeida", Telefone = "(11) 98765-4321", Tipo = "Premium" };
            var c2 = new Cliente { Id = 2, Nome = "Fernanda Costa", Telefone = "(11) 91234-5678", Tipo = "Padrão" };
            _clientes.Add(c1);
            _clientes.Add(c2);

            // 2. Criando Veículos e associando aos clientes
            _veiculos.Add(new Veiculo
            {
                Id = 1,
                MarcaModelo = "VW Golf GTI 2021",
                Placa = "BRA2E19",
                ClienteId = 1,
                Proprietario = c1
            });

            _veiculos.Add(new Veiculo
            {
                Id = 2,
                MarcaModelo = "Toyota Hilux SRX",
                Placa = "PLK4J22",
                ClienteId = 2,
                Proprietario = c2
            });

            // 3. Peças
            _pecas.Add(new Peca { Id = 1, Nota = "FR-4022", Nome = "Disco de Freio", QuantidadeEstoque = 24 });
        }

        // --- MÉTODOS DE CLIENTES ---
        public List<Cliente> GetClientes() => _clientes;
        public void AdicionarCliente(Cliente novo)
        {
            novo.Id = _clientes.Count + 1;
            _clientes.Add(novo);
        }

        public void AtualizarCliente(Cliente clienteEditado)
        {
            var index = _clientes.FindIndex(c => c.Id == clienteEditado.Id);
            if (index != -1)
            {
                _clientes[index] = clienteEditado;
            }
        }

        public void ExcluirCliente(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }


        // --- MÉTODOS DE VEÍCULOS ---
        public List<Veiculo> GetVeiculos() => _veiculos;

        public void AdicionarVeiculo(Veiculo novo)
        {
            novo.Id = _veiculos.Count + 1;

            // Tenta encontrar o dono na lista de clientes para manter o vínculo
            if (novo.Proprietario == null && novo.ClienteId != 0)
            {
                novo.Proprietario = _clientes.FirstOrDefault(c => c.Id == novo.ClienteId);
            }

            _veiculos.Add(novo);
        }

        public void AtualizarVeiculo(Veiculo veiculoEditado)
        {
            var index = _veiculos.FindIndex(v => v.Id == veiculoEditado.Id);
            if (index != -1)
            {
                // Reatribui o proprietário caso o ClienteId tenha mudado
                veiculoEditado.Proprietario = _clientes.FirstOrDefault(c => c.Id == veiculoEditado.Id);
                _veiculos[index] = veiculoEditado;
            }
        }

        public void ExcluirVeiculo(int id) => _veiculos.RemoveAll(v => v.Id == id);


        // --- ADICIONE AO GARAGEMSERVICE.CS ---

        public List<Peca> GetPecas() => _pecas;

        public void AdicionarPeca(Peca nova)
        {
            nova.Id = _pecas.Count + 1;
            _pecas.Add(nova);
        }

        public void AtualizarPeca(Peca pecaEditada)
        {
            var index = _pecas.FindIndex(p => p.Id == pecaEditada.Id);
            if (index != -1) _pecas[index] = pecaEditada;
        }

        public void ExcluirPeca(int id) => _pecas.RemoveAll(p => p.Id == id);


        public List<OrdemServico> GetOrdensServico() => _ordens;

        public void AdicionarOS(OrdemServico nova)
        {
            nova.Id = _ordens.Count + 1;

            // Fazemos a conta fora da string
            int numeroCalculado = 4580 + nova.Id;
            nova.NumeroOS = "#" + numeroCalculado.ToString();

            nova.DataEntrada = DateTime.Now;

            // Vincula os objetos completos para exibição
            nova.Veiculo = _veiculos.FirstOrDefault(v => v.Id == nova.VeiculoId);
            nova.Cliente = _clientes.FirstOrDefault(c => c.Id == nova.ClienteId);

            _ordens.Add(nova);
        }

        public void AtualizarStatus(int osId, string novoStatus)
        {
            var os = _ordens.FirstOrDefault(o => o.Id == osId);
            if (os != null)
            {
                os.Status = novoStatus;
            }
        }

        public DashboardData GetDashboardStats()
        {
            var ordens = GetOrdensServico();

            var stats = new DashboardData
            {
                TotalFaturado = ordens.Where(o => o.Status == "Finalizada").Sum(o => o.ValorTotal),
                QuantidadeOS = ordens.Count,
                StatusContagem = new List<StatusInfo>()
            };

            // Lista de todos os status possíveis para o gráfico
            var statusParaExibir = new[] {
            new { Nome = "Abertas", Chave = "Aberta", Cor = "yellow" },
            new { Nome = "Em Progresso", Chave = "Em Progresso", Cor = "blue" },
            new { Nome = "Finalizadas", Chave = "Finalizada", Cor = "green" },
            new { Nome = "Canceladas", Chave = "Cancelada", Cor = "red" }
            };

            foreach (var s in statusParaExibir)
            {
                stats.StatusContagem.Add(new StatusInfo
                {
                    Nome = s.Nome,
                    Quantidade = ordens.Count(o => o.Status == s.Chave),
                    Cor = s.Cor
                });
            }

            return stats;
        }




    }




}