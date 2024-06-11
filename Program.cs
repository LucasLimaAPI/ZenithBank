System.Console.WriteLine("Boas Vindas ao ZenithBank, Atendimento");

//TestaArrayInt();
//TestaBuscarPalavra();

void TestaArrayInt()
{
    int[] idades = new int[5];// array []
    idades[0] = 30;
    idades[1] = 10;
    idades[2] = 20;
    idades[3] = 55;
    idades[4] = 3;

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
        System.Console.WriteLine($"Digite {i + 1} Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
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


Array amostra = Array.CreateInstance(typeof(double), 5);//metodo createinstance precisamos determinar o tipo e o tamanho.
amostra.SetValue(5.8, 0);
amostra.SetValue(1.5, 1);
amostra.SetValue(7.2, 2);
amostra.SetValue(10, 3);
amostra.SetValue(5.8, 4);

TestaMediana(amostra);

static void TestaMediana(Array array)
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
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}

