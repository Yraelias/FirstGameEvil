using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<List<MapNode>> mapLevels = new List<List<MapNode>>();

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        // Niveau 1
        var level1 = new List<MapNode>
        {
            new MapNode(NodeType.Combat),
            new MapNode(NodeType.Combat)
        };

        // Niveau 2
        var level2 = new List<MapNode>
        {
            new MapNode(NodeType.Rest),
            new MapNode(NodeType.Shop),
            new MapNode(NodeType.Combat)
        };

        // Connexions
        foreach (var n1 in level1)
            foreach (var n2 in level2)
                n1.nextNodes.Add(n2);

        mapLevels.Add(level1);
        mapLevels.Add(level2);

        // Tu peux ajouter un niveau 3, etc.
    }
}
