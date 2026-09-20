using System;

public class No
{
    public int Valor;
    public No? Proximo;
    public No(int valor) { Valor = valor; Proximo = null; }
}

public class ListaLigada
{
    private No? cabeca;

    public void InserirInicio(int valor)
    {
        No novo = new No(valor);
        novo.Proximo = cabeca;
        cabeca = novo;
    }

    public void InserirFim(int valor)
    {
        No novo = new No(valor);
        if (cabeca == null) { cabeca = novo; return; }
        No atual = cabeca;
        while (atual.Proximo != null) atual = atual.Proximo;
        atual.Proximo = novo;
    }

    public bool Remover(int valor)
    {
        if (cabeca == null) return false;
        if (cabeca.Valor == valor) { cabeca = cabeca.Proximo; return true; }
        No atual = cabeca;
        while (atual.Proximo != null && atual.Proximo.Valor != valor)
            atual = atual.Proximo;
        if (atual.Proximo != null)
        {
            atual.Proximo = atual.Proximo.Proximo;
            return true;
        }
        return false;
    }

    public bool Buscar(int valor)
    {
        No? atual = cabeca;
        while (atual != null)
        {
            if (atual.Valor == valor) return true;
            atual = atual.Proximo;
        }
        return false;
    }

    public void Exibir()
    {
        No? atual = cabeca;
        while (atual != null)
        {
            Console.Write($"{atual.Valor} -> ");
            atual = atual.Proximo;
        }
        Console.WriteLine("null");
    }
}

class Program
{
    static void Main()
    {
        var lista = new ListaLigada();
        lista.InserirFim(10);
        lista.InserirFim(20);
        lista.InserirInicio(5);
        lista.Exibir();
        Console.WriteLine($"Buscar 10: {lista.Buscar(10)}");
        lista.Remover(10);
        lista.Exibir();
    }
}
