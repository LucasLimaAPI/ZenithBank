System.Console.WriteLine("Boas Vindas ao ZenithBank, Atendimento");

//TestaArrayInt();
TestaBuscarPalavra();

void TestaArrayInt()
{
    int [] idades = new int [5];// array []
    idades [0] = 30;
    idades [1] = 10;
    idades [2] = 20;
    idades [3] = 55;
    idades [4] = 3;

    System.Console.WriteLine($"Tamanho do Array {idades.Length}"); // vai ler a quantidade de que está dentro do array, no caso seu indice.

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        System.Console.WriteLine($"Indice [{i}] = {idade}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    System.Console.WriteLine($"Media de idades = {media}");
}

void TestaBuscarPalavra()
{

    string[] arrayDePalavras = new string[5]; //Em new string[5] mostra que o array vai conter 5 palavras
    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        System.Console.WriteLine($"Digite {i+1} Palavra: ");
        arrayDePalavras [i] = Console.ReadLine();
    }
    System.Console.WriteLine($"Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            System.Console.WriteLine($"Palavra encontrada = {busca}");
            break;
        }
    
    }
}