using System;
using System.Collections.Generic;

namespace DemoBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Demo01();
        }

        public void Demo01()
        {
            List<int> numeros = new List<int>();
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            Random random = new Random();

            int num;
            for (int i = 0; i < 10; ++i)
            {
                num = random.Next(1, 100);
                numeros.Add(num);
                bst.Add(num);
            }

            Console.Write("Números   ");
            foreach (int n in numeros)
            {
                Console.Write("{0} ", n);
            }
            Console.WriteLine();

            Console.WriteLine("Arbol bst {0}", bst.ToString());
            Console.WriteLine();

            Console.Write("En orden  ");
            bst.InOrder();
            Console.WriteLine();

            Console.WriteLine("Cantidad de nodos: {0}", bst.NodeCount());
            Console.WriteLine("Cantidad de hojas: {0}", bst.LeafCount());
            Console.WriteLine("Nodos Internos   : {0}", bst.InternalNodeCount());
            Console.WriteLine("Máximo nivel     : {0}", bst.MaxLevel());
            Console.WriteLine("Altura           : {0}", bst.Height());

            Console.WriteLine("\nPrueba de la extracción");
            while (true)
            {
                Console.WriteLine("Arbol bst {0}", bst.ToString());
                Console.Write("Ingrese valor a remover (0 finaliza): ");
                string line = Console.ReadLine();
                num = int.Parse(line);
                if (num == 0) { break; }
                bst.Remove(num);
                Console.Write("En orden  ");
                bst.InOrder();
                Console.WriteLine();
            }

        }
    }


}
