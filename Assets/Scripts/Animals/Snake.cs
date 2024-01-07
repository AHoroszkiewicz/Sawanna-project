using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Animal
{
    [SerializeField] private int venomLevel = 100;
    [SerializeField] private int venomPerBite = 50;
    [SerializeField] private int venomRegenRate = 10;

    override public void Move()
    {
        Node nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
        transform.position = nextNode.transform.position;
        Debug.Log("The Snake slithers to " + currentNode);
        currentNode = nextNode;
        venomLevel += venomRegenRate;
    }
    public void Bite()
    {
        Debug.Log("The snake bites");
        venomLevel -= venomPerBite;
    }
}
