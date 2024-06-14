using System.Collections;
using System.Reflection.Metadata;
using ZENITHBANK.Conta;
using ZENITHBANK.Util;

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

ArrayList _listaDeContas = [];

AtendimentoCliente();
void AtendimentoCliente()
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
        opcao = Console.ReadLine()[0];
        switch (opcao)
        {
            case '1':
                CadastrarConta();
                break;
            case '2':
                ListarConta();    
                break;
            default:
                System.Console.WriteLine("Opcao não implementada.");
                break;
        }
    }
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

    if(_listaDeContas.Count <=0)
    {
        System.Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        return;
    }

    foreach (ContaCorrente item in _listaDeContas)
    {
        System.Console.WriteLine("===  Dados da Conta  ===");
        System.Console.WriteLine("Número da Conta: "+ item.Conta );
        System.Console.WriteLine("Titular da Conta: "+ item.Titular.Nome);
        System.Console.WriteLine("CPF do titular: " + item.Titular.Cpf);
        System.Console.WriteLine("Profissão do Titular: "+ item.Titular.Profissao);
        System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.ReadKey();
    }
}