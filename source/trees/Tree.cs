namespace Trees;

public abstract class Tree<TreeType> : ITree<TreeType>
{
    #region Constructor(s)
    public Tree() { }

    #endregion

    #region Classes
    public class Node<NodeType> : INode<NodeType>
    {
        #region Constructor(s)
        public Node(NodeType data)
        {
            Data = data;

        }

        #endregion

        #region Properties
        public NodeType Data { get; set; }

        public INode<NodeType>[]? Children { get; set; }

        public INode<NodeType>? LeftChild { get => Children?[0]; }

        public INode<NodeType>? RightChild { get => Children?[Children.Length - 1]; }

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
