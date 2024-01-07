using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antelope : Mammal
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
        Debug.Log("The Antelope moves");
    }

}
