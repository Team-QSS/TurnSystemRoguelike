using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class SkillCard : Card
{
    public byte[] Range { get; private set; }
    public bool IsHeal { get; private set; }
    
    // card_id,card_name,range,amount,description
    public SkillCard(int cardId, string cardName, byte[] range, 
        int amount, string description, CardFXData fxData) : 
        base(cardId, cardName, description, CardType.Skill, fxData)
    {
        Amount = amount;
        Range = range;
        IsHeal = (range[0] & 128) == 128;
    }

    public override void Active()
    {
        base.Active();

        if (IsHeal)
        {
            Player.Instance.Hp += Amount;
        }
        else
        {
            foreach (var enemy in GameManager.Instance.GetEnemiesWithinSkillRanges(Range))
            {
                enemy.Hp -= Amount;
            }
        }
    }
}
