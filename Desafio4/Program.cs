using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

Console.WriteLine("--- Desafio 4: Herança e Polimorfismo ---\n");

var minhaLoja = new Loja("Loja de Herança");

minhaLoja.AdicionarProduto(new ProdutoEletronico(1, "Notebook", 3500.00m, 5, 12));
minhaLoja.AdicionarProduto(new ProdutoPerecivel(2, "Leite", 5.50m, 30, new DateTime(2025, 8, 20)));
minhaLoja.AdicionarProduto(new Produto(3, "Caderno", 15.00m, 50)); 

minhaLoja.ListarProdutos();

Console.ReadKey();


public class Loja
{
    public string? Nome { get; set; }
    public List<Produto> ListaDeProdutos;

    public Loja(string nome)
    {
        Nome = nome;
        ListaDeProdutos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        ListaDeProdutos.Add(produto);
        Console.WriteLine($"\nProduto '{produto.Nome}' adicionado à loja.");
    }

    public void ListarProdutos()
    {
        Console.WriteLine("\n--- Produtos em Estoque ---");
        if (ListaDeProdutos.Count == 0)
        {
            Console.WriteLine("A loja não tem produtos cadastrados.");
        }
        else
        {
            foreach (var produto in ListaDeProdutos)
            {
                
                produto.ExibirInformacoes();
            }
        }
    }
}


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

    public virtual void ExibirInformacoes()
    {
        Console.WriteLine($"[Comum] {Nome} | Preço: {Preco:c} | Estoque: {Estoque} unidades");
    }
}


public class ProdutoPerecivel : Produto
{
    public DateTime DataValidade { get; set; }

    public ProdutoPerecivel(int id, string? nome, decimal preco, int estoque, DateTime dataValidade)
        : base(id, nome, preco, estoque) 
    {
        DataValidade = dataValidade;
    }

    public void VerificarValidade()
    {
        if (DateTime.Now > DataValidade)
        {
            Console.WriteLine($"ATENÇÃO: O produto '{Nome}' está vencido!");
        }
        else
        {
            Console.WriteLine($"O produto '{Nome}' está na validade.");
        }
    }

    
    public override void ExibirInformacoes()
    {
        Console.WriteLine($"[Perecível] {Nome} | Preço: {Preco:c} | Validade: {DataValidade:d}");
    }
}

public class ProdutoEletronico : Produto
{
    public int GarantiaMeses { get; set; }

    public ProdutoEletronico(int id, string? nome, decimal preco, int estoque, int garantiaMeses)
        : base(id, nome, preco, estoque) 
    {
        GarantiaMeses = garantiaMeses;
    }

    public void ExibirGarantia()
    {
        Console.WriteLine($"A garantia do {Nome} é de {GarantiaMeses} meses.");
    }

    
    public override void ExibirInformacoes()
    {
        Console.WriteLine($"[Eletrônico] {Nome} | Preço: {Preco:c} | Garantia: {GarantiaMeses} meses");
    }
}


