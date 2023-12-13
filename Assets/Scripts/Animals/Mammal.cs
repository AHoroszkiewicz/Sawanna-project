using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mammal : Animal
{
    override public void Move()
    {
        Debug.Log("The Mammal moves");
    }
}

