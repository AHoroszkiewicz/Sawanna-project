using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal, IEating
{
    [SerializeField] private int altitude { get; set; }
    [SerializeField] private bool isHungry { get; set; }
    [SerializeField] private int hungerTreshhold { get; set; }
    [SerializeField] private int feedingSpeed { get; set; }
    [SerializeField] private int hungerLevel { get; set; } // 100 is max 0 is none

    public Bird()
    {
        hungerLevel = 0;
        hungerTreshhold = 50;
        feedingSpeed = 10;
        isHungry = false;
    }

    override public void Move()
    {
        Debug.Log("The birb flies");
    }
    public void Eat()
    {
        Debug.Log("The birb eats a snake");
        if (isHungry)
        {
            hungerLevel -= feedingSpeed;
        }
        if (hungerLevel < hungerTreshhold)
        {
            isHungry = false;
        }
    }
    public void MakeNest()
    {
        Debug.Log("The birb makes a nest in a tree");
    }
}
