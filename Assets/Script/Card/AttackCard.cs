using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AttackCard : Card
{
    public int Damage { get; private set; }
    public int[,] Range { get; private set; }
    
    public AttackCard(byte cardData, int damage, int[,] range)
    {
        Type = CardDataType.Attack;
        CardData = cardData;
        Damage = damage;
        Range = range;
    }
}
