using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyena : Mammal
{
    override public void Move()
    {
        Debug.Log("The Hyena moves");
    }
    override public void Eat()
    {
        Debug.Log("The Hyena eats a carcass");
    }
}
