using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Snake : Animal
{
    [SerializeField] private int venomLevel;
    [SerializeField] private int venomPerBite;
    [SerializeField] private int venomRegenRate;

    public int VenomLevel => venomLevel;
    public int VenomPerBite => venomPerBite;
    public int VenomRegenRate { get => venomRegenRate; set => venomRegenRate = value;}

    public Snake()
    {
        venomLevel = 100;
        venomPerBite = 50;
        venomRegenRate = 5;
    }

    override public void Move()
    {
        if (currentNode == null)
        {
            Debug.Log("currentNode is null");
            return;
        }    
        Debug.Log("The snake slithers");
        venomLevel += venomRegenRate;
    }
    public void Bite()
    {
        Debug.Log("The snake bites");
        venomLevel -= venomPerBite;
    }
}
