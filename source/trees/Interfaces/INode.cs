namespace Trees;

public interface INode<NodeType>
{
    public NodeType Data { get; set; }

    public INode<NodeType>[] Children { get; set; }

    public INode<NodeType> LeftChild { get; set; }

    public INode<NodeType> RightChild { get; set; }

    public INode<NodeType> Copy();

}