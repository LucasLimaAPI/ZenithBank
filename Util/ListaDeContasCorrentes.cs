using ZENITHBANK.Conta;
namespace ZENITHBANK.Util;
//Encapsulamento dos arrays.
public class ListaDeContasCorrentes(int tamanhoInicial = 5)
{
    private  ContaCorrente[] _itens = new ContaCorrente[tamanhoInicial];
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
}