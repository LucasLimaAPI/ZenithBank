using ZENITHBANK.Conta;
using ZENITHBANK.zenithbank.Exceptions;

namespace ZenithBank.zenithbank.Atendimento;

internal class ZenithbankAtendimento
{
    #region     
#nullable disable
    #endregion
    private List<ContaCorrente> _listaDeContas = [
new(95,"123456-X"){Saldo= 150,Titular = new Cliente{Cpf= "123456789-10",Nome ="Wallace",Profissao="Analista"}},
    new(95,"954321-Z"){Saldo= 20000000,Titular = new Cliente{Cpf= "2291601287-77",Nome ="Lucas",Profissao="Dev"}},
    new(94,"578965-W"){Saldo= 15,Titular = new Cliente{Cpf= "2233445566-77",Nome ="Felipe",Profissao="Analista"}}
];

    public void AtendimentoCliente()
    {
        try
        {
            char opcao = 'O'; // char = ''
            while (opcao != '6')
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("===            ATENDIMENTO            ===");
                Console.WriteLine("===      .1 - CADASTRAR CONTA         ===");
                Console.WriteLine("====     .2 - LISTAR CONTAS           ===");
                Console.WriteLine("===      .3 - REMOVER CONTA           ===");
                Console.WriteLine("===      .4 - ORDENAR CONTAS          ===");
                Console.WriteLine("===      .5 - PESQUISAR CONTA         ===");
                Console.WriteLine("===      .6 - SAIR DO SISTEMA         ===");
                Console.WriteLine("-----------------------------------------");
                Console.Write("\n\n");
                Console.Write("Digite a opção desejada: ");

                try
                {
                    opcao = Console.ReadLine()[0];
                }
                catch (Exception excecao)
                {
                    throw new ZenithBankException(excecao.Message);
                }

                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarConta();
                        break;
                    case '3':
                        RemoverContas();
                        break;
                    case '4':
                        OdernarContas();
                        break;
                    case '5':
                        PesquisarContas();
                        break;
                    case '6':
                        EncerrarApp();
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;
                }
            }
        }
        catch (ZenithBankException excecao)
        {

            Console.WriteLine($"{excecao.Message}");
        }


    }

    private void EncerrarApp()
    {
        System.Console.WriteLine("... Encerrando Aplicação ...");
        Console.ReadKey();
    }

    private void PesquisarContas()
    {
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine("===     PESQUISAR CONTAS     ===");
        Console.WriteLine("================================");
        Console.WriteLine("\n");
        Console.WriteLine("Deseja pesquisar por (1) N° DA CONTA ou (2) CPF TITULAR (3) N° DA AGÊNCIA? ");
        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                {
                    Console.WriteLine("Informe o número da Conta");
                    string _numeroConta = Console.ReadLine();
                    ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                    Console.WriteLine(consultaConta.ToString());
                    Console.ReadKey();
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Informe o CPF do Titular: ");
                    string _cpf = Console.ReadLine();
                    ContaCorrente ConsultaCpf = ConsultaPorCPFTitular(_cpf);
                    Console.WriteLine(ConsultaCpf.ToString());

                    Console.ReadKey();
                    break;

                }
            case 3:
                {
                    Console.WriteLine("Informe o N° da Agência: ");
                    int _numeroAgencia = int.Parse(Console.ReadLine());
                    var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                    ExibirListadeContas(contasPorAgencia);
                    Console.ReadKey();
                    break;

                }
            default:
                Console.WriteLine("Opção não implementada.");
                break;

        }
    }
    private ContaCorrente ConsultaPorNumeroConta(string numeroConta)
    {
        //Ao invés disso:

        // ContaCorrente? conta = null;
        // for (int i = 0; i < _listaDeContas.Count; i++)
        // {
        //     if (_listaDeContas[i].Conta.Equals(numeroConta))
        //     {
        //         conta = _listaDeContas[i];
        //     }
        // }
        // return conta;

        // Faça Isso:
        return _listaDeContas.Where(conta => conta.Titular.Cpf == numeroConta).FirstOrDefault(); // metodo de extenção extende da classe linQ. 
    }

    private ContaCorrente ConsultaPorCPFTitular(string cpf)
    {
        //Ao invés disso:

        // ContaCorrente conta = null;
        // for (int i = 0; i < _listaDeContas.Count; i++)
        // {
        //     if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
        //     {
        //         conta = _listaDeContas[i];
        //     }
        // }
        // return conta;

        // Faça Isso:
        return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault(); // metodo de extenção extende da classe link. 

    }

    private List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
    {
        var consulta = (
                             from conta in _listaDeContas
                             where conta.Numero_agencia == numeroAgencia
                             select conta).ToList();
        return consulta;
    }

    private static void ExibirListadeContas(List<ContaCorrente> contasPorAgencia)
    {
        if (contasPorAgencia == null)
        {
            Console.WriteLine("... A consulta não retornou dados ...");
        }
        else
        {
            foreach (var item in contasPorAgencia)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
    private void OdernarContas()
    {
        _listaDeContas.Sort(); //ordena uma lista 
        Console.WriteLine("... Lista de Contas Ordenada ...");
        Console.ReadKey();
    }

    private void RemoverContas()
    {
        Console.Clear();
        Console.WriteLine("==============================");
        Console.WriteLine("===     REMOVER CONTAS     ===");
        Console.WriteLine("==============================");
        Console.WriteLine("\n");
        Console.WriteLine("Informe o número da Conta: ");

        string numeroConta = Console.ReadLine();
        ContaCorrente conta = null;
        bool contaEncontrada = false;

        // Encontrar a conta a ser removida
        foreach (var item in _listaDeContas)
        {
            if (item.Conta.Equals(numeroConta))
            {
                conta = item;
                contaEncontrada = true;
                break; // Não precisa continuar a interação se a conta for encotnrada
            }
        }

        // Remover conta encontrada
        if (contaEncontrada)
        {
            _listaDeContas.Remove(conta);
            Console.WriteLine("... Conta removida da lista! ...");
        }
        else
        {
            Console.WriteLine("... Conta para remoção não encontrada ...");
        }

        Console.ReadKey();
    }

    private void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("===         CADASTRO DE CONTAS         ===");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("\n");
        Console.WriteLine("===      INFORME OS DADOS DA CONTA      ===");

        Console.Write("Número da conta: ");
        string numeroConta = Console.ReadLine();

        Console.WriteLine("Número da agencia: ");
        int numeroAgencia = int.Parse(Console.ReadLine());

        ContaCorrente conta = new(numeroAgencia);
        System.Console.WriteLine($"Numero da conta [NOVA] : {conta.Conta}");
        Console.WriteLine("Informe o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine());

        Console.WriteLine("Informe o nome do titular: ");
        conta.Titular.Nome = Console.ReadLine();

        Console.WriteLine("Informe o CPF do titular: ");
        conta.Titular.Cpf = Console.ReadLine();

        Console.WriteLine("Informe a profissão do titular: ");
        conta.Titular.Profissao = Console.ReadLine();

        _listaDeContas.Add(conta);

        Console.WriteLine("... CONTA CADASTRADA COM SUCESSO ...");
        Console.ReadKey();
    }

    private void ListarConta()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("\n");

        if (_listaDeContas.Count <= 0)
        {
            Console.WriteLine("... Não há contas cadastradas! ...");
            Console.ReadKey();
            return;
        }

        foreach (ContaCorrente item in _listaDeContas)
        {
            // Console.WriteLine("===  Dados da Conta  ===");
            // Console.WriteLine("Número da Conta: " + item.Conta);
            // Console.WriteLine("Saldo em conta: " + item.Saldo);
            // Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
            // Console.WriteLine("CPF do titular: " + item.Titular.Cpf);
            // Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
            Console.WriteLine(item.ToString());
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ReadKey();
        }
    }

    #region Testes de Uso do List
    // Generica<int> teste1 = new(); Código de teste
    // teste1.MostrarMensagem(10);

    // Generica<string> teste2 = new();
    // teste2.MostrarMensagem("Olá Mundo");

    // public class Generica<T>
    // {
    //     public void MostrarMensagem(T t)
    //     {
    //         System.Console.WriteLine($"Exibindo {t}");
    //     }
    // }

    // List<ContaCorrente> _listaDeContas2 =
    // [
    //     new ContaCorrente(874, "5679787-A"),
    //     new ContaCorrente(874, "4456668-B"),
    //     new ContaCorrente(874, "7781438-C")
    // ];


    // List<ContaCorrente> _listaDeContas3 =
    // [
    //     new ContaCorrente(951, "5679787-E"),
    //     new ContaCorrente(321, "4456668-F"),
    //     new ContaCorrente(719, "7781438-G")
    // ];


    // _listaDeContas2.AddRange(_listaDeContas3);  //AddRange vai pegar uma lista e adicionar outra
    // _listaDeContas2.Reverse();// reverter este objeto

    // for (int i = 0; i < _listaDeContas2.Count; i++)
    // {
    //     System.Console.WriteLine($"Indice[{i}] Conta: [{_listaDeContas2[i].Conta}]");
    // }

    // System.Console.WriteLine("\n\n");

    // if (_listaDeContas3.Count > 0)
    // {
    //     var range = _listaDeContas3.GetRange(0, Math.Min(1, _listaDeContas3.Count));
    //     for (int i = 0; i < range.Count; i++)
    //     {
    //         System.Console.WriteLine($"Indice[{i}] = Conta: [{range[i].Conta}]");

    //     }

    //     _listaDeContas3.Clear();
    //     for (int i = 0; i < _listaDeContas3.Count; i++)
    //     {
    //         System.Console.WriteLine($"Indice[{i}] Conta [{range[i].Conta}]");
    //     }

    // }
    // else
    // {
    //     // Handle case where _listaDeContas3 is empty
    //     System.Console.WriteLine("Error: _listaDeContas3 is empty.");
    // }
    #endregion

}
