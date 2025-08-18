Console.WriteLine("#desafio do Renan#");


Produto produto = new();


var produto1 = new Produto(1, "Notebook", 3500.00m, 5);
var produto2 = new Produto(2, "Mouse", 45.00m, 30);
var produto3 = new Produto(3, "Monitor", 850.00m, 12);


produto1.AplicarDesconto(0.1m);  // 10% de desconto
produto2.AplicarDesconto(0.2m);  // 20% de desconto
produto3.AplicarDesconto(0.6m);  // 60% de desconto (não)

Console.WriteLine("--- Informações dos Produtos ---");
produto1.ExibirInformacoes();
produto2.ExibirInformacoes();
produto3.ExibirInformacoes();

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

    public Produto()
    {
      
    }

    public void AplicarDesconto(decimal percentual)
    {
        
        if (percentual > 0.5m)
        {
            Console.WriteLine($"\nERRO: Desconto máximo permitido é de 50%. O desconto de {percentual:P0} não foi aplicado ao produto {Nome}.");
        }
        else
        {
           
            decimal valorDoDesconto = Preco * percentual;
            Preco -= valorDoDesconto;
        }
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Produto: {Nome} | Preço: {Preco:c} | Estoque: {Estoque} unidades");
    }

}





