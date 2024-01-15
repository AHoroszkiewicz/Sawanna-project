using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Mammal
{
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
        // Look through all connected nodes for a lion, intersection, or special node
        while (nextNode == null || nextNode == previousNode || !(nextNode.nodeType == Node.NodeType.lion || nextNode.nodeType == Node.NodeType.intersection || nextNode.nodeType == Node.NodeType.special))
        {
            nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
        }
        if (!nextNode.isOccupied || nextNode.nodeType == Node.NodeType.special)
        {
            base.Move();
            Debug.Log("The Lion moves from " + currentNode + " to " + nextNode);
        }
        else
        {
            Debug.Log("The Lion waits at " + currentNode + " to enter " + nextNode);
        }
    }
    // Lion rests a a Lions Rock
    public void Rest()
    {
        Debug.Log("The Lion rests");
    }
}
