using System;
using System.Collections.Generic;

Console.WriteLine("--- Desafio 5: Interfaces e Polimorfismo ---\n");

var minhaLoja = new Loja("Loja de Eletrônicos");

minhaLoja.AdicionarProduto(new Produto(1, "Notebook", 3500.00m, 5));
minhaLoja.AdicionarProduto(new Produto(2, "Mouse", 45.00m, 30));


var pagamentoCartao = new PagamentoCartao();
var pagamentoPix = new PagamentoPix();

Console.WriteLine("\n--- Simulando Vendas ---");

minhaLoja.VenderProduto(1, 1, pagamentoCartao);

minhaLoja.VenderProduto(2, 1, pagamentoPix);

Console.ReadKey();

public interface IPagamento
{
    void ProcessarPagamento(decimal valor);
}


public class PagamentoCartao : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Pagamento via cartão processado: {valor:c}");
    }
}


public class PagamentoPix : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Pagamento via PIX processado: {valor:c}");
    }
}



public class Loja
{
    public string? Nome { get; set; }
    public List<Produto> ListaDeProdutos { get; set; }

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

    public void VenderProduto(int id, int quantidade, IPagamento formaDePagamento)
    {
        var produtoAVender = ListaDeProdutos.Find(p => p.Id == id);

        if (produtoAVender != null)
        {
            if (quantidade > produtoAVender.Estoque)
            {
                Console.WriteLine($"\nProduto esgotado ou estoque insuficiente.");
            }
            else
            {
                
                formaDePagamento.ProcessarPagamento(produtoAVender.Preco * quantidade);

               
                produtoAVender.Estoque -= quantidade;
                Console.WriteLine($"\nProduto '{produtoAVender.Nome}' vendido com sucesso!");
            }
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

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Produto: {Nome} | Estoque: {Estoque} unidades");
    }
}

