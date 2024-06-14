namespace ZENITHBANK.Conta;

public class Cliente
{

    public string Cpf { get; set; }

    private string _nome = string.Empty;
    public string Nome
    {
        get
        {
            return _nome;
        }
        set
        {
            if (value.Length < 3)
            {
                Console.WriteLine("Nome do titular precisa ter pelo menos 3 caracteres.");
                return;
            }
            _nome = value;
        }

    }
    //public string Nome { get; set; }
    public string Profissao { get; set; }

    public static int TotalClientesCadastrados { get; set; }

    public Cliente()
    {
        TotalClientesCadastrados++;
    }
}
