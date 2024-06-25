using System.Collections;
using ZENITHBANK.Conta;
using ZENITHBANK.Util;
using ZENITHBANK.zenithbank.Exceptions;

Console.WriteLine("Boas Vindas ao ZenithBank, Atendimento.");
//COM O #REGION PODEMOS MARCAR UMA AREA PARA MINIMIZALA
#region Exemplos Arrays Em C#
//TestaArrayInt();
//TestaBuscarPalavra();

void TestaArrayInt()
{
    int[] idades = [30, 40, 17, 21, 18];
    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"índice [{i}] = {idade}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"Média de idades = {media}");
}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite palavara a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
            break;
        }
    }

}

Array amostra = new double[5];
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//[5,9][1,8][7,1][10][6,9]
//TestaMediana(amostra);

void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para cálculo da mediana está vazio ou nulo.");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);
    //[1,8][5,9][6,9][7,1][10]

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
                                   (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}

int[] valores = { 10, 58, 36, 47 };

for (int i = 0; i < 4; i++)
{
    Console.WriteLine(valores[i]);
}

// código anterior omitido
static void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new();
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));

    var contaDoLucas = new ContaCorrente(988, "000000-1");
    listaDeContas.Adicionar(contaDoLucas);
    // listaDeContas.ExibeLista();
    // System.Console.WriteLine("-------------------");
    // listaDeContas.Remover(contaDoLucas);
    // listaDeContas.ExibeLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        System.Console.WriteLine($"Indice [{i}] = {conta.Conta} / {conta.Numero_agencia}");
    }
}

// TestaArrayDeContasCorrentes();
#endregion

List<ContaCorrente> _listaDeContas = [
    new(95,"123456-X"){Saldo= 150},
    new(95,"954321-Z"){Saldo = 200},
    new(94,"578965-W"){Saldo = 10}

];

void AtendimentoCliente()
{
    try
    {
        char opcao = 'O'; // char = ''
        while (opcao != '6')
        {
            Console.Clear();
            System.Console.WriteLine("-----------------------------------------");
            System.Console.WriteLine("===            ATENDIMENTO            ===");
            System.Console.WriteLine("===      .1 - CADASTRAR CONTA         ===");
            System.Console.WriteLine("====     .2 - LISTAR CONTAS           ===");
            System.Console.WriteLine("===      .3 - REMOVER CONTA           ===");
            System.Console.WriteLine("===      .4 - ORDENAR CONTAS          ===");
            System.Console.WriteLine("===      .5 - PESQUISAR CONTA         ===");
            System.Console.WriteLine("===      .6 - SAIR DO SISTEMA         ===");
            System.Console.WriteLine("-----------------------------------------");
            System.Console.Write("\n\n");
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
                default:
                    System.Console.WriteLine("Opcao não implementada.");
                    break;
            }
        }
    }
    catch (ZenithBankException excecao)
    {

        System.Console.WriteLine($"{excecao.Message}");
    }


}

void OdernarContas()
{
    _listaDeContas.Sort(); //ordena uma lista 
    System.Console.WriteLine("... Lista de Contas Ordenada ...");
    Console.ReadKey();
}

void RemoverContas()
{
    Console.Clear();
    System.Console.WriteLine("==============================");
    System.Console.WriteLine("===     REMOVER CONTAS     ===");
    System.Console.WriteLine("==============================");
    System.Console.WriteLine("\n");
    System.Console.WriteLine("Informe o número da Conta: ");

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
        System.Console.WriteLine("... Conta removida da lista! ...");
    }
    else
    {
        System.Console.WriteLine("... Conta para remoção não encontrada ...");
    }

    Console.ReadKey();
}

void CadastrarConta()
{
    Console.Clear();
    System.Console.WriteLine("------------------------------------------");
    System.Console.WriteLine("===         CADASTRO DE CONTAS         ===");
    System.Console.WriteLine("-------------------------------------------");
    System.Console.WriteLine("\n");
    System.Console.WriteLine("===      INFORME OS DADOS DA CONTA      ===");

    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine();

    System.Console.WriteLine("Número da agencia: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new(numeroAgencia, numeroConta);

    System.Console.WriteLine("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    System.Console.WriteLine("Informe o nome do titular: ");
    conta.Titular.Nome = Console.ReadLine();

    System.Console.WriteLine("Informe o CPF do titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    System.Console.WriteLine("Informe a profissão do titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    _listaDeContas.Add(conta);

    System.Console.WriteLine("... CONTA CADASTRADA COM SUCESSO ...");
    Console.ReadKey();
}

void ListarConta()
{
    Console.Clear();
    System.Console.WriteLine();
    System.Console.WriteLine("");
    System.Console.WriteLine("");
    System.Console.WriteLine("\n");

    if (_listaDeContas.Count <= 0)
    {
        System.Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        return;
    }

    foreach (ContaCorrente item in _listaDeContas)
    {
        System.Console.WriteLine("===  Dados da Conta  ===");
        System.Console.WriteLine("Número da Conta: " + item.Conta);
        System.Console.WriteLine("Saldo em conta: " + item.Saldo);
        System.Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
        System.Console.WriteLine("CPF do titular: " + item.Titular.Cpf);
        System.Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
        System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
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

AtendimentoCliente();

