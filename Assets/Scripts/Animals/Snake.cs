using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Animal
{
    [SerializeField] private int VenomLevel { get; set; }
    [SerializeField] private int VenomRegenRate { get; set; }

    override public void Move()
    {
        Debug.Log("The snake slithers");
    }
}
