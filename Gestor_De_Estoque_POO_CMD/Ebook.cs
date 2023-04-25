using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_De_Estoque_POO_CMD
{
    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada no ebook, pois é um produto digital ");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no Ebook: {nome}");
            Console.WriteLine("Digite a Qtd. de vendas que que dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("saida Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Auror: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"vendas: {vendas}");
            Console.WriteLine("============================");
        }
    }
}
