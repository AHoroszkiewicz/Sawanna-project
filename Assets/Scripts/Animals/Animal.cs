using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : IAging, IMovement
{
    [SerializeField] private int ID { get; set; }
    [SerializeField] private int Age { set; get;  }
    [SerializeField] private int MovementSpeed { get; set; }
    [SerializeField] private bool IsAlive { get; set; }

    public void AgeUp()
    {
        Age++;
    }

    void Die()
    {
        IsAlive = false;
    }

    public abstract void Move();
}
