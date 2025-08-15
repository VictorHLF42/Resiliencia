using System;
using System.Collections.Generic; // Para poder usar a classe List

Console.WriteLine("--- Desafio 3: Classe Loja ---\n");
Console.WriteLine();

// 1. Instanciar a loja
var minhaLoja = new Loja("Minha Loja de Eletrônicos");

// 2. Cadastrar produtos
minhaLoja.AdicionarProduto(new Produto(1, "Notebook", 3500.00m, 5));
minhaLoja.AdicionarProduto(new Produto(2, "Mouse", 45.00m, 30));
minhaLoja.AdicionarProduto(new Produto(3, "Monitor", 850.00m, 12));

// Listar produtos
minhaLoja.ListarProdutos();

// 3. Realizar vendas
Console.WriteLine("\n--- Realizando Vendas ---");
minhaLoja.VenderProduto(2, 5); // Vende 5 mouses
minhaLoja.VenderProduto(3, 15); // Tenta vender 15 monitores (estoque insuficiente)
minhaLoja.VenderProduto(4, 1); // Tenta vender um produto que não existe

// Listar produtos após as vendas
minhaLoja.ListarProdutos();



Console.ReadKey();


// CLASSE LOJA
public class Loja
{
    // Propriedades da classe
    public string? Nome;
    public List<Produto> ListaDeProdutos;

    // Construtor
    public Loja(string nome)
    {
        Nome = nome;
        ListaDeProdutos = new List<Produto>(); // Inicializa a lista
    }

    // Método para adicionar um produto à lista
    public void AdicionarProduto(Produto produto)
    {
        ListaDeProdutos.Add(produto);
        Console.WriteLine($"\nProduto '{produto.Nome}' adicionado à loja.");
    }

    // Método para listar todos os produtos
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
                // Reutiliza o método da classe Produto
                produto.ExibirInformacoes();
            }
        }
    }

    // Método para vender um produto
    public void VenderProduto(int id, int quantidade)
    {
        // Procura o produto na lista pelo ID
        var produtoAVender = ListaDeProdutos.Find(p => p.Id == id);

        if (produtoAVender != null)
        {
            // O método RemoverEstoque da classe Produto já cuida da lógica de validação
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
    public int Id;
    public string? Nome;
    public decimal Preco;
    public int Estoque;

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

