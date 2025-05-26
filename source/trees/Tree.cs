using System.Diagnostics;
using System.Text;

namespace Trees;

public abstract class Tree<TreeType> : ITree<TreeType>
{
    #region Constructor(s)
    public Tree() { }

    #endregion

    #region Classes
    public class Node<NodeType> : INode<NodeType>
    {
        public Node() { }

        #region Properties
        public INode<NodeType>[]? Children { get; set; }

        #endregion

        #region Methods
        public INode<NodeType> Copy()
        {
            INode<NodeType> source = this,
                            copy = new Node<NodeType>();

            if (source.Children is not null)
            {
                copy.Children = new INode<NodeType>[source.Children.Length];

                for (int i = 0; i < source.Children.Length; i++)
                    copy.Children[i] = source.Children[i].Copy();


            }

            return copy;

        }

        #endregion
    
    }

    #endregion

}
