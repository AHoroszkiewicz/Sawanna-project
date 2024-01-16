using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Mammal
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

        // Je�li lew jest spragniony i nie jest ju� w drodze do w�z�a "Waterhole", szuka najbli�szego w�z�a "Waterhole"
        if (isThirsty && !isMovingToWaterhole)
        {
            pathToWaterhole = currentNode.GetPathToNearestWaterhole();
            if (pathToWaterhole == null)
            {
                Debug.Log("Nie znaleziono w�z�a 'Waterhole'");
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

            // Stw�rz now� list� w�z��w, kt�ra nie zawiera w�z��w "Waterhole"
            List<Node> nonWaterholeNodes = new List<Node>();
            foreach (Node node in currentNode.ConnectedNodes)
            {
                if (node.nodeType != Node.NodeType.waterhole)
                {
                    nonWaterholeNodes.Add(node);
                }
            }

            // Je�li wszystkie po��czone w�z�y to w�z�y "Waterhole", u�yj oryginalnej listy
            if (nonWaterholeNodes.Count == 0)
            {
                nonWaterholeNodes = currentNode.ConnectedNodes;
            }

            // Wybierz nextNode z listy nonWaterholeNodes
            while (nextNode == null || nextNode == previousNode || !(nextNode.nodeType == Node.NodeType.lion || nextNode.nodeType == Node.NodeType.intersection || nextNode.nodeType == Node.NodeType.special))
            {
                nextNode = nonWaterholeNodes[Random.Range(0, nonWaterholeNodes.Count)];
            }
        }

        if (nextNode != null)
        {
            if ((!nextNode.isOccupied && (nextNode.nodeType != Node.NodeType.special || nextNode.nodeType == Node.NodeType.special)) || (nextNode.nodeType == Node.NodeType.waterhole && isThirsty))
            {
                base.Move();
                Debug.Log("The Lion moves from " + currentNode + " to " + nextNode);
            }
            else
            {
                Debug.Log("The Lion waits at " + currentNode + " to enter " + nextNode);
                nextNode = null;
            }
        }
        else
        {
            Debug.Log("nextNode is null");
        }
    }

    // Lion rests a a Lions Rock
    public void Rest()
    {
        Debug.Log("The Lion rests");
    }
}
