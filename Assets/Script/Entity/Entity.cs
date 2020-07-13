using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public class EntityTransform
    {
        public int X;
        public int Y;
        public byte _Rotation;

        EntityTransform(int x, int y, byte rotation)
        {
            X = x;
            Y = y;
            _Rotation = rotation;
        }
    }

    [HideInInspector] public int Hp { get; protected set; }
    [HideInInspector] public EntityTransform _transform { get; protected set; }

    protected Entity(int hp, EntityTransform entityTransform)
    {
        Hp = hp;
        _transform = entityTransform;
    }

    public virtual void Move(byte rotation, int value)
    {
        int vertical = (rotation & (byte) Rotation.Up) == (byte) Rotation.Up ? 1 : 
            (rotation & (byte) Rotation.Down) == (byte)Rotation.Down ? -1 : 0;
        int horizontal = (rotation & (byte) Rotation.Right) == (byte) Rotation.Right ? 1 : 
            (rotation & (byte) Rotation.Left) == (byte)Rotation.Left ? -1 : 0;

        _transform.X = horizontal * value;
        _transform.Y = vertical * value;
        _transform._Rotation = rotation;
        
        // TODO move game obj
    }
}
