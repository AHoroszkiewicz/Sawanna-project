using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal, IEating
{
    [SerializeField] private int altitude { get; set; } // ???

    [SerializeField] public bool isHungry => hungerLevel > hungerTreshhold;
    [SerializeField] private int hungerTreshhold = 80; // treshhold for hunger 
    [SerializeField] private int feedingSpeed = 25; // hunger reduction per round
    [SerializeField] private int hungerLevel = 0; // 100 is max 0 is none

    public override AnimalTypes AnimalType => AnimalTypes.bird;

    private void move()
    {
        transform.position = nextNode.transform.position;
        Debug.Log("The Bird moves from " + currentNode + " to " + nextNode);
        previousNode = currentNode;
        currentNode = nextNode;
        nextNode = null;
    }

    override public void Move()
    {
        if (previousNode == null)
        {
            previousNode = currentNode;
        }

        List<Node> listOfValidNodes = new List<Node>();
        // Search connected nodes for next unoccipied lion or intersection nodes
        foreach (Node node in currentNode.ConnectedNodes)
        {
            if ((node.nodeType == Node.NodeType.bird || node.nodeType == Node.NodeType.intersection) && node != previousNode)
            {
                listOfValidNodes.Add(node);
            }
        }
        if (listOfValidNodes.Count > 0)
        {
            // if available, select a node at random and move to it
            nextNode = listOfValidNodes[Random.Range(0, listOfValidNodes.Count)];
            move();
        }
    }

    public void Eat()
    {
        Debug.Log("The bird eats a snake");
        if (isHungry)
        {
            hungerLevel -= feedingSpeed;
        }
    }

    public void MakeNest()
    {
        Debug.Log("The bird makes a nest in a tree");
        // TODO: check if node is a tree
        // set node to nested
    }
}
