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

        if (!nextNode.isOccupied)
        {
            base.Move();
            Debug.Log("The Snake slithers from " + currentNode + " to " + nextNode);
        }
        else
        {
            // TODO: If has enough venom and the node is occupied by a mammal, try hunting it. Move if successful, wait if not.
            Debug.Log("The Snake waits at " + currentNode + " to enter " + nextNode);
        }
        venomLevel += venomRegenRate;
    }


    public void Bite()
    {
        Debug.Log("The snake bites");
        venomLevel -= venomPerBite;
    }
}
