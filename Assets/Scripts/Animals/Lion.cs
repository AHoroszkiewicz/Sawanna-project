using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lion : Mammal
{
    private List<Node> pathToWaterhole;
    private List<Node> pathToLionNode;
    private bool isMovingToWaterhole = false;
    private bool isMovingToLionNode = false;    

    [SerializeField] private int huntingSuccessRate = 50; // 0-100
    public override AnimalTypes AnimalType => AnimalTypes.lion;

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
                Debug.Log("Nie znaleziono wez�a 'Waterhole'");
                return;
            }
            isMovingToWaterhole = true;
        }

        if (!isHungry && !isThirsty && !isMovingToLionNode)
        {
            pathToLionNode = currentNode.GetPathToNearest(Node.NodeType.lion);
            if (pathToLionNode == null)
            {
                Debug.Log("Nie znaleziono wez�a 'Lion'");
                return;
            }
            isMovingToLionNode = true;
        }

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
        else if(isMovingToLionNode && !isHungry && !isThirsty)
        {
            if (pathToLionNode.Count > 0)
            {
                nextNode = pathToLionNode[0];
                pathToLionNode.RemoveAt(0);
            }
            if (pathToLionNode.Count == 0)
            {
                isMovingToLionNode = false;
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
            //List<Node> nonWaterholeNodes = new List<Node>();
            //foreach (Node node in currentNode.ConnectedNodes)
            //{
            //    if (node.nodeType != Node.NodeType.waterhole)
            //    {
            //        nonWaterholeNodes.Add(node);
            //    }
            //}

            //// Je�li wszystkie po��czone w�z�y to w�z�y "Waterhole", u�yj oryginalnej listy
            //if (nonWaterholeNodes.Count == 0)
            //{
            //    nonWaterholeNodes = currentNode.ConnectedNodes;
            //}

            // Look through all connected nodes for a lion or intersection node
            while (nextNode == null || nextNode == previousNode || !(nextNode.nodeType == Node.NodeType.lion || nextNode.nodeType == Node.NodeType.intersection || nextNode.nodeType == Node.NodeType.special))
            {
                nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
                // Debug.Log("Lion searching for next node"); // debug
            }
        }

        if (nextNode != null)
        {
            if (!isThirsty && !isHungry && !isMovingToLionNode)
            {
                Rest();
                return;
            }
            if (!nextNode.isOccupied || nextNode.nodeType == Node.NodeType.waterhole)
            {
                Debug.Log("The Lion " + Id + " moves from " + currentNode + " to " + nextNode);
                base.Move();
            }
            else
            {
                var antelope = nextNode.occupyingObjects.Find(x => x.GetComponent<Antelope>() != null);
                if (antelope != null)
                {
                    if (Random.Range(0, 100) > huntingSuccessRate)
                    {
                        Debug.Log("The Lion " + Id + " hunts successfully at " + nextNode + ". Antelope " + antelope.GetComponent<Antelope>().Id + " dies.");
                        antelope.GetComponent<Antelope>().Die();
                        base.Move();
                        Eat();
                        return;
                    }
                    else
                    {
                        Debug.Log("The Lion " + Id + " failed to hunt at " + nextNode);
                        return;
                    }
                }
                Debug.Log("The Lion " + Id + " waits at " + currentNode + " to enter " + nextNode + ". Occupied by: " + nextNode.occupyingObjects[0]);
                nextNode = null;
            }
        }
        else
        {
            Debug.Log("nextNode is null");
        }
    }

    // Lion rests at Lions Rock
    public void Rest()
    {
        Debug.Log("The Lion " + Id + " rests");
    }

    override public void Eat()
    {
        base.Eat();
        if (!isHungry)
        {
         GameController.Instance.SpawnCarcass(nextNode);
        }
    }
}
