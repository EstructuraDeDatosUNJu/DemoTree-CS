using System;

namespace DemoBinarySearchTree
{
    /// <summary>
    /// Implementación de Árbol Binario de Búsqueda
    /// </summary>
    /// <typeparam name="E">Tipo de dato del elemento que se referencia en cada nodo</typeparam>
    public class BinarySearchTree<E> : BinaryTree<E> where E : IComparable
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public BinarySearchTree() : base(null)
        { }

        /// <summary>
        /// Constructor especializado que crea un árbol
        /// binario de busqueda para el elemento indicado
        /// </summary>
        /// <param name="item">Elemento</param>
        public BinarySearchTree(E item) : base(item)
        { }

        #region Comportamiento Agregar y Retirar elementos

        /// <summary>
        /// Agrega un elemento al árbol binario de búsqueda
        /// </summary>
        /// <param name="item">Elemento a agregar</param>
        public virtual void Add(E item)
        {
            if (this.IsEmpty)
            {
                this.Root = new BTNode<E>(item);
            }
            else
            {
                // busca iterativamente la posición para el nuevo elemento
                BTNode<E> temp = this.Root, prev = null;
                while (temp != null)
                {
                    prev = temp;
                    if (item.CompareTo(temp.Item) < 0)
                    {
                        temp = temp.Left;
                    }
                    else
                    {
                        temp = temp.Right;
                    }
                }
                // crea y agrega un nodo de acuerdo al criterio de orden
                temp = new BTNode<E>(item);
                if (item.CompareTo(prev.Item) < 0)
                {
                    prev.Left = temp;
                }
                else
                {
                    prev.Right = temp;
                }
            }
        }

        /// <summary>
        /// Extrae el elemento del árbol binario de busqueda
        /// </summary>
        /// <param name="item">Elemento a extraer</param>
        public virtual E Remove(E item)
        {
            return RemoveByFusion(item);
        }

        /// <summary>
        /// Extrae el elemento del árbol binario de busqueda
        /// implementa la técnica de menor de los mayores
        /// implementa la técnica de sustitución o copia
        /// </summary>
        /// <param name="item">Elemento a extraer</param>
        protected virtual E RemoveByCopy(E item)
        {
            BTNode<E> find = this.Root, prev = null;
            while ((find != null) && (!find.Item.Equals(item)))
            { // búsqueda iterativa del nodo recordando al nodo padre
                prev = find;
                if (item.CompareTo(find.Item) < 0)
                {
                    find = find.Left;
                }
                else
                {
                    find = find.Right;
                }
            }
            // find es el nodo con el valor a extraer y prev el padre de ese nodo
            if (find == null)
            {
                throw new Exception("No existe el elemento o el árbol está vacio");
            }
            // save es una referencia al item o valor a extraer
            E save = find.Item;

            // node es el nodo que va a quedar despues de la extracción
            BTNode<E> node = find;
            if (node.Right == null) // no hay subárbol derecho
            { // nodo con un descendiente (el izquierdo) o hoja
                node = node.Left;
            }
            else
            {
                if (node.Left == null)  // no hay subárbol izquierdo
                { // nodo con un descendiente (el derecho) o hoja
                    node = node.Right;
                }
                else
                { // nodo con dos descendientes
                    // last es el padre del menor de los mayores
                    BTNode<E> last = node;
                    // aplicar la técnica menor de los mayores
                    BTNode<E> temp = node.Right;  // (1) a la derecha (los mayores)
                    while (temp.Left != null)  // (2) busca el menor de los mayores
                    {
                        last = temp;
                        temp = temp.Left;
                    }

                    // temp es el menor de los mayores
                    // (3) realiza la copia de contenidos
                    node.Item = temp.Item;
                    // (4) ajusta los enlaces
                    if (last == node)
                    { // no hay subarbol izquierdo en el 1er nodo de la derecha 
                        last.Right = temp.Right;
                    }
                    else
                    { // last es el nodo anterior al menor de los mayores
                        last.Left = temp.Right;
                    }
                    temp.Right = null;
                }
            }
            // (5) ajustar todo el arbol
            if (find == this.Root)
            {
                this.Root = node;
            }
            else
            {
                if (prev.Left == find)
                {
                    prev.Left = node;
                }
                else
                {
                    prev.Right = node;
                }
            }
            return save;
        }


