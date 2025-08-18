using System;
using System.Collections.Generic; 

Console.WriteLine("--- Desafio 3: Classe Loja ---\n");
Console.WriteLine();


var minhaLoja = new Loja("Minha Loja de Eletrônicos");


minhaLoja.AdicionarProduto(new Produto(1, "Notebook", 3500.00m, 5));
minhaLoja.AdicionarProduto(new Produto(2, "Mouse", 45.00m, 30));
minhaLoja.AdicionarProduto(new Produto(3, "Monitor", 850.00m, 12));


minhaLoja.ListarProdutos();


Console.WriteLine("\n--- Realizando Vendas ---");
minhaLoja.VenderProduto(2, 5); 
minhaLoja.VenderProduto(3, 15); 
minhaLoja.VenderProduto(4, 1);


minhaLoja.ListarProdutos();



Console.ReadKey();



public class Loja
{
    
    public string? Nome;
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

    
    public void VenderProduto(int id, int quantidade)
    {
        
        var produtoAVender = ListaDeProdutos.Find(p => p.Id == id);

        if (produtoAVender != null)
        {
            
            produtoAVender.RemoverEstoque(quantidade);
        }
        else
        {
            Console.WriteLine($"\nERRO: Produto com ID {id} não encontrado.");
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

    
    public void RemoverEstoque(int quantidade)
    {
        if (quantidade > Estoque)
        {
            Console.WriteLine($"\nProduto esgotado ou estoque insuficiente.");
        }
        else if (quantidade <= 0)
        {
            Console.WriteLine("\nNão é possível remover uma quantidade negativa ou zero.");
        }
        else
        {
            Estoque -= quantidade;
            Console.WriteLine($"\nProduto '{Nome}' vendido com sucesso!");
        }
    }

   
    public void ExibirInformacoes()
    {
        Console.WriteLine($"Produto: {Nome} | Estoque: {Estoque} unidades");
    }
}

