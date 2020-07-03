using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCard : Card
{
    public int Amount { get; private set; }
    public int[,] Range { get; private set; }

    public SkillCard(byte cardData, int amount, int[,] range)
    {
        CardData = cardData;
        Amount = amount;
        Range = range;
    }
}
