using UnityEngine;
using UnityEngine.UI;

public sealed class AttackCard : Card
{
    public int Damage { get; private set; }
    public (int x, int y) Range { get; private set; }
    
    public AttackCard(string cardName, string description, byte cardData,
        CardFXData fxData, int damage, (int x, int y) range) : 
        base(cardName, description, CardType.Attack, cardData, fxData)
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
