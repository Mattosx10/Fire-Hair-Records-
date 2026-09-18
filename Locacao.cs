using System;

namespace FireHair_Records
{
    internal class Locacao
    {

        private int id;
        private Cliente cliente;
        private Album album;
        private DateTime dataLocacao;
        private DateTime dataPrevistaDevolucao;
        private DateTime dataDevolucao;
        private Decimal ValorLocacao;
        private Decimal ValorMulta;
        private String statusLocacao;
        private bool aluguelPago;
        private bool multaPaga;

        public Locacao(int id, Cliente cliente, Album album)
        {
            this.id = id;
            this.cliente = cliente;
            this.album = album;
            this.dataLocacao = DateTime.Now;
            this.dataPrevistaDevolucao = this.dataLocacao.AddDays(7);
            this.ValorLocacao = GetValorLocacao();
            this.statusLocacao = "Ativa";
            this.aluguelPago = false;
            this.multaPaga = false;
        }
        public int GetId()
        {
            return this.id;
        }
        public Cliente GetCliente()
        {
            return this.cliente;
        }
        public DateTime GetDataDevolucao()
        {
            return this.dataDevolucao;
        }
        public DateTime GetDataLocacao()
        {
            return this.dataLocacao;
        }
        public decimal GetValorLocacao()
        {
            int diferencaAno = DateTime.Now.Year - album.GetAnoLancamento();

            diferencaAno = diferencaAno / 6;
            int desconto = diferencaAno * 2;

            if (desconto >= 12)
            {

                return 20.00m - 12.00m;

            }
            else
            {
                return 20.00m - desconto;
            }
        }
        public Album GetAlbum()
        {
            return this.album;
        }
        public void DevolverAlbum()
        {
            if (this.statusLocacao == "Ativa")
            {
                Console.Write("\n - Insira a data de devolução: ");
                this.dataDevolucao = Convert.ToDateTime(Console.ReadLine());

                if (this.dataDevolucao <= this.dataPrevistaDevolucao)
                {

                    Console.WriteLine($"\n - Álbum '{album.GetNome()}' devolvido dentro da data prevista. Sem multa.");
                    this.statusLocacao = "Finalizada";
                    Console.WriteLine($"\n - Álbum '{album.GetNome()}' devolvido com sucesso.");
                    Console.WriteLine($"\n - Quantidade em estoque: {album.GetQtdEstoque()}");

                }
                else
                {
                    TimeSpan atraso = this.dataDevolucao - this.dataPrevistaDevolucao;
                    int diasAtraso = atraso.Days;
                    this.ValorMulta = (this.ValorLocacao * 0.10m) * diasAtraso;

                    Console.WriteLine($"\n - Álbum '{album.GetNome()}' devolvido com {diasAtraso} dias de atraso. Multa: {this.ValorMulta:C}");
                    Console.WriteLine($"\n - Quantidade em estoque: {album.GetQtdEstoque()}");


                    Console.Write("\n - A multa foi paga (s/n): ");
                    string respostaMulta = Console.ReadLine();
                    if (respostaMulta.ToLower() == "s")
                    {
                        this.multaPaga = true;
                        this.statusLocacao = "Finalizada";
                        Console.WriteLine($"\n - Multa paga com sucesso.");
                    }
                    else
                    {
                        this.multaPaga = false;
                        this.statusLocacao = "Pendente";
                        this.cliente.BloquearCliente();
                        Console.WriteLine($"\n - Cliente bloqueado por multa pendente.");
                    }
                    album.DevolverAlbum();
                }

            }
            else
            {
                Console.WriteLine($"\n - A locação do álbum '{album.GetNome()}' já foi finalizada.");
            }

        }

        public DateTime GetDataPrevistaDevolucao()
        {
            return this.dataPrevistaDevolucao;
        }
        public void PagarAluguel()
        {

            if (this.statusLocacao == "Ativa")
            {
                if (this.aluguelPago == false)
                {
                    Console.WriteLine($"\n - Valor do aluguel: {GetValorLocacao():C}");
                    Console.Write("\n - Deseja pagar o aluguel? (s/n): ");
                    string resposta = Console.ReadLine();
                    if (resposta.ToLower() == "s")
                    {

                        this.aluguelPago = true;
                        Console.WriteLine("\n - Aluguel pago com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("\n - Aluguel não pago.");
                    }
                }
                else
                {
                    Console.WriteLine("\n - O aluguel já foi pago.");
                }

            }
            else
            {
                Console.WriteLine($"\n - A locação do álbum '{album.GetNome()}' já foi finalizada.");
            }


        }
        public void PagarMulta()
        {
            if (this.statusLocacao == "Pendente")
            {
                if (this.multaPaga == false)
                {
                    decimal multa = GetValorMulta();
                    Console.WriteLine($"\n -Valor da multa: {multa:C}");
                    Console.Write("\n -Deseja pagar a multa? (s/n): ");
                    string resposta = Console.ReadLine();
                    if (resposta.ToLower() == "s")
                    {
                        this.multaPaga = true;
                        this.statusLocacao = "Finalizada";
                        Console.WriteLine("\n - Multa paga com sucesso.");
                        this.cliente.DesbloquearCliente();
                    }
                    else
                    {
                        Console.WriteLine("\n -Multa não paga. Cliente continua bloqueado.");
                    }
                }
                else
                {
                    Console.WriteLine("\n -A multa já foi paga.");
                }
            }
            else
            {
                Console.WriteLine($"\n - Cliente '{album.GetNome()}' não está pendente de multa.");
            }
        }
        public Decimal GetValorMulta()
        {

            TimeSpan atraso = this.dataDevolucao - this.dataPrevistaDevolucao;
            int diasAtraso = atraso.Days;
            this.ValorMulta = (this.ValorLocacao * 0.10m) * diasAtraso;

            return this.ValorMulta;
        }
        public string GetStatusLocacao()
        {
            return this.statusLocacao;

        }
        
        
    }
}
