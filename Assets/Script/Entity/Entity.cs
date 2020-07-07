using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Entity
{
    [HideInInspector] public int Hp { get; protected set; }
    [HideInInspector] public Collider2D Col { get; protected set; }
    [HideInInspector] public int[] pos { get; private set; } = new int[2];
    
    public virtual void Move(int x, int y)
    {
        // move entity +x +y
    }
}
