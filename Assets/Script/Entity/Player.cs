using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : Entity
{
    private static Player _instance = null;

    public static Player Instance
    {
        get
        {
            _instance = GameObject.FindWithTag("Player").GetComponent<Player>();
            
            if (_instance == null)
            {
                Debug.LogError("has not Player");
            }
            
            return _instance;
        }
        private set { _instance = value; }
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
