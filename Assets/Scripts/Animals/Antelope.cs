using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antelope : Mammal
{
    override public void Move()
    {
        if (currentNode == null)
        {
            Debug.Log("currentNode is null");
            return;
        }
        Debug.Log("The Antelope moves");
    }

}
