using System;
using System.Collections.Generic;

namespace DemoBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Demo01();
        }

        public void Demo01()
        {
            // D(B(A, C), E( , G(F, )))

            BinaryTree<char> a1 = new BinaryTree<char>('B', new BinaryTree<char>('A'), new BinaryTree<char>('C'));
            BinaryTree<char> a2 = new BinaryTree<char>('G', new BinaryTree<char>('F'), null);
            BinaryTree<char> a3 = new BinaryTree<char>('E', null, a2);

            BinaryTree<char> a = new BinaryTree<char>('D', a1, a3);

            Console.WriteLine("Arbol       {0}", a.ToString());
            Console.WriteLine();

            Console.Write("Pre orden   ");
            a.PreOrder();
            Console.WriteLine();
            Console.Write("En orden    ");
            a.InOrder();
            Console.WriteLine();
            Console.Write("Post orden  ");
            a.PostOrder();
            Console.WriteLine();

            Console.WriteLine("Cantidad de nodos: {0}", a.NodeCount());
            Console.WriteLine("Cantidad de hojas: {0}", a.LeafCount());
            Console.WriteLine("Nodos Internos   : {0}", a.InternalNodeCount());
            Console.WriteLine("Máximo nivel     : {0}", a.MaxLevel());
            Console.WriteLine("Altura           : {0}", a.Height());

            Console.Write("Descendente ");
            a.InDescendingOrder();
            Console.WriteLine();
        }

    }

}
