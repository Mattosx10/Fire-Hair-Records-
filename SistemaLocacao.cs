using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireHair_Records
{
    internal class SistemaLocacao
    {
        List<Locacao> locacoes;

        public SistemaLocacao()
        {
            locacoes = new List<Locacao>();
        }
        public void AdicionarLocacao(Locacao locacao)
        {
            locacoes.Add(locacao);
        }
        public bool VerificarLocacaoAtiva(Cliente cliente)
        {
            foreach (Locacao locacao in locacoes)
            {
                if (locacao.GetCliente() == cliente &&
                    locacao.GetStatusLocacao() == "Ativa")
                {
                    return true;
                }
            }

            return false;
        }
        public Locacao RealizarLocacao(Cliente cliente, Album album, int id)
        {

            if (cliente.GetVerificarBloqueio())
            {
                Console.WriteLine($"\n - Cliente '{cliente.GetNome()}' está bloqueado e não pode realizar locações.");
                return null;
            }
            else if (VerificarLocacaoAtiva(cliente))
            {
                Console.WriteLine($"\n - Cliente '{cliente.GetNome()}' já possui uma locação ativa.");
                return null;
            }
            else if(album.AlugarAlbum() == false)
            {
                return null;
            }

            Locacao locacao = new Locacao(id, cliente, album);
            AdicionarLocacao(locacao);
            return locacao;
        }

        public void ListarLocacoesCliente(Cliente cliente)
        {   bool encontrado = false;
            

            foreach (Locacao locacao in locacoes)
            {   if (locacao.GetCliente() == cliente) {
                    Console.WriteLine($"ID: {locacao.GetId()}, Cliente: {locacao.GetCliente().GetNome()}, Álbum: {locacao.GetAlbum().GetNome()}, Status: {locacao.GetStatusLocacao()}");
                    encontrado = true;
                }
            }
            if(!encontrado)
            {
                Console.WriteLine($"Nenhuma locação encontrada para o cliente '{cliente.GetNome()}'.");
            }
        }

        public void ListarLocacoesAtivas()
        {
            bool encontrado = false;
            foreach (Locacao locacao in locacoes)
            {
                if (locacao.GetStatusLocacao() == "Ativa")
                {
                    Console.WriteLine($"ID: {locacao.GetId()}, Cliente: {locacao.GetCliente().GetNome()}, Álbum: {locacao.GetAlbum().GetNome()}, Status: {locacao.GetStatusLocacao()}");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Nenhuma locação ativa encontrada.");
            }
        }
        public void ListarLocacoesPendentes()
        {
            bool encontrado = false;
            foreach (Locacao locacao in locacoes)
            {
                if (locacao.GetStatusLocacao() == "Pendente")
                {
                    Console.WriteLine($"ID: {locacao.GetId()}, Cliente: {locacao.GetCliente().GetNome()}, Álbum: {locacao.GetAlbum().GetNome()}, Status: {locacao.GetStatusLocacao()}");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Nenhuma locação pendente encontrada.");
            }
        }
        public Locacao BuscarLocacaoPorId(int id)
        {
            foreach (Locacao locacao in locacoes)
            {
                if (locacao.GetId() == id)
                {
                    return locacao;
                }
            }
            return null;
        }
        public void ConsultarDetalhesLocacao(int id)
        {
            Locacao locacao = BuscarLocacaoPorId(id);
            if (locacao != null)
            {
                Console.WriteLine($"ID: {locacao.GetId()}, Cliente: {locacao.GetCliente().GetNome()}, Álbum: {locacao.GetAlbum().GetNome()}, Status: {locacao.GetStatusLocacao()}");
                Console.WriteLine($"Data de Locação: {locacao.GetDataLocacao()}, Data Prevista de Devolução: {locacao.GetDataPrevistaDevolucao()}");
                if (locacao.GetStatusLocacao() == "Finalizada")
                {
                    Console.WriteLine($"Data de Devolução: {locacao.GetDataDevolucao()}");
                }
                else if(locacao.GetStatusLocacao() == "Pendente")
                {
                    Console.WriteLine($"Data de Devolução: {locacao.GetDataDevolucao()} ( Pagamento de multa pendente )");
                    Console.WriteLine($"Valor da Multa: {locacao.GetValorMulta()}");
                }
                Console.WriteLine($"Valor da Locação: {locacao.GetValorLocacao()}");
            }
            else
            {
                Console.WriteLine($"Nenhuma locação encontrada com o ID '{id}'.");
            }
        }
        public void DevolverLocacao(int id)
        {
            Locacao locacao = BuscarLocacaoPorId(id);

            if (locacao == null)
            {
                Console.WriteLine($"Nenhuma locação encontrada com o ID '{id}'.");
                return;
            }

            else if (locacao.GetStatusLocacao() == "Finalizada")
            {
                Console.WriteLine($"A locação com ID '{id}' já foi finalizada.");
                return;
            }
            
            locacao.DevolverAlbum();
            
        }
    }
}
