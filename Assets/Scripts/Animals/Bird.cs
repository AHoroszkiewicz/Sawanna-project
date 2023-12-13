using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal
{
    [SerializeField] private int Altitude { get; set; }
    [SerializeField] private bool isHungry { get; set; }
    [SerializeField] private int HungerLevel { get; set; }

    override public void Move()
    {
        Debug.Log("The birb flies");
    }
}
