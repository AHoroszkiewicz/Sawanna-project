using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyena : Mammal
{
    public override AnimalTypes AnimalType => AnimalTypes.hyena;

    private void move()
    {
        if (!nextNode.isOccupied)
        {
            transform.position = nextNode.transform.position;
            currentNode.isOccupied = false;
            nextNode.isOccupied = true;
            Debug.Log("The Hyena moves from " + currentNode + " to " + nextNode);
            previousNode = currentNode;
            currentNode = nextNode;
            nextNode = null;
        }
        else
        {
            currentNode.isOccupied = true;
            Debug.Log("The Hyena waits at " + currentNode + " to enter " + nextNode);
        }
    }

    override public void Move()
    {
        if (previousNode == null)
        {
            previousNode = currentNode;
        }

        List<Node> listOfValidNodes = new List<Node>();
        // Prioritize continuing previous move
        if (nextNode == null)
        {
            // Search connected nodes for next unoccipied hyena or intersection nodes
            foreach (Node node in currentNode.ConnectedNodes)
            {
                if ((node.nodeType == Node.NodeType.hyena || node.nodeType == Node.NodeType.intersection) && node != previousNode)
                {
                    listOfValidNodes.Add(node);
                }
            }
            if (listOfValidNodes.Count > 0)
            {
                // if available, select a node at random and move to it
                nextNode = listOfValidNodes[Random.Range(0, listOfValidNodes.Count)];
                move();
            }
            else
            {
                Debug.Log("No nodes available for " + this + " at " + currentNode);
            }
        }
        else
        {
            move();
        }
    }
}
