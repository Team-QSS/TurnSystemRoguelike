using UnityEngine;

public sealed class ShieldCard : Card
{
    public int ShieldDamage { get; private set; }
    public byte Rotation { get; private set; } // 1 2 4 8 16 ... pip-line 이용

    public ShieldCard(string cardName, Animation effect, AudioClip sound, Animation playerAni, 
        string description, byte cardData, int shieldDamage, byte rotation) : 
        base(cardName, effect, sound, playerAni, description, CardType.Shield, cardData)
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
