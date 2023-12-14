using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Mammal
{
    override public void Move()
    {
        Debug.Log("The Lion moves");
    }
    override public void Eat()
    {
        Debug.Log("The Lion eats");
    }
    public void Rest()
    {
        Debug.Log("The Lion rests");
    }
}
