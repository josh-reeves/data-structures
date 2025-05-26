namespace Trees;

public class BinarySearchTree<TreeType> : Tree<TreeType>
{
    private INode<TreeType>? root;

    #region Constructor(s)
    public BinarySearchTree()
    {
        ChildrenPerNode = 2;

    }

    #endregion

    public void Add(TreeType value)
    {
        if (root is null)
        {
            root = new Node<TreeType>(value)
            {
                Children = new Node<TreeType>[ChildrenPerNode]

            };

            return;

        }

    }

}