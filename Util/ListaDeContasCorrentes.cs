using ZENITHBANK.Conta;
namespace ZENITHBANK.Util;
//Encapsulamento dos arrays.
public class ListaDeContasCorrentes(int tamanhoInicial = 5)
{
    private ContaCorrente[] _itens = new ContaCorrente[tamanhoInicial];
    private int _proximaPosicao = 0;

    public void Adicionar(ContaCorrente item)
    {
        Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
        VerificarCapacidade(_proximaPosicao + 1);
        _itens[_proximaPosicao] = item;
        _proximaPosicao++;
    }

    private ContaCorrente[] Get_itens()
    {
        return _itens;
    }

    //VERIFICAR O TAMANHO DO ARRAY
    private void VerificarCapacidade(int tamanhoNecessario)
    {
        if (_itens.Length >= tamanhoNecessario)
        {
            return;
        }
        Console.WriteLine("Aumentando a capacidade da lista!");
        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

        for (int i = 0; i < _itens.Length; i++)
        {
            novoArray[i] = _itens[i];
        }
        _itens = novoArray;
    }

    //RETORNA A CONTA COM O MAIOR SALDO

    public ContaCorrente MaiorSaldo()
    {
        ContaCorrente conta = null;
        double maiorValor = 0;
        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[i] != null)
            {
                if (maiorValor < _itens[i].Saldo)
                {
                    maiorValor = _itens[i].Saldo;
                    conta = _itens[i];
                }
            }
        }
        System.Console.WriteLine($"O Maior valor é: {maiorValor}");
        return conta;
    }

    //EXIBE LISTA

    public void ExibeLista()
    {
        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[i] != null)
            {
                var conta = _itens[i];
                System.Console.WriteLine($"Indice [{i}] = " + $"Conta:{conta.Conta} -" + $"N° da Agência: {conta.Numero_agencia}");
            }
        }
    }

    public ContaCorrente RecuperarContaNoIndice(int indice)
    {
        if (indice < 0 || indice >= _proximaPosicao)
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }
        return _itens[indice];
    }

    public int Tamanho
    {
        get
        {
            return _proximaPosicao;
        }
    } // Será somente para leitura então tera apenas o get

    public ContaCorrente this[int indice]
    {
        get
        {
            return RecuperarContaNoIndice(indice);
        }
    }

    //METODO PARA REMOVER CONTA
    public void Remover(ContaCorrente conta)
    {
        int indiceItem = -1;
        for (int i = 0; i < _proximaPosicao; i++)
        {
            ContaCorrente contaAtual = _itens[i];
            if (contaAtual == conta)
            {
                indiceItem = i;
                break;
            }
        }

        for (int i = indiceItem; i < _proximaPosicao - 1; i++)
        {
            _itens[i] = _itens[i + 1];
        }
        _proximaPosicao--;
        _itens[_proximaPosicao] = null;
    }

}