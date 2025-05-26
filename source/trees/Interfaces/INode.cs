namespace Trees;

public interface INode<NodeType>
{
    public NodeType Data { get; set; }
    public INode<NodeType>[]? Children { get; set; }

}