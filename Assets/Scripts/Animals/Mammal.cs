using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mammal : Animal, IEating, IDrinking
{
    [SerializeField] public bool isHungry => hungerLevel > hungerTreshhold;
    [SerializeField] private int hungerTreshhold = 80;
    [SerializeField] private int feedingSpeed = 50; // hunger reduction per round
    [SerializeField] private int hungerLevel = 0; // 100 is max 0 is none
    [SerializeField] private int hungerRate = 10; // hunger increase per round

    [SerializeField] public bool isThirsty => thirstLevel > thirstThreshold;
    [SerializeField] private int thirstThreshold = 70; 
    [SerializeField] private int drinkingSpeed = 50; // thirst reduction per round
    [SerializeField] private int thirstLevel = 0; // 100 is max 0 is none
    [SerializeField] private int thirstRate = 10; // thirst increase per round
    [SerializeField] private bool isDrinking = false;

    public bool IsDrinking => isDrinking;

    override public void AgeUp()
    {
        base.AgeUp();
        hungerLevel += hungerRate;
        thirstLevel += thirstRate;
    }

    override public void Move()
    {
        base.Move();
        isDrinking = false;
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
    virtual public void Eat()
    {
        // Debug.Log("The " + AnimalType + " eats");
        if (isHungry)
        {
            hungerLevel -= feedingSpeed;
        }

    }
}

