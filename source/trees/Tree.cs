using System.Diagnostics;
using System.Text;

namespace Trees;

public abstract class Tree<TreeType> : ITree<TreeType>
{
    #region Constructor(s)
    public Tree() { }

    #endregion
    
    #region Properties
    protected uint ChildrenPerNode { get; set; }

    #endregion

    #region Classes
    public class Node<NodeType> : INode<NodeType>
    {
        public Node(NodeType data)
        {
            Data = data;

        }

        #region Properties
        public NodeType Data { get; set; }

        /* There may be some concerns here regarding the efficiency of arrays as an underlying data structure.
         *  Need too look into that. For now this will act as a proof of concept. 
         *  (maybe I should use a hash set/table?)*/
        public INode<NodeType>[]? Children { get; set; } 

        #endregion

        #region Methods
        public INode<NodeType> Copy()
        {
            INode<NodeType> source = this,
                            copy = new Node<NodeType>(source.Data);
            
            if (source.Children is not null)
            {
                copy.Children = new INode<NodeType>[source.Children.Length];

                for (int i = 0; i < source.Children.Length; i++)
                    copy.Children[i] = ((Node<NodeType>)source.Children[i]).Copy();

            }

            return copy;

        }

        #endregion

    }

    #endregion

}
