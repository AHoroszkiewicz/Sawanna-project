using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour, IAging, IMovement
{
    [SerializeField] private int id;
    [SerializeField] private int age;
    [SerializeField] private int movementSpeed { get; set; }
    [SerializeField] private bool isAlive;
    [SerializeField] private AnimalTypes animalType;
    public int maxAge;

    public int Id { get => id; set => id = value; }
    public int Age => age;
    public AnimalTypes AnimalType => animalType;
    public bool IsAlive => isAlive; 

    public void AgeUp()
    {
        age++;
    }

    public void Die()
    {
        isAlive = false;
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
