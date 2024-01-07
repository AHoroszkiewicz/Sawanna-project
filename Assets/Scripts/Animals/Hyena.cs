using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyena : Mammal
{
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
        // Look through all connected nodes for a hyena or intersection node
        // TODO: If thirsty go to waterhole // tutaj pasywnie czy w game controllerze aktywnie? xd
        // TODO: Go outside the graveyard zone if hungry
        while (nextNode == null || nextNode == previousNode || nextNode.nodeType != Node.NodeType.hyena || nextNode.nodeType != Node.NodeType.intersection)
        {
            nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
        }

        if (!nextNode.isOccupied)
        {
            base.Move();
            Debug.Log("The Hyena moves from " + currentNode + " to " + nextNode);
        }
        else
        {
            Debug.Log("The Hyena waits at " + currentNode + " to enter " + nextNode);
        }
    }
}
