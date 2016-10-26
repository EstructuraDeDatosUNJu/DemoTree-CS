using System;
using System.Text;

namespace DemoBinaryTree
{
    /// <summary>
    /// Implementación de Árbol Binario
    /// </summary>
    /// <typeparam name="E">Tipo de dato del elemento que se referencia en cada nodo</typeparam>
    public class BinaryTree<E>
    {
        /// <summary>
        /// Mantiene la raíz del árbol
        /// </summary>
        private BTNode<E> root;
        protected virtual BTNode<E> Root
        {
            get { return this.root; }
            set { this.root = value; }
        }

        public virtual Boolean IsEmpty
        {
            get { return this.Root == null; }
        }

        /// <summary>
        /// Constructor por defecto con valor por defecto
        /// </summary>
        public BinaryTree(BTNode<E> root = null)
        {
            this.Root = root;
        }

        /// <summary>
        /// Constructor especializado, permite asignar 
        /// el valor del item de la raíz del árbol
        /// </summary>
        /// <param name="root">referencia al item de la raíz del árbol, puede ser null</param>
        public BinaryTree(E item = default(E)) : this(new BTNode<E>(item))
        { }

        /// <summary>
        /// Constructor especializado, permite asignar 
        /// el valor del item de la raíz del árbol y 
        /// los subárboles izquierdo y derecho
        /// </summary>
        /// <param name="root">referencia al item de la raíz del árbol, puede ser null</param>
        /// <param name="leftTree">referencia a un árbol que estará a la izquierda, puede ser null</param>
        /// <param name="rightTree">referencia a un árbol que estará a la derecha, puede ser null</param>
        public BinaryTree(E item, BinaryTree<E> leftTree = null, BinaryTree<E> rightTree = null)
        {
            this.Root = new BTNode<E>(item);
            if (leftTree != null)
            {
                this.Root.Left = leftTree.Root;
            }
            if (rightTree != null)
            {
                this.Root.Right = rightTree.Root;
            }
        }

        /// <summary>
        /// Devuelve el subárbol izquierdo si no esta vacío
        /// </summary>
        /// <returns>Referencia al subárbol izquierdo</returns>
        public BinaryTree<E> GetLeftSubTree()
        {
            if (IsEmpty)
            {
                throw new Exception("Árbol vacío");
            }
            return new BinaryTree<E>(Root.Left);
        }

        /// <summary>
        /// Devuelve el subárbol derecho si no esta vacío
        /// </summary>
        /// <returns>Referencia al subárbol derecho</returns>
        public BinaryTree<E> GetRightSubTree()
        {
            if (IsEmpty)
            {
                throw new Exception("Árbol vacío");
            }
            return new BinaryTree<E>(Root.Right);
        }

        /// <summary>
        /// Muestra la representación del árbol en forma de lista
        /// </summary>
        /// <returns>Cadena con la representación</returns>
        public override string ToString()
        {
            return ToString(this.Root);
        }
        /// <summary>
        /// Implementación recursiva para mostrar un árbol en forma de lista
        /// </summary>
        /// <param name="root">Nodo del árbol</param>
        /// <returns>Cadena con la representación</returns>
        protected string ToString(BTNode<E> root)
        {
            StringBuilder sb = new StringBuilder();
            //string s = string.Empty;
            if (root != null)
            {
                //s = root.Item.ToString();
                sb.Append(root.Item.ToString());
                if (root.Left != null)
                {
                    //s = s + " (" + ToString(root.Left);
                    sb.Append(" (" + ToString(root.Left));
                    if (root.Right != null)
                    {
                        //s = s + ", " + ToString(root.Right);
                        sb.Append(", " + ToString(root.Right));
                    }
                    //s = s + ")";
                    sb.Append(")");
                }
                else
                {
                    if (root.Right != null)
                    {
                        //s = s + " (, " + ToString(root.Right) + ")";
                        sb.Append(" (, " + ToString(root.Right) + ")");
                    }
                }
            }
            //return s;
            return sb.ToString(); ;
        }

