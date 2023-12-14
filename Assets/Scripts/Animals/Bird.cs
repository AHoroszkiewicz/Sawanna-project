using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal, IEating
{
    [SerializeField] private int Altitude { get; set; }
    [SerializeField] private bool IsHungry { get; set; }
    [SerializeField] private int HungerLevel { get; set; }

    override public void Move()
    {
        Debug.Log("The birb flies");
    }
    public void Eat()
    {
        Debug.Log("The birb eats a snake");
    }
    public void MakeNest()
    {
        Debug.Log("The birb makes a nest in a tree");
    }
}
