using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour, IAging, IMovement
{
    [SerializeField] private int id;
    [SerializeField] private int age = 0;
    [SerializeField] private int movementSpeed = 1;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private AnimalTypes animalType;
    [SerializeField] private int maxAge = 100;
    [SerializeField] public Node currentNode;
    [SerializeField] public Node previousNode;
    [SerializeField] public Node nextNode = null;

    public int Id { get => id; set => id = value; }
    public int Age => age;
    public int MovementSpeed => movementSpeed;
    public virtual AnimalTypes AnimalType => animalType;
    public bool IsAlive => isAlive; 
    public int MaxAge { get => maxAge; set => maxAge = value;}
    public Node CurrentNode { get => currentNode; set => currentNode = value; }

    public void AgeUp()
    {
        age++;
    }

    public void Die()
    {
        isAlive = false;
        currentNode.isOccupied = false;
        currentNode.occupyingObjects.Remove(gameObject);
        GameController.Instance.SpawnCarcass(currentNode);
        Destroy(this.gameObject);
    }

    virtual public void Move()
    {
        currentNode.occupyingObjects.Remove(gameObject);
        currentNode.isOccupied = false;

        nextNode.occupyingObjects.Add(gameObject);
        nextNode.isOccupied = true;

        transform.position = nextNode.transform.position;
        previousNode = currentNode;
        currentNode = nextNode;
        nextNode = null;
    }

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
