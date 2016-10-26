using System;

namespace DemoAVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Demo01();
        }

        private void Demo01()
        {
            AVLTree<int> tree = new AVLTree<int>();
            // Cambiar el arreglo para verificar la insersión en un árbol AVL
            int[] numeros = {55, 30, 75, 4, 41, 85, 54, 25, 44, 28, 35, 31};

            foreach (int n in numeros) {
                MostrarAgregar(tree, n);
            }
        }

        
        
        /// <summary>
        /// Agrega un elemento al árbol luego lo muestra
        /// </summary>
        /// <param name="tree">Árbol AVL</param>
        /// <param name="item">Elemento a agregar</param>
        void MostrarAgregar(AVLTree<int> tree, int item)
        {
            Console.Write("Agrega : {0}", item.ToString());
            tree.Add(item);
            Console.WriteLine("\t : {0}", tree.ToString());
        }

    }
}
