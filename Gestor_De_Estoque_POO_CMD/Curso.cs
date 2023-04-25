using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_De_Estoque_POO_CMD
{
    [System.Serializable]
    internal class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar Vagas no Curso: {nome}");
            Console.WriteLine("Digite a Qtd. de vagas que quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir Vagas no Curso: {nome}");
            Console.WriteLine("Digite a Qtd. de vagas que quer consumir: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas -= entrada;
            Console.WriteLine("Saida Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Auror: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas Restantes: {vagas}");
            Console.WriteLine("============================");
        }
    }
}
