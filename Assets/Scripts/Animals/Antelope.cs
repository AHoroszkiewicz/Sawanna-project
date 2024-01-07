using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antelope : Mammal
{
    public override AnimalTypes AnimalType => AnimalTypes.deer;

    private void move()
    {
        if (!nextNode.isOccupied)
        {
            transform.position = nextNode.transform.position;
            currentNode.isOccupied = false;
            nextNode.isOccupied = true;
            Debug.Log("The Antelope moves from " + currentNode + " to " + nextNode);
            previousNode = currentNode;
            currentNode = nextNode;
            nextNode = null;
        }
        else
        {
            currentNode.isOccupied = true;
            Debug.Log("The Antelope waits at " + currentNode + " to enter " + nextNode);
        }
    }

    override public void Move()
    {
        // Eat(); // Antelope grazes every turn. How much animal action during the movement should we put here?

        if (previousNode == null)
        {
            previousNode = currentNode;
        }

        List<Node> listOfValidNodes = new List<Node>();
        // Prioritize continuing previous move if available
        if (nextNode == null)
        {
            // Search connected nodes for next unoccipied antelope or intersection nodes
            foreach (Node node in currentNode.ConnectedNodes)
            {
                if ((node.nodeType == Node.NodeType.antelope || node.nodeType == Node.NodeType.intersection) && node != previousNode)
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
        }
        else
        {
            move();
        }
    }
}
