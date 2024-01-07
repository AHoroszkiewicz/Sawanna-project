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
        base.Move();
        Debug.Log("The Lion moves");
    }

    // Lion rests a a Lions Rock
    public void Rest()
    {
        Debug.Log("The Lion rests");
    }
}
