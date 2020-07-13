﻿using UnityEngine;
using UnityEngine.UI;

public sealed class SkillCard : Card
{
    public int Amount { get; private set; }
    public byte Rotation { get; private set; }
    public int[] Range { get; private set; }

    public SkillCard(string cardName, Animation effect, AudioClip sound, Animation playerAni,
        string description, Image cardImage, byte cardData, int amount, byte rotation, int[] range) : 
        base(cardName, effect, sound, playerAni, description, cardImage, CardType.Skill, cardData)
    {
        Amount = amount;
        Rotation = rotation;
        Range = range;
    }

    public override void Active()
    {
        base.Active();
        // TODO heal or damage
    }
}
