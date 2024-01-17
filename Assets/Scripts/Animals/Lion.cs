using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Mammal
{
    [SerializeField] private int huntingSuccessRate = 50; // 0-100
    public override AnimalTypes AnimalType => AnimalTypes.lion;

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
        // Look through all connected nodes for a lion or intersection node
        // TODO: if thirsty go to waterhole
        while (nextNode == null || nextNode == previousNode || !(nextNode.nodeType == Node.NodeType.lion || nextNode.nodeType == Node.NodeType.intersection))
        {
            nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
            // Debug.Log("Lion searching for next node"); // debug
        }
        if (!nextNode.isOccupied)
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
                    Debug.Log("The Lion " + Id + " hunts successfuly at " + nextNode + ". Antelope " + antelope.GetComponent<Antelope>().Id + " dies.");
                    antelope.GetComponent<Antelope>().Die();
                    base.Move();
                    Eat();
                    return;
                } else {
                    Debug.Log("The Lion " + Id + " failed to hunt at " + nextNode);
                    return;
                }
            }
            Debug.Log("The Lion " + Id + " waits at " + currentNode + " to enter " + nextNode + ". Occupied by: " + nextNode.occupyingObjects[0]);
        }
    }
    // Lion rests a a Lions Rock
    public void Rest()
    {
        Debug.Log("The Lion " + Id + "rests");
    }
}
