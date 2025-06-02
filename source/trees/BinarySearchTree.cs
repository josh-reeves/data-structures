using System.Runtime.CompilerServices;

namespace Trees;

public class BinarySearchTree<TreeType> : Tree<TreeType>
{
    #region Fields
    private const int childrenPerNode = 2;

    private Comparer<TreeType> comparer;
    private INode<TreeType>? root;

    #endregion

    #region Constructor(s)
    public BinarySearchTree()
    {
        comparer = Comparer<TreeType>.Default;

    }

    #endregion

    #region Methods
    public void Insert(TreeType value, INode<TreeType>? node = null)
    {
        root ??= new Node<TreeType>(value, childrenPerNode);

        node ??= root;

        if (comparer.Compare(value, node.Data) < 0)
            if (node.LeftChild is null)
                node.LeftChild = new Node<TreeType>(value, childrenPerNode);
            else
                Insert(value, node.LeftChild);

        if (comparer.Compare(value, node.Data) > 0)
            if (node.LeftChild is null)
                node.LeftChild = new Node<TreeType>(value, childrenPerNode);
            else
                Insert(value, node.LeftChild);


    }

    public void Insert(TreeType[] values)
    {
        foreach (TreeType value in values)
            Insert(value);

    }

    public void Print(INode<TreeType>? current = null)
    {
        current ??= root;

        if (current is null)
            return;
            
        Console.WriteLine(current.Data);

        if (current.LeftChild is not null)
            Print(current.LeftChild);

        if (current.RightChild is not null)
            Print(current.RightChild);

    }

    #endregion

}
