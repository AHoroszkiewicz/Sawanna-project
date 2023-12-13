using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mammal : Animal
{
    [SerializeField] private int ID { get; set; }
    [SerializeField] private bool IsHungry { get; set; }
    [SerializeField] private int HungerLevel { get; set; }

    override public void Move()
    {
        Debug.Log("The Mammal moves");
    }
}

