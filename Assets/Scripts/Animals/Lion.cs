using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Mammal
{
    override public void Move()
    {
        Debug.Log("The Lion moves");
    }

    // Lion rests a a Lions Rock
    public void Rest()
    {
        Debug.Log("The Lion rests");
    }
}
