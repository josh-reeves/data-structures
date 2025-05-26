namespace Trees;

public abstract class Tree<TreeType>
{
    #region Constructor(s)
    public Tree() { }

    #endregion

    #region Classes
    public class Node
    {
        public Node() { }

        #region Properties
        public Node[]? Children { get; set; }

        #endregion
        
    }

    #endregion

}
