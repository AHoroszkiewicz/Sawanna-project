using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private List<Node> connectedNodes = new List<Node>();
    [SerializeField] public NodeType nodeType = NodeType.none;
    [SerializeField] public List<GameObject> occupyingObjects = new List<GameObject>();
    public bool isOccupied = false;
    public bool hasCarcass = false;

    public List<Node> ConnectedNodes
    {
        get { return connectedNodes; }
    }

    private void OnDrawGizmos()
    {
        foreach (Node node in connectedNodes)
        {
            switch (nodeType)
            {
                case NodeType.lion:
                    Gizmos.color = Color.red;
                    break;
                case NodeType.antelope:
                    Gizmos.color = Color.green;
                    break;
                case NodeType.hyena:
                    Gizmos.color = Color.yellow;
                    break;
                case NodeType.snake:
                    Gizmos.color = Color.magenta;
                    break;
                default:
                    Gizmos.color = Color.white;
                    break;
            }
            Gizmos.DrawLine(transform.position, node.transform.position);
        }
    }

    public void DestroyCarcass()
    {
        if (hasCarcass)
        {
            var carcass = occupyingObjects.Find(x => x.GetComponent<Carcass>() != null);
            hasCarcass = false;
            occupyingObjects.Remove(carcass);
            carcass.GetComponent<Carcass>().DestroyCarcass();
        }
    }

    public enum NodeType
    {
        none = 0,
        lion = 1,
        antelope = 2,
        hyena = 3,
        snake = 4,
        intersection = 5,
        special = 6,
        waterhole = 7,
    }

    // New method to add an object to the occupyingObjects list
    public void AddOccupyingObject(GameObject obj)
    {
        if (!occupyingObjects.Contains(obj))
        {
            occupyingObjects.Add(obj);
            if (nodeType != NodeType.special)
            {
                isOccupied = true;
            }
        }
    }

    public void RemoveOccupyingObject(GameObject obj)
    {
        if (occupyingObjects.Contains(obj))
        {
            occupyingObjects.Remove(obj);
            if (occupyingObjects.Count == 0)
            {
                isOccupied = false;
            }
        }
    }

    public List<Node> GetPathToNearestWaterhole()
    {
        Queue<Node> queue = new Queue<Node>();
        HashSet<Node> visited = new HashSet<Node>();
        Dictionary<Node, Node> previousNode = new Dictionary<Node, Node>();

        queue.Enqueue(this);
        visited.Add(this);

        while (queue.Count > 0)
        {
            Node currentNode = queue.Dequeue();
            if (currentNode.nodeType == NodeType.waterhole && currentNode.name == "Waterhole")
            {
                List<Node> path = new List<Node>();
                Node node = currentNode;
                while (node != this)
                {
                    path.Insert(0, node);
                    node = previousNode[node];
                }
                return path;
            }

            foreach (Node connectedNode in currentNode.ConnectedNodes)
            {
                if (!visited.Contains(connectedNode))
                {
                    queue.Enqueue(connectedNode);
                    visited.Add(connectedNode);
                    previousNode[connectedNode] = currentNode;
                }
            }
        }

        return null; // Zwraca null, jeœli nie znaleziono wêz³a "Waterhole"
    }
}
