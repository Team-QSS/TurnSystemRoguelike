using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public class EntityTransform
    {
        public int x;
        public int y;
        public byte rotation;

        public EntityTransform(int x, int y, byte rotation)
        {
            this.x = x;
            this.y = y;
            this.rotation = rotation;
        }
    }

    public int Hp;
    public EntityTransform _Transform { get; protected set; }

    protected Entity(int hp, EntityTransform entityTransform)
    {
        Hp = hp;
        _Transform = entityTransform;
    }

    protected void GetDirection(byte rotation, out int vertical, out int horizontal)
    {
        vertical = (rotation & (byte) Rotation.Up) == (byte) Rotation.Up ? 1 : (rotation & (byte) Rotation.Down) == (byte)Rotation.Down ? -1 : 0;
        horizontal = (rotation & (byte) Rotation.Right) == (byte) Rotation.Right ? 1 : (rotation & (byte) Rotation.Left) == (byte)Rotation.Left ? -1 : 0;
    }
    
    public virtual void Move(byte rotation, int value)
    {
        int vertical = 0;
        int horizontal = 0;
        
        GetDirection(rotation, out vertical, out horizontal);

        _Transform.x = horizontal * value;
        _Transform.y = vertical * value;
        _Transform.rotation = rotation;
        
        // TODO move game obj
    }
}
