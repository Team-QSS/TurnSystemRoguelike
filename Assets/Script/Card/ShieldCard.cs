using UnityEngine;
using UnityEngine.UI;

public sealed class ShieldCard : Card
{
    public int ShieldDamage { get; private set; }
    public byte Rotation { get; private set; } // 1 2 4 8 16 ... pip-line 이용

    public ShieldCard(string cardName, string description, byte cardData,
        CardFXData fxData, int shieldDamage, byte rotation) : 
        base(cardName, description, CardType.Shield, cardData, fxData)
    {
        ShieldDamage = shieldDamage;
        Rotation = rotation;
    }
    
    public override void Active()
    {
        base.Active();
        // TODO shield to rotation
    }
    
}
