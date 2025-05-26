namespace Trees;

public class BinarySearchTree<TreeType> : Tree<TreeType>
{
    private INode<TreeType> template,
                            root;


    #region Constructor(s)
    public BinarySearchTree()
    {
        template = new Node<TreeType>
        {
            Children = new INode<TreeType>[2]

        };

        root = template.Copy();

    }

    #endregion

}