        /// <summary>
        /// Extrae el elemento del árbol binario de busqueda
        /// implementa la técnica de mayor de los menores
        /// implementa la técnica de sustitución o copia
        /// </summary>
        /// <param name="item">Elemento a extraer</param>
        protected virtual E RemoveByCopy_MayorDeLosMenores(E item)
        {
            BTNode<E> find = this.Root, prev = null;
            while ((find != null) && (!find.Item.Equals(item)))
            { // búsqueda iterativa del nodo recordando al nodo padre
                prev = find;
                if (item.CompareTo(find.Item) < 0)
                {
                    find = find.Left;
                }
                else
                {
                    find = find.Right;
                }
            }
            // find es el nodo con el valor a extraer y prev el padre de ese nodo
            if (find == null)
            {
                throw new Exception("No existe el elemento o el árbol está vacio");
            }
            // save es una referencia al item o valor a extraer
            E save = find.Item;

            // node es el nodo que va a quedar despues de la extracción
            BTNode<E> node = find;
            if (node.Right == null) // no hay subárbol derecho
            { // nodo con un descendiente (el izquierdo) o hoja
                node = node.Left;
            }
            else
            {
                if (node.Left == null)  // no hay subárbol izquierdo
                { // nodo con un descendiente (el derecho) o hoja
                    node = node.Right;
                }
                else
                { // nodo con dos descendientes
                    // last es el padre del menor de los mayores
                    BTNode<E> last = node;
                    // aplicar la técnica mayor de los menores
                    BTNode<E> temp = node.Left;  // (1) a la izquierda (los menores)
                    while (temp.Right != null)  // (2) busca el mayor de los menores
                    {
                        last = temp;
                        temp = temp.Right;
                    }

                    // temp es el mayor de los menores
                    // (3) realiza la copia de contenidos
                    node.Item = temp.Item;
                    // (4) ajusta los enlaces
                    if (last == node)
                    { // no hay subarbol derecho en el 1er nodo de la izquierda
                        last.Left = temp.Left;
                    }
                    else
                    { // last es el nodo anterior al mayor de los menores
                        last.Right = temp.Left;
                    }
                    temp.Left = null;
                }
            }
            // (5) ajustar todo el arbol
            if (find == this.Root)
            {
                this.Root = node;
            }
            else
            {
                if (prev.Left == find)
                {
                    prev.Left = node;
                }
                else
                {
                    prev.Right = node;
                }
            }
            return save;
        }


        /// <summary>
        /// Extrae el elemento del árbol binario de busqueda
        /// implementa la técnica de menor de los mayores
        /// implementa la técnica de fusión
        /// </summary>
        /// <param name="item">Elemento a extraer</param>
        protected virtual E RemoveByFusion(E item)
        {
            BTNode<E> find = this.Root, prev = null;
            while ((find != null) && (!find.Item.Equals(item)))
            { // búsqueda iterativa del nodo recordando al nodo padre
                prev = find;
                if (item.CompareTo(find.Item) < 0)
                {
                    find = find.Left;
                }
                else
                {
                    find = find.Right;
                }
            }
            // find es el nodo con el valor a extraer y prev el padre de ese nodo
            if (find == null)
            {
                throw new Exception("No existe el elemento o el árbol está vacio");
            }

            // node es el nodo que va a quedar despues de la extracción
            BTNode<E> node = find;

            if (node.Right == null) // no hay subárbol derecho
            { // nodo con un descendiente (el izquierdo) o hoja
                node = node.Left;
            }
            else
            {
                if (node.Left == null)  // no hay subárbol izquierdo
                { // nodo con un descendiente (el derecho) o hoja
                    node = node.Right;
                }
                else
                { // nodo con dos descendientes
                    // aplicar la técnica menor de los mayores
                    BTNode<E> temp = node.Right;  // (1) a la derecha (los mayores)
                    while (temp.Left != null)  // (2) busca el menor de los mayores
                    {
                        temp = temp.Left;
                    }
                    // (3) conecta el subárbol izquierdo del nodo que se retira
                    temp.Left = node.Left;
                    // (4) desconectar el nodo (queda en find)
                    node = node.Right;
                }
            }
            // (5) ajustar todo el arbol
            if (find == this.Root)
            {
                this.Root = node;
            }
            else
            {
                if (prev.Left == find)
                {
                    prev.Left = node;
                }
                else
                {
                    prev.Right = node;
                }
            }
            find.Left = find.Right = null;
            return find.Item;
        }
        

        #endregion
    }
}
