using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Animal
{
    [SerializeField] private int venomLevel { get; set; }
    [SerializeField] private int venomPerBite { get; set; }
    [SerializeField] private int venomRegenRate { get; set; }

    public Snake()
    {
        venomLevel = 100;
        venomPerBite = 50;
        venomRegenRate = 5;
    }

    override public void Move()
    {
        Debug.Log("The snake slithers");
        venomLevel += venomRegenRate;
    }
    public void Bite()
    {
        Debug.Log("The snake bites");
        venomLevel -= venomPerBite;
    }
}
