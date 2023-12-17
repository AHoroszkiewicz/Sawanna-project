using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mammal : Animal, IEating, IDrinking
{
    [SerializeField] public bool isHungry => hungerLevel > hungerTreshhold;
    [SerializeField] private int hungerTreshhold { get; set; }
    [SerializeField] private int feedingSpeed { get; set; }
    [SerializeField] private int hungerLevel { get; set; } // 100 is max 0 is none
    [SerializeField] private bool isThirsty => thirstLevel > thirstThreshold;
    [SerializeField] private int thirstThreshold { get; set; }
    [SerializeField] private int drinkingSpeed { get; set; }
    [SerializeField] private int thirstLevel { get; set; } // 100 is max 0 is none

    public Mammal()
    {
        hungerLevel = 0;
        thirstLevel = 0;
        hungerTreshhold = 50;
        thirstThreshold = 70;
        drinkingSpeed = 10;
        feedingSpeed = 10;

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
            thirstLevel -= drinkingSpeed;
        }

    }
    
    // Changes hunger level
    public void Eat()
    {
        Debug.Log("The Mammal drinks");
        if (isHungry)
        {
            hungerLevel -= feedingSpeed;
        }

    }
}

