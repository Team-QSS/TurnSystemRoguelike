using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : Entity
{
    private static Player instance = null;

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindWithTag("Player").GetComponent<Player>();
            }

            return instance;
        }
        set { instance = value; }
    }
    
    Player(int hp, EntityTransform entityTransform) : base(hp, entityTransform) {}

    public override void Move(byte rotation, int value)
    {
        if (!CardSet.UseCard(rotation))
        {
            base.Move(rotation, value);
            // TODO pull card
        }
    }
}
