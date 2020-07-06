using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Card
{
    protected string CardName;
    protected Animation Effect;
    protected AudioSource Sound;
    protected Animation PlayerAni;
    public CardType Type { get; protected set; }
    public byte CardData { get; protected set; } // card code

    protected Card(string cardName, CardType type, byte cardData)
    {
        CardName = cardName;
        Type = type;
        CardData = cardData;
    }

    public virtual void Active()
    {
        // don't move
    }
}
