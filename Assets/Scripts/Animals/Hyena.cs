using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyena : Mammal
{
    private List<Node> pathToWaterhole;
    private List<Node> pathToHyenaNode;
    private bool isMovingToWaterhole = false;
    private bool isMovingToHyenaNode = false;

    override public void Move()
    {
        // If at waterhole drink and do nothing.
        if (IsDrinking && !isHungry)
        {
            Drink();
            return;
        }

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

        if (isThirsty && !isMovingToWaterhole && !isHungry)
        {
            pathToWaterhole = currentNode.GetPathToNearest(Node.NodeType.waterhole);
            if (pathToWaterhole == null)
            {
                Debug.Log("Nie znaleziono wezla 'Waterhole'");
                return;
            }
            isMovingToWaterhole = true;
        }

        if (!isHungry && !isThirsty && !isMovingToHyenaNode)
        {
            pathToHyenaNode = currentNode.GetPathToNearest(Node.NodeType.hyena);
            if (pathToHyenaNode == null)
            {
                Debug.Log("Nie znaleziono wez³a 'Hyena'");
                return;
            }
            isMovingToHyenaNode = true;
        }

        // Look through all connected nodes for a hyena or intersection node
        // TODO: Go outside the graveyard zone if hungry
        if (isMovingToWaterhole && !isHungry)
        {
            if (pathToWaterhole.Count > 0)
            {
                nextNode = pathToWaterhole[0];
                pathToWaterhole.RemoveAt(0);

            }
            if (pathToWaterhole.Count == 0)
            {
                isMovingToWaterhole = false;
                if (isThirsty)
                {
                    Drink(); // Drink at waterhole
                }
            }
        }
        else if (isMovingToHyenaNode && !isHungry && !isThirsty)
        {
            if (pathToHyenaNode.Count > 0)
            {
                nextNode = pathToHyenaNode[0];
                pathToHyenaNode.RemoveAt(0);
            }
            if (pathToHyenaNode.Count == 0)
            {
                isMovingToHyenaNode = false;
            }
        }
        else
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

            while (nextNode == null || nextNode == previousNode || !(nextNode.nodeType == Node.NodeType.hyena || nextNode.nodeType == Node.NodeType.intersection || nextNode.nodeType == Node.NodeType.special))
            {
                nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
            }
        }

        if (nextNode != null)
        {
            if (!isThirsty && !isHungry && !isMovingToHyenaNode)
            {
                Debug.Log("The Hyena " + Id + " rests at " + currentNode);
                return;
            }
            if (!nextNode.isOccupied || nextNode.nodeType == Node.NodeType.special || (nextNode.nodeType == Node.NodeType.waterhole && isThirsty))
            {
                if (nextNode.hasCarcass)
                {
                    nextNode.DestroyCarcass();
                    Eat();
                }
                Debug.Log("The Hyena moves from " + currentNode + " to " + nextNode);
                base.Move();
            }
            else
            {
                nextNode = null;
                Debug.Log("The Hyena waits at " + currentNode + " to enter " + nextNode);
            }
        }
        else
        {
            Debug.Log("nextNode is null");
        }
    }
}
