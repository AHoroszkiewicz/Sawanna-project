using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Bird : Animal, IEating
{
    [SerializeField] private int altitude { get; set; } // ???

    [SerializeField] public bool isHungry => hungerLevel > hungerTreshhold;
    [SerializeField] private int hungerTreshhold = 80; // treshhold for hunger 
    [SerializeField] private int feedingSpeed = 25; // hunger reduction per round
    [SerializeField] private int hungerLevel = 0; // 100 is max 0 is none

    public override void Respawn()
    {
        base.Respawn();
        hungerLevel = 0;
    }

    override public void HungerUp()
    {
        base.HungerUp();
        hungerLevel++;
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

        if (nextNode.isOccupied)
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
    }

    public void Eat()
    {
        // Debug.Log("The bird eats a snake");
        if (isHungry)
        {
            hungerLevel -= feedingSpeed;
        }
    }

    public void MakeNest()
    {
        Debug.Log("The bird makes a nest in a tree");
        // TODO: check if node has a tree
        // set node to nested
        // new chicks spawns in nests? dunno
    }
}
