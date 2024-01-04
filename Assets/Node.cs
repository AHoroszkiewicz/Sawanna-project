using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private List<Node> connectedNodes = new List<Node>();
    [SerializeField] private NodeType nodeType = NodeType.none;
    [SerializeField] private bool isOccupied = false; 

    public List<Node> ConnectedNodes
    {
        get { return connectedNodes; }
    }

    public bool IsOccupied 
    {
        get { return isOccupied; }
    }

    public enum NodeType
    {
        none = 0,
        lion = 1,
        antelope = 2,
        bird = 3,
        hyena = 4,
        snake = 5,
    }

    // Sprawdza, czy node jest wolny
    public bool IsNodeFree()
    {
        bool isFree = !isOccupied;
        Debug.Log($"Node is free: {isFree}");
        return isFree;
    }

    // Sprawdza, czy konkretne zwierze moze wejsc na ten node
    public bool CanAnimalEnter(NodeType animal)
    {
        bool canEnter = !isOccupied;
        Debug.Log($"Can animal enter: {canEnter}");
        return canEnter;
    }
}
