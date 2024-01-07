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
    [SerializeField] private Node currentNode;
    [SerializeField] private int maxAge = 100;
    private Node previousNode;

    public int Id { get => id; set => id = value; }
    public int Age => age;
    public AnimalTypes AnimalType => animalType;
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
    }

    virtual public void Move()
    {
        Node nextNode = null;
        while (nextNode == null || nextNode == previousNode)
        {
            nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
        }
        transform.position = nextNode.transform.position;
        previousNode = currentNode;
        currentNode = nextNode;
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
