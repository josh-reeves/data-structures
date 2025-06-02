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
        public Node(NodeType data, int degree)
        {
            Data = data;

            Children = new Node<NodeType>[degree];

        }

        #endregion

        #region Properties
        public NodeType Data { get; set; }

        public INode<NodeType>[] Children { get; set; }

        public INode<NodeType> LeftChild { get => Children[0]; set => Children[0] = value; }

        public INode<NodeType> RightChild { get => Children[Children.Length - 1]; set => Children[Children.Length - 1] = value; }

        #endregion

        #region Methods
        public INode<NodeType> Copy()
        {
            INode<NodeType> source = this,
                            copy = new Node<NodeType>(source.Data, source.Children.Length);

            for (int i = 0; i < source.Children.Length; i++)
                if (Children[i] is not null)
                    copy.Children[i] = ((Node<NodeType>)source.Children[i]).Copy();

            return copy;

        }

        #endregion

    }

    #endregion

}
