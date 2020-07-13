using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Enemy : Entity
{
    // routine 관리
    
    public Enemy(int hp, EntityTransform entityTransform) : base(hp, entityTransform)
    {
        
    }

    public override void Move(byte rotation, int value)
    {
        // 플레이어가 가까우면 공격
        base.Move(rotation, value);
    }
}
