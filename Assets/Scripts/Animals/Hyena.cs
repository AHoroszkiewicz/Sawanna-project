using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyena : Mammal
{
    private List<Node> pathToWaterhole;
    private bool isMovingToWaterhole = false;

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

        if (isThirsty && !isMovingToWaterhole)
        {
            pathToWaterhole = currentNode.GetPathToNearestWaterhole();
            if (pathToWaterhole == null)
            {
                Debug.Log("Nie znaleziono wêz³a 'Waterhole'");
                return;
            }
            isMovingToWaterhole = true;
        }

        if (isMovingToWaterhole)
        {
            if (pathToWaterhole.Count > 0)
            {
                nextNode = pathToWaterhole[0];
                pathToWaterhole.RemoveAt(0);
                if (pathToWaterhole.Count == 0)
                {
                    isMovingToWaterhole = false;
                }
            }
            else
            {
                isMovingToWaterhole = false;
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
            if (!nextNode.isOccupied || nextNode.nodeType == Node.NodeType.special || (nextNode.nodeType == Node.NodeType.waterhole && isThirsty))
            {
                base.Move();
                Debug.Log("The Hyena moves from " + currentNode + " to " + nextNode);
            }
            else
            {
                Debug.Log("The Hyena waits at " + currentNode + " to enter " + nextNode);
                nextNode = null;
            }
        }
        else
        {
            Debug.Log("nextNode is null");
        }
    }
}
