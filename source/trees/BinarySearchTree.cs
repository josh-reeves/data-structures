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
    public void Add(TreeType value)
    {
        ref INode<TreeType>? current = ref root;

        while (current is not null)
        {
            if (comparer.Compare(value, current.Data) < 0)
                current = current.LeftChild;
            else if (comparer.Compare(value, current.Data) > 0)
                current = current.RightChild;

        }

        current = new Node<TreeType>(value)
        {
            Children = new Node<TreeType>[childrenPerNode]

        };

        return;

    }

    #endregion

}
