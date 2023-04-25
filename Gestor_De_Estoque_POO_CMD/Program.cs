﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_De_Estoque_POO_CMD
{
    
    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();

        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair}
        static void Main(string[] args)
        {
            Carregar();

            bool escolheuSair = false;

            while(escolheuSair == false)
            {
                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Entrada\n5-Saida\n6-Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
               
                if(opInt > 0 && opInt < 7)
                {
                    Menu escolha = (Menu)opInt;
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;

                    }
                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
                
            }

        }
        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Difite o ID do elemento que voce quer dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("Difite o ID do elemento que voce quer dar baixa: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }



        static void Listagem()
        {
            Console.WriteLine("Lista de pordutos");
            int i = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine($"ID: {i}");
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Difite o ID do elemento que voce quer remover: ");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            string opStr = Console.ReadLine();
            int escolaInt = int.Parse(opStr);
            switch (escolaInt)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }

        }

        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());

            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());

            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());

            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch(Exception e)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();

        }
    }
}
