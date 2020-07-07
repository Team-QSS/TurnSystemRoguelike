using UnityEngine;

public sealed class AttackCard : Card
{
    public int Damage { get; private set; }
    public int[] Range { get; private set; }
    
    public AttackCard(string cardName, Animation effect, AudioClip sound, Animation playerAni, byte cardData, int damage, int[] range) : base(cardName, effect, sound, playerAni, CardType.Attack, cardData)
    {
        Damage = damage;
        Range = range;
    }

    public override void Active()
    {
        base.Active();
        // TODO cal position
    }
    
}
