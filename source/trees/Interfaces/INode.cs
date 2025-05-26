namespace Trees;

public interface INode<NodeType>
{
    public INode<NodeType>[]? Children { get; set; }

    /// <summary>
    /// Peforms a recursive deep copy of the node.
    /// </summary>
    /// <returns>A new node with identical copies of the source node's properties.</returns>
    public INode<NodeType> Copy();

}