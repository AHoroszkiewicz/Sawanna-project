using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : IAging, IMovement
{
    [SerializeField] private int ID
    [SerializeField] private int Age
    [SerializeField] private int MovementSpeed { get; set; }
    [SerializeField] private bool IsAlive { get; set; }
    [SerializeField] private AnimalTypes animalType;
    public int maxAge;

    public int Id => id;
    public int Age => age;
    public AnimalTypes AnimalType => animalType;

    public void AgeUp()
    {
        Age++;
    }

    void Die()
    {
        IsAlive = false;
    }

    public abstract void Move();

    public enum AnimalTypes
    {
        none = 0,
        lion = 1,
        deer = 2,
        bird = 3,
        hyena = 4,
        snake = 5,
    }
}
