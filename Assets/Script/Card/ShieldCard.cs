using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ShieldCard : Card
{
    public int ShieldDamage { get; private set; }
    public byte Rotation { get; private set; } // 1 2 4 8 16 ... pip-line 이용

    ShieldCard(byte cardData, int shieldDamage, byte rotation)
    {
        Type = CardDataType.Shield;
        CardData = cardData;
        ShieldDamage = shieldDamage;
        Rotation = rotation;
    }
}
