using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antelope : Mammal
{
    override public void Move()
    {
        Debug.Log("The Antelope moves");
    }
    override public void Eat()
    {
        Debug.Log("The Antelope eats");
    }
}