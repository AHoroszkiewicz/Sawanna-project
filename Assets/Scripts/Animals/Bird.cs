using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Bird : Animal, IEating
{
    [SerializeField] private int altitude = 10;// ???

    [SerializeField] public bool isHungry => hungerLevel > hungerTreshhold;
    [SerializeField] private int hungerTreshhold = 80; // treshhold for hunger 
    [SerializeField] private int feedingSpeed = 25; // hunger reduction per round
    [SerializeField] private int hungerLevel = 0; // 100 is max 0 is none
    [SerializeField] private int hungerRate = 10; // hunger increase per round

    override public void Respawn()
    {
        base.Respawn();
        hungerLevel = 0;
    }

    override public void AgeUp()
    {
        base.AgeUp();
        hungerLevel += hungerRate;
    }

    override public void Move()
    {
        if (CurrentNode == null)
        {
            Debug.Log("currentNode is null");
            return;
        }
        if (CurrentNode.ConnectedNodes.Count == 0)
        {
            Debug.Log("currentNode has no connected nodes");
            return;
        }
        while (nextNode == null || nextNode == previousNode)
        {
            nextNode = currentNode.ConnectedNodes[Random.Range(0, currentNode.ConnectedNodes.Count)];
        }

        if (nextNode.isOccupied && nextNode.nodeType!=Node.NodeType.waterhole)
        {
            var snake = nextNode.occupyingObjects.Find(x => x.GetComponent<Snake>() != null);
            if (snake != null)
            {
                Debug.Log("The Bird " + Id + " eats a Snake " + snake.GetComponent<Snake>().Id + " at " + nextNode + ". Snake " + snake.GetComponent<Snake>().Id + " dies.");
                snake.GetComponent<Snake>().Die();
                Eat();
            }
        }
        Debug.Log("The Bird flies from " + currentNode + " to " + nextNode);
        base.Move();

        // 1 in a 10 chance to make a nest on a current node
        if (Random.Range(0, 10) == 0)
        {
            MakeNest();
        }
    }

    public void Eat()
    {
        // Debug.Log("The bird eats a snake");
        if (isHungry)
        {
            hungerLevel -= feedingSpeed;
        }
        else
        {
            GameController.Instance.SpawnCarcass(nextNode);
        }
    }

    public void MakeNest()
    {
        Debug.Log("The bird makes a hidden nest on a tree at "  + currentNode);
    }
}
