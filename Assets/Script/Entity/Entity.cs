using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Entity
{
    public int Hp { get; protected set; }
    public Collider2D Col { get; protected set; }

    public virtual void Move(int x, int y)
    {
        // move entity +x +y
    }
}
