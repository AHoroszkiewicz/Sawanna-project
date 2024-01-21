using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mammal : Animal, IEating, IDrinking
{
    [SerializeField] public bool isHungry => hungerLevel > hungerTreshhold;
    [SerializeField] private int hungerTreshhold = 80;
    [SerializeField] private int feedingSpeed = 50; // hunger reduction per round
    [SerializeField] private int hungerLevel = 0; // 100 is max 0 is none

    [SerializeField] public bool isThirsty => thirstLevel > thirstThreshold;
    [SerializeField] private int thirstThreshold = 70; 
    [SerializeField] private int drinkingSpeed = 50; // thirst reduction per round
    [SerializeField] private int thirstLevel = 0; // 100 is max 0 is none
    [SerializeField] private bool isDrinking = false;

    public bool IsDrinking => isDrinking;

    override public void AgeUp()
    {
        base.AgeUp();
        hungerLevel += 10;
        thirstLevel += 10;
    }

    override public void Move()
    {
        base.Move();
    }

    override public void HungerUp()
    {
        base.HungerUp();
        hungerLevel++;
    }

    override public void ThirstUp()
    {
        base.ThirstUp();
        thirstLevel++;
    }

    override public void Respawn()
    {
        base.Respawn();
        hungerLevel = 0;
        thirstLevel = 0;
    }

    // Changes thirst level
    public void Drink()
    {
        isDrinking = true;
        thirstLevel -= drinkingSpeed;
        if (thirstLevel < 0)
        {
            isDrinking = false;
        }

    }
    
    // Changes hunger level
    public void Eat()
    {
        // Debug.Log("The " + AnimalType + " eats");
        if (isHungry)
        {
            hungerLevel -= feedingSpeed;
        }

    }
}

