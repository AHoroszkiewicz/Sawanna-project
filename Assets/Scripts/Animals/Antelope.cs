using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antelope : Mammal
{
    public override AnimalTypes AnimalType => AnimalTypes.deer;

    override public void Move()
    {
        if (CurrentNode == null)
        {
            Debug.Log("currentNode is null");
            return;
        }
        if (CurrentNode.ConnectedNodes.Count == 0)
        {
            Debug.Log("currentNode has no connected nodes");
            return;
        }

        Eat(); // Start each round with grazing

        // Look through all connected nodes for an antelope or intersection node
        // TODO: If thirsty go to waterhole
        while (nextNode == null || nextNode == previousNode || !(nextNode.nodeType == Node.NodeType.antelope || nextNode.nodeType == Node.NodeType.intersection))
        {
            nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
            // Debug.Log("Antelope searching for next node"); // debug
        }

        if (!nextNode.isOccupied)
        {
            Debug.Log("The Antelope " + Id + " moves from " + currentNode + " to " + nextNode);
            base.Move();
        }
        else
        {
            Debug.Log("The Antelope " + Id + " waits at " + currentNode + " to enter " + nextNode);
        }
    }
}
