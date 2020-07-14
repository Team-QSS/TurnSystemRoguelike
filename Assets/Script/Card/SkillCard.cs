using UnityEngine;
using UnityEngine.UI;

public sealed class SkillCard : Card
{
    public int Amount { get; private set; }
    public byte[] Range { get; private set; }

    public SkillCard(string cardName, string description, byte cardData,
        CardFXData fxData, int amount, byte[] range) : 
        base(cardName, description, CardType.Skill, cardData, fxData)
    {
        Amount = amount;
        Range = range;
    }

    public override void Active()
    {
        base.Active();
        // TODO heal or damage
    }
}
