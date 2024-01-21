using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antelope : Mammal
{
    private List<Node> pathToWaterhole;
    private bool isMovingToWaterhole = false;
    public override AnimalTypes AnimalType => AnimalTypes.deer;

    override public void Move()
    {
        // If at waterhole drink and do nothing.
        if (IsDrinking)
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

        if (isThirsty && !isMovingToWaterhole)
        {
            pathToWaterhole = currentNode.GetPathToNearestWaterhole();
            if (pathToWaterhole == null)
            {
                Debug.Log("Waterhole node not found");
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
            // Look through all connected nodes
            while (nextNode == null || nextNode == previousNode || !(nextNode.nodeType == Node.NodeType.antelope || nextNode.nodeType == Node.NodeType.intersection))
            {
                nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
                // Debug.Log("Antelope searching for next node"); // debug
            }
        }

        Eat(); // Graze at current node before moving

        if (nextNode != null)
        {
            if (!nextNode.isOccupied || (nextNode.nodeType == Node.NodeType.waterhole && isThirsty))
            {
                Debug.Log("The Antelope " + Id + " moves from " + currentNode + " to " + nextNode);
                base.Move();
            }
            else
            {
                Debug.Log("The Antelope " + Id + " waits at " + currentNode + " to enter " + nextNode);
                nextNode = null;
            }
        }
        else
        {
            Debug.Log("nextNode is null");
        }
    }
}
