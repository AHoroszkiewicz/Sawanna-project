using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antelope : Mammal
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

            List<Node> nonSpecialNodes = new List<Node>();
            foreach (Node node in currentNode.ConnectedNodes)
            {
                if (node.nodeType != Node.NodeType.special)
                {
                    nonSpecialNodes.Add(node);
                }
            }

            if (nonSpecialNodes.Count == 0)
            {
                nonSpecialNodes = currentNode.ConnectedNodes;
            }

            while (nextNode == null || nextNode == previousNode || !(nextNode.nodeType == Node.NodeType.antelope || nextNode.nodeType == Node.NodeType.intersection))
            {
                nextNode = nonSpecialNodes[Random.Range(0, nonSpecialNodes.Count)];
            }
        }

        if (nextNode != null)
        {
            if (!nextNode.isOccupied || (nextNode.nodeType == Node.NodeType.waterhole && isThirsty))
            {
                base.Move();
                Debug.Log("The Antelope moves from " + currentNode + " to " + nextNode);
            }
            else
            {
                Debug.Log("The Antelope waits at " + currentNode + " to enter " + nextNode);
                nextNode = null;
            }
        }
        else
        {
            Debug.Log("nextNode is null");
        }
    }
}
