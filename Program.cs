using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireHair_Records
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criar alguns álbuns de exemplo
            List<Album> albuns = CriarAlbuns();
            // Criar uma lista de clientes
            List<Cliente> clientes = new List<Cliente>();


            int opcao = -1;
            int idLocacao = 1;
            int idCliente = 0;


            SistemaLocacao Slocacao = new SistemaLocacao();



            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("=========================");
                Console.WriteLine("   FIRE HAIR - RECORDS   ");
                Console.WriteLine("=========================");
                Console.ResetColor();

                Console.WriteLine("\n~~~~~~~~~~ MENU ~~~~~~~~~~\n");
                Console.WriteLine("1 - Cadastrar cliente \r\n2 - Realizar locação\r\n3 - Devolver álbum\r\n4 - Pagar aluguel\r\n5 - Pagar multa\r\n6 - Listar locações do cliente\r\n7 - Listar locações ativas\r\n8 - Consultar detalhes da locação\r\n\n~~~~~~~~ 0 - SAIR ~~~~~~~~");



                Console.Write("\nDigite a opção desejada: ");
                opcao = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcao)
                {

                    case 1:
                        idCliente++;
                        CadastrarCliente(clientes, idCliente);
                        break;
                    case 2:
                        RealizarLocacao(Slocacao, clientes, albuns, ref idLocacao, ref idCliente);
                        break;
                    case 3:
                        int idLocacaoDevolver;

                        do {
                            Console.WriteLine("\nOpção 3 selecionada: Devolver álbum");
                            Console.Write("\n - Qual o ID da locação:  ");
                            idLocacaoDevolver = int.Parse(Console.ReadLine());

                            if (Slocacao.BuscarLocacaoPorId(idLocacaoDevolver) == null)
                            {
                                Console.WriteLine("\n - Locação não encontrada.");

                                Console.Write("\n - Deseja Tentar novamente? (s/n):");
                                string resposta = Console.ReadLine();
                                if (resposta.ToLower() != "s")
                                {
                                    break;
                                }
                            }
                            
                        } while (Slocacao.BuscarLocacaoPorId(idLocacaoDevolver) == null);

                        Slocacao.DevolverLocacao(idLocacaoDevolver);
                        break;
                    case 4:
                        Locacao locacaoEncontrada;

                        do {
                            Console.WriteLine("\nOpção 4 selecionada: Pagar aluguel");
                            Console.Write("\n - Qual o ID da locação: ");
                            int idLocacaoBusca = int.Parse(Console.ReadLine());
                            locacaoEncontrada = Slocacao.BuscarLocacaoPorId(idLocacaoBusca);

                            if (locacaoEncontrada == null)
                            {
                                Console.WriteLine("Locação não encontrada.");
                                Console.Write("\n - Deseja Tentar novamente? (s/n):");
                                string resposta = Console.ReadLine();
                                if (resposta.ToLower() != "s")
                                {
                                    break;
                                }
                            }

                        } while (locacaoEncontrada == null);

                        locacaoEncontrada.PagarAluguel();
                        break;
                    case 5:
                        Locacao locEncontrada;

                        do {
                            Console.WriteLine("\nOpção 5 selecionada: Pagar multa");
                            Console.Write("\n - Qual o ID da locação: ");
                            int idLocacaoMulta = int.Parse(Console.ReadLine());

                            locEncontrada = Slocacao.BuscarLocacaoPorId(idLocacaoMulta);

                            if (locEncontrada == null)
                            {
                                Console.WriteLine("Locação não encontrada.");
                                Console.Write("\n - Deseja Tentar novamente? (s/n):");
                                string resposta = Console.ReadLine();
                                if (resposta.ToLower() != "s")
                                {
                                    break;
                                }
                            }
                        }while(locEncontrada == null);

                        locEncontrada.PagarMulta();
                        break;
                    case 6:
                       ListarLocacoesCliente(Slocacao, clientes);
                        break;
                    case 7:
                        Console.WriteLine("\nOpção 7 selecionada: Listar locações ativas");
                        Slocacao.ListarLocacoesAtivas();
                        break;
                    case 8:
                        Locacao LocEncontrada;
                        int idLocBusca;

                        do {
                            Console.WriteLine("\nOpção 8 selecionada: Consultar detalhes da locação");
                            Console.Write("\n - Qual o ID da locação: ");
                            idLocBusca = int.Parse(Console.ReadLine());

                            LocEncontrada = Slocacao.BuscarLocacaoPorId(idLocBusca);

                            if(LocEncontrada == null)
                            {
                                Console.WriteLine("Locação não encontrada.");
                                Console.Write("\n - Deseja Tentar novamente? (s/n):");
                                string resposta = Console.ReadLine();
                                if (resposta.ToLower() != "s")
                                {
                                    break;
                                }
                            }

                        } while(LocEncontrada == null);

                        Slocacao.ConsultarDetalhesLocacao(idLocBusca);

                        break;
                    case 0:
                        Console.WriteLine("\nSaindo do programa...");
                        // Lógica para sair do programa
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, selecione uma opção válida.");
                        break;
                }

                Console.WriteLine("\n===== PRESSIONE UMA TECLA PARA CONTINUAR =====");
                Console.ReadKey();

                Console.Clear();

            } while (opcao != 0);
        }



        static List<Album> CriarAlbuns()
        {
            EstiloMusical rock = new EstiloMusical(1, "Rock");

            Album nevermind = new Album(
                1,
                "Nevermind",
                "Nirvana",
                1991,
                5,
                rock
            );

            Album darkSide = new Album(
                2,
                "The Dark Side of the Moon",
                "Pink Floyd",
                1973,
                3,
                rock
            );

            Album hybridTheory = new Album(
                3,
                "Hybrid Theory",
                "Linkin Park",
                2000,
                4,
                rock
            );

            List<Album> albuns = new List<Album>();

            albuns.Add(nevermind);
            albuns.Add(darkSide);
            albuns.Add(hybridTheory);

            return albuns;
        }
        static void CadastrarCliente(List<Cliente> clientes, int idCliente)
        {
            string nome;
            Console.WriteLine("\nOpção 1 selecionada: Cadastrar cliente");

            do {
                Console.Write("\n - Digite o nome do cliente: ");
                nome = Console.ReadLine();

                if (!Cliente.VerificarNome(nome))
                {
                    Console.WriteLine("\n - Nome inválido. O nome deve conter apenas letras e espaços.");
                }

            }while(Cliente.VerificarNome(nome) != true);

            string email;

            do {
                Console.Write("\n - Digite o email do cliente: ");
                email = Console.ReadLine();

                if (!Cliente.VerificarEmail(email))
                {
                    Console.WriteLine("\n - Email inválido. O email deve conter '@' e '.'");
                }

            }while(Cliente.VerificarEmail(email) != true);

            string telefone;

            do {
                Console.Write("\n - Digite o telefone do cliente: ");
                telefone = Console.ReadLine();

                if (!Cliente.VerificarTelefone(telefone))
                {
                    Console.WriteLine("\n - Telefone inválido. O telefone deve conter apenas números e ter no mínimo 10 dígitos.");
                }

            }while(Cliente.VerificarTelefone(telefone) != true);


            Console.Write("\n - Digite o endereço do cliente: ");
            string endereco = Console.ReadLine();

            Cliente cliente = new Cliente(idCliente, nome, telefone, email, endereco);
            clientes.Add(cliente);
            Console.WriteLine("\n - Cliente cadastrado com sucesso! O ID do cliente é: {0}", idCliente);


        }
        static void RealizarLocacao(SistemaLocacao Slocacao, List<Cliente> clientes, List<Album> albuns, ref int idLocacao, ref int idCliente)
        {
            Cliente clienteEncontrado = null;
            do {
                Console.WriteLine("\nOpção 2 selecionada: Realizar locação");
                Console.Write("\n - Qual o ID do cliente: ");
                string idClienteBuscaStr = Console.ReadLine();

                if (!int.TryParse(idClienteBuscaStr, out int idClienteBusca))
                {
                    Console.WriteLine("\n - ID inválido. Por favor, digite um número.");
                    continue;
                }

                // Verificar se o cliente existe na lista de clientes
                foreach (Cliente c in clientes)
                {
                    if (c.Getid() == idClienteBusca)
                    {
                        clienteEncontrado = c;
                        break;
                    }
                }

                if (clienteEncontrado == null)
                {
                    Console.WriteLine("\n - Cliente não encontrado. Por favor, cadastre o cliente antes de realizar a locação.");
                    Console.Write("\n - Deseja cadastrar um novo cliente? (s/n) : ");
                    string resposta = Console.ReadLine();
                    if (resposta.ToLower() == "s")
                    {
                        Console.Clear();
                        idCliente++;
                        CadastrarCliente(clientes,idCliente);
                        clienteEncontrado = clientes.Last();
                    }
                    else
                    {
                        Console.WriteLine("\n - Tente novamente.\n");
                    }
                }

            }while(clienteEncontrado == null);

            Console.WriteLine("\n - Álbuns disponíveis: \n");
            for (int i = 0; i < albuns.Count; i++)
            {
                Album album = albuns[i];
                Console.WriteLine($"\n {i + 1} - {album.GetNome()} - {album.GetArtista()} ({album.GetAnoLancamento()}) - Estoque: {album.GetQtdEstoque()}\n");
            }

            int opcaoAlbum;
            do
            {
                Console.Write($"\n - Qual álbum cliente deseja alugar:  ");
                string entrada = Console.ReadLine();

                if (!int.TryParse(entrada, out opcaoAlbum))
                {
                    Console.WriteLine("\n - Digite apenas números.");
                    continue;
                }

                if (opcaoAlbum < 1 || opcaoAlbum > albuns.Count)
                {
                    Console.WriteLine("\n - Opção inválida. Por favor, selecione um álbum válido.");
                    continue;
                } 

            }while(opcaoAlbum < 1 || opcaoAlbum > albuns.Count);

            Locacao loc = Slocacao.RealizarLocacao(clienteEncontrado, albuns[opcaoAlbum - 1], idLocacao);

            if(loc == null)
            {
                return;
            }

                Console.WriteLine($"\n - Locação realizada com sucesso! O id da locação é {idLocacao}");
                idLocacao++;
        }
        static void ListarLocacoesCliente(SistemaLocacao Slocacao, List<Cliente> clientes)
        {
            Console.WriteLine("\nOpção 6 selecionada: Listar locações do cliente");
            Cliente clienteEncontrado = null;

            do
            {
                Console.WriteLine("\nOpção 2 selecionada: Realizar locação");
                Console.Write("\n - Qual o ID do cliente: ");
                string idClienteBuscaStr = Console.ReadLine();

                if (!int.TryParse(idClienteBuscaStr, out int idClienteBusca))
                {
                    Console.WriteLine("\n - ID inválido. Por favor, digite um número.");
                    continue;
                }

                // Verificar se o cliente existe na lista de clientes
                foreach (Cliente c in clientes)
                {
                    if (c.Getid() == idClienteBusca)
                    {
                        clienteEncontrado = c;
                        break;
                    }
                }

                if (clienteEncontrado == null)
                {
                    Console.WriteLine("\n - Cliente não encontrado. Por favor, consulte o cadastro de clientes.");
                    return;
                }

            } while (clienteEncontrado == null);

            Slocacao.ListarLocacoesCliente(clienteEncontrado);
        }
    }
}
    

      