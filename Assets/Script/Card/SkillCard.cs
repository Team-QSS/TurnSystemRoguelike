using UnityEngine;
using UnityEngine.UI;

public sealed class SkillCard : Card
{
    public byte[] Range { get; private set; }

    // card_id,card_name,range,amount,description
    public SkillCard(int cardId, string cardName, byte[] range, 
        int amount, string description, CardFXData fxData) : 
        base(cardId, cardName, description, CardType.Skill, fxData)
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
