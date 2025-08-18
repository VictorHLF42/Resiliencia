using System;


Console.WriteLine("--- SIMULAÇÃO DE ESTOQUE (Desafio 2) ---");

var mouse = new Produto(1, "Mouse", 45.00m, 30);

Console.WriteLine("\nAntes da venda:");
mouse.ExibirInformacoes();


mouse.RemoverEstoque(5);

Console.WriteLine("Após vender 5 unidades:");
mouse.ExibirInformacoes();


mouse.AdicionarEstoque(10);

Console.WriteLine("Após repor 10 unidades:");
mouse.ExibirInformacoes();

Console.ReadKey();



public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }

    public Produto(int id, string? nome, decimal preco, int estoque)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade > 0)
        {
            Estoque += quantidade;
            Console.WriteLine($"\n{quantidade} unidades adicionadas ao estoque.");
        }
        else
        {
            Console.WriteLine("\nNão é possível adicionar uma quantidade negativa ou zero.");
        }
    }

    public void RemoverEstoque(int quantidade)
    {
        if (quantidade > Estoque)
        {
            Console.WriteLine($"\nERRO: Não há {quantidade} unidades no estoque de {Nome}. Estoque atual: {Estoque}.");
        }
        else if (quantidade <= 0)
        {
            Console.WriteLine("\nNão é possível remover uma quantidade negativa ou zero.");
        }
        else
        {
            Estoque -= quantidade;
            Console.WriteLine($"\n{quantidade} unidades removidas do estoque.");
        }
    }

   
    public void ExibirInformacoes()
    {
        Console.WriteLine($"Produto: {Nome} | Estoque: {Estoque} unidades");
    }
}