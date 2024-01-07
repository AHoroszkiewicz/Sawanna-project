using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private List<Node> connectedNodes = new List<Node>();
    [SerializeField] private NodeType nodeType = NodeType.none;

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
                case NodeType.bird:
                    Gizmos.color = Color.blue;
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

    public enum NodeType
    {
        none = 0,
        lion = 1,
        antelope = 2,
        bird = 3,
        hyena = 4,
        snake = 5,
    }
}
