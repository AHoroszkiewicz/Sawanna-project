using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mammal : Animal, IEating, IDrinking
{
    [SerializeField] private bool isHungry { get; set; }
    [SerializeField] private int hungerTreshhold { get; set; }
    [SerializeField] private int hungerLevel { get; set; } // 100 is max 0 is none
    [SerializeField] private bool isThirsty { get; set; }
    [SerializeField] private int thirstThreshold { get; set; }
    [SerializeField] private int thirstLevel { get; set; } // 100 is max 0 is none

    public Mammal()
    {
        hungerLevel = 0;
        thirstLevel = 0;
        hungerTreshhold = 50;
        thirstThreshold = 70;
        isHungry = false;
        isThirsty = false;
    }

    override public void Move()
    {
        Debug.Log("The Mammal moves");
    }

    // Changes thirst level
    public void Drink()
    {
        Debug.Log("The Mammal drinks");
        if (isThirsty)
        {
            thirstLevel -= 10;
        }
        if (thirstLevel < thirstThreshold)
        {
            isThirsty = false;
        }
    }
    
    // Changes hunger level
    public void Eat()
    {
        Debug.Log("The Eats drinks");
        if (isHungry)
        {
            hungerLevel -= 10;
        }
        if (hungerLevel < hungerTreshhold)
        {
            isHungry = false;
        }
    }
}

