using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private int age;
    [SerializeField] private AnimalTypes animalType;
    public int maxAge;

    public int Id => id;
    public int Age => age;
    public AnimalTypes AnimalType => animalType;

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
