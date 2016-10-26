using System;

namespace DemoBinarySearchTree
{
    /// <summary>
    /// Implementación del Nodo para un árbol binario
    /// </summary>
    /// <typeparam name="E">Tipo de dato del elemento que se referencia en cada nodo</typeparam>
    public class BTNode<E>
    {
        private E item;
        public virtual E Item
        {
            get { return this.item; }
            set { this.item = value; }
        }
        private BTNode<E> left;
        public virtual BTNode<E> Left
        {
            get { return this.left; }
            set { this.left = value; }
        }
        private BTNode<E> right;
        public virtual BTNode<E> Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        /// <summary>
        /// Constructor por defecto con valores por defecto
        /// Constructor especializado, permite fijar el elemento del nodo
        /// y el valor de los enlaces a subárboles izquierdo y derecho
        /// </summary>
        /// <param name="item">Elemento en el nodo</param>
        /// <param name="next">Enlace al subárbol izquierdo</param>
        /// <param name="prev">Enlace al subárbol derecho</param>
        public BTNode(E item = default(E), BTNode<E> left = null, BTNode<E> right = null)
        {
            this.Item = item;
            this.Left = left;
            this.Right = right;
        }













        /// <summary>
        /// Metodo para probar las distintas formas en que
        /// se puede recorrer un árbol
        /// </summary>
        public virtual void Visit()
        {
            Console.Write("{0} ", this.Item.ToString());
        }
    }
}
