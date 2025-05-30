namespace Trees;

public interface INode<NodeType>
{
    public NodeType Data { get; set; }

    public INode<NodeType>[]? Children { get; set; }

    public INode<NodeType>? LeftChild { get; }

    public INode<NodeType>? RightChild { get; }

}