using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Animal
{
    [SerializeField] private int venomLevel = 100;
    [SerializeField] private int venomPerBite = 50;
    [SerializeField] private int venomRegenRate = 5;

    public int VenomLevel => venomLevel;
    public int VenomPerBite => venomPerBite;
    public int VenomRegenRate { get => venomRegenRate; set => venomRegenRate = value;}

    override public void Respawn()
    {
        base.Respawn();
        venomLevel = 100;
    }

    public override void AgeUp()
    {
        base.AgeUp();
        venomLevel += venomRegenRate;
    }

    public override void Move()
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
        // Look through all connected nodes for a snake or intersection node
        while (nextNode == null || nextNode == previousNode || !(nextNode.nodeType == Node.NodeType.snake || nextNode.nodeType == Node.NodeType.intersection))
        {
            nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
        }

        if (nextNode.isOccupied && venomLevel > 5 && nextNode.nodeType!=Node.NodeType.waterhole)
        {
            var mammal = nextNode.occupyingObjects.Find(x => x.GetComponent<Mammal>() != null);
            if (mammal != null)
            {
                Bite(mammal.GetComponent<Mammal>());
            }
        }
        else if (nextNode.isOccupied)
        {
            Debug.Log("The Snake waits at " + currentNode + " to enter " + nextNode);
        }
        else
        {
            Debug.Log("The Snake " + Id + " slithers from " + currentNode + " to " + nextNode);
            base.Move();
        }
    }

    private void Bite(Mammal mammal)
    {
        Debug.Log("The Snake " + Id + " bites a Mammal " + mammal + " at " + nextNode + ". Mammal " + mammal.Id + " dies.");
        mammal.Die();
        venomLevel -= venomPerBite;
    }
}
