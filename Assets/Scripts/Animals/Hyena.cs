using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyena : Mammal
{
    override public void Move()
    {
        if (currentNode == null)
        {
            Debug.Log("currentNode is null");
            return;
        }
        Debug.Log("The Hyena moves");
    }

}
