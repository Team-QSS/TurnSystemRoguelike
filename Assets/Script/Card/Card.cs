using UnityEngine;

public class Card
{
    protected string CardName;
    protected Animation Effect;
    protected AudioClip Sound;
    protected Animation PlayerAni;
    protected string Description;
    public CardType Type { get; protected set; }
    public byte CardData { get; protected set; } // card code

    protected Card(string cardName, Animation effect, AudioClip sound, Animation playerAni, 
        string description, CardType type, byte cardData)
    {
        CardName = cardName;
        Effect = effect;
        Sound = sound;
        PlayerAni = playerAni;
        Description = description;
        Type = type;
        CardData = cardData;
    }

    public virtual void Active()
    {
        Effect.Play();
        PlayerAni.Play();
        // TODO Sound PlayOneShot
    }
}