        #region Comportamiento para recorrer un árbol
        /// <summary>
        /// Implementación del recorrido Pre Orden
        /// </summary>
        public virtual void PreOrder()
        {
            PreOrder(this.Root);
        }
        /// <summary>
        /// Implementación recursiva de Pre Orden
        /// </summary>
        /// <param name="root">Nodo a visitar</param>
        protected virtual void PreOrder(BTNode<E> root)
        {
            if (root != null)
            {
                root.Visit();
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }
        /// <summary>
        /// Implementación del recorrido En Orden
        /// </summary>
        public virtual void InOrder()
        {
            InOrder(this.Root);
        }
        /// <summary>
        /// Implementación recursiva de En Orden
        /// </summary>
        /// <param name="root">Nodo a visitar</param>
        protected virtual void InOrder(BTNode<E> root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                root.Visit();
                InOrder(root.Right);
            }
        }
        /// <summary>
        /// Implementación del recorrido Post Orden
        /// </summary>
        public virtual void PostOrder()
        {
            PostOrder(this.Root);
        }
        /// <summary>
        /// Implementación recursiva de Post Orden
        /// </summary>
        /// <param name="root">Nodo a visitar</param>
        protected virtual void PostOrder(BTNode<E> root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                root.Visit();
            }
        }

        /// <summary>
        /// Implementación del recorrido En Orden Descendente
        /// </summary>
        public virtual void InDescendingOrder()
        {
            InDescendingOrder(this.Root);
        }
        /// <summary>
        /// Implementación recursiva de En Orden Descendente
        /// </summary>
        /// <param name="root">Nodo a visitar</param>
        protected virtual void InDescendingOrder(BTNode<E> root)
        {
            if (root != null)
            {
                InDescendingOrder(root.Right);
                root.Visit();
                InDescendingOrder(root.Left);
            }
        }
        
        
        #endregion

        
        
        /// <summary>
        /// Cuenta la cantidad de nodos
        /// </summary>
        /// <returns>Cantidad de nodos</returns>
        public virtual int NodeCount()
        {
            return NodeCount(this.Root);
        }
        /// <summary>
        /// Cuenta recursivamente la cantidad de nodos
        /// </summary>
        /// <param name="root">Nodo a procesar</param>
        /// <returns>Cantidad de nodos</returns>
        protected virtual int NodeCount(BTNode<E> root)
        {
            if (root != null)
            {
                return 1 + NodeCount(root.Left) + NodeCount(root.Right);
            }
            return 0;
        }

        /// <summary>
        /// Cuenta la cantidad de hojas
        /// </summary>
        /// <returns>Cantidad de hojas</returns>
        public virtual int LeafCount()
        {
            return LeafCount(this.Root);
        }
        /// <summary>
        /// Cuenta recursivamente la cantidad de hojas
        /// </summary>
        /// <param name="root">Nodo a procesar</param>
        /// <returns>Cantidad de hojas</returns>
        protected virtual int LeafCount(BTNode<E> root)
        {
            if (root != null)
            {
                if ((root.Left == null) && (root.Right == null))
                {
                    return 1;
                }
                else
                {
                    return LeafCount(root.Left) + LeafCount(root.Right);
                }
            }
            return 0;
        }

        /// <summary>
        /// Cuenta la cantidad de nodos internos
        /// </summary>
        /// <returns>Cantidad de nodos internos</returns>
        public virtual int InternalNodeCount()
        {
            return InternalNodeCount(this.Root);
        }
        /// <summary>
        /// Cuenta recursivamente la cantidad de nodos internos
        /// </summary>
        /// <param name="root">Nodo a procesar</param>
        /// <returns>Cantidad de nodos internos</returns>
        protected virtual int InternalNodeCount(BTNode<E> root)
        {
            if (root != null)
            {
                if ((root.Left == null) && (root.Right == null))
                {
                    return 0;
                }
                else
                {
                    return 1 + LeafCount(root.Left) + LeafCount(root.Right);
                }
            }
            return 0;
        }

        /// <summary>
        /// Determina el máximo nivel
        /// </summary>
        /// <returns>Nro de nivel</returns>
        public virtual int MaxLevel()
        {
            if (!IsEmpty)
            {
                return MaxLevel(this.Root);
            }
            return -1;
        }
        /// <summary>
        /// Determina recursivamente el máximo nivel
        /// </summary>
        /// <param name="root">Nodo a procesar</param>
        /// <returns>Nro de nivel</returns>
        protected virtual int MaxLevel(BTNode<E> root)
        {
            if (root != null)
            {
                if ((root.Left != null) || (root.Right != null))
                {
                    int leftLevel = MaxLevel(root.Left);
                    int rightLevel = MaxLevel(root.Right);
                    return 1 + Math.Max(leftLevel, rightLevel);
                }
            }
            return 0;
        }

        /// <summary>
        /// Determina la altura
        /// </summary>
        /// <returns>Altura</returns>
        public virtual int Height()
        {
            return MaxLevel() + 1;
        }
    }
}
