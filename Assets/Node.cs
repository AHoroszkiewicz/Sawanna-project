using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private List<Node> connectedNodes = new List<Node>();
    [SerializeField] public NodeType nodeType = NodeType.none;
    public bool isOccupied = false;

    public List<Node> ConnectedNodes
    {
        get { return connectedNodes; }
    }

    public enum NodeType
    {
        none = 0,
        lion = 1,
        antelope = 2,
        bird = 3,
        hyena = 4,
        snake = 5,
        intersection = 6,
    }
}
