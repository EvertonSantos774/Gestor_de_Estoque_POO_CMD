using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_De_Estoque_POO_CMD
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
            
                
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto: {nome}");
            Console.WriteLine("Digite a Qtd. que quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saida no estoque do produto: {nome}");
            Console.WriteLine("Digite a Qtd. que quer dar baixa: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque -= entrada;
            Console.WriteLine("Saida Registrada");
            Console.ReadLine();

        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("============================");
        }
    }
}
