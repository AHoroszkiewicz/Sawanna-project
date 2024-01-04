using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Mammal
{
    override public void Move()
    {
        Node nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
        transform.position = nextNode.transform.position;
        Debug.Log("The Lion moves");
        currentNode = nextNode;
    }

    // Lion rests a a Lions Rock
    public void Rest()
    {
        Debug.Log("The Lion rests");
    }
}
