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
            if (_instance == null)
            {
                var player = GameObject.FindWithTag("Player");
                
                if (player == null)
                {
                    Debug.LogError("this scene hasn't player");
                }
                else
                {
                    _instance = player.GetComponent<Player>();
                }
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
            CardSet.PullCard();
        }
    }
}
