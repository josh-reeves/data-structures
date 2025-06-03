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
    public void Insert(TreeType value)
    {
        if (root is null)
        {
            root = new Node<TreeType>(value, childrenPerNode);

            return;

        }

        INode<TreeType> node = root;

        // This is gross and I feel like there has to be a better non-recursive approach, but it does work.
        while (true)
        {
            if (comparer.Compare(value, node.Data) < 0)
                if (node.LeftChild is null)
                {
                    node.LeftChild = new Node<TreeType>(value, childrenPerNode);

                    break;

                }
                else
                    node = node.LeftChild;

            if (comparer.Compare(value, node.Data) > 0)
                if (node.RightChild is null)
                {
                    node.RightChild = new Node<TreeType>(value, childrenPerNode);

                    break;

                }
                else
                    node = node.RightChild;

        }

    }

    public void Insert(TreeType[] values)
    {
        foreach (TreeType value in values)
            RecursiveInsert(value);

    }

    public void RecursiveInsert(TreeType value, INode<TreeType>? node = null)
    {
        root ??= new Node<TreeType>(value, childrenPerNode);

        node ??= root;

        if (comparer.Compare(value, node.Data) < 0)
            if (node.LeftChild is null)
                node.LeftChild = new Node<TreeType>(value, childrenPerNode);
            else
                RecursiveInsert(value, node.LeftChild);

        if (comparer.Compare(value, node.Data) > 0)
            if (node.RightChild is null)
                node.RightChild = new Node<TreeType>(value, childrenPerNode);
            else
                RecursiveInsert(value, node.RightChild);

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
