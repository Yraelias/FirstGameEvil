using System.Collections.Generic;

public enum NodeType { Combat, Rest, Shop, Event }

public class MapNode
{
    public NodeType type;
    public List<MapNode> nextNodes;

    public MapNode(NodeType type)
    {
        this.type = type;
        nextNodes = new List<MapNode>();
    }
}