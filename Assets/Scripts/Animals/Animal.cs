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
    [SerializeField] private int respawnRate = 3;
    [SerializeField] private int respawnCooldown = 0;
    [SerializeField] private Node spawningNode;

    public int Id { get => id; set => id = value; }
    public int Age => age;
    public virtual AnimalTypes AnimalType => animalType;
    public bool IsAlive => isAlive; 
    public int MaxAge { get => maxAge; set => maxAge = value;}
    public Node CurrentNode { get => currentNode; set => currentNode = value; }
    public int MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public int RespawnRate { get => respawnRate; set => respawnRate = value; }

    private void Start()
    {
        spawningNode = currentNode;
    }

    // Everything that happens in a round
    virtual public void RoundAction()
    {
        if(isAlive)
        {
            AgeUp();
            if (age > maxAge)
            {
                Die();
                return;
            }
            for (int i = 0; i < movementSpeed; i++)
            {
                Move();
            }
        }
        else
        {
            Respawn();
        }

    }

    virtual public void AgeUp()
    {
        age++;
    }

    public void Die()
    {
        isAlive = false;
        currentNode.isOccupied = false;
        currentNode.occupyingObjects.Remove(gameObject);
        //GameController.Instance.SpawnCarcass(currentNode);
        gameObject.SetActive(false);
    }

    virtual public void Respawn()
    {
        if (respawnCooldown < respawnRate)
        {
            respawnCooldown++;
            return;
        }
        respawnCooldown = 0;
        isAlive = true;
        age = 0;
        currentNode = spawningNode;
        currentNode.AddOccupyingObject(gameObject);
        transform.position = spawningNode.transform.position;
        gameObject.SetActive(true);
    }

    virtual public void Move()
    {
        currentNode.RemoveOccupyingObject(gameObject);
        nextNode.AddOccupyingObject(gameObject);

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
