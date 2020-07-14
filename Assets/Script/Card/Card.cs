using UnityEngine;
using UnityEngine.UI;

public class Card
{
    public class CardFXData
    {
        public Animation effect;
        public Animation playerAnimation;
        public AudioClip audioClip;
        public Sprite cardSprite;
        
        public CardFXData(Animation effect, Animation playerAnimation, AudioClip audioClip, Sprite cardSprite)
        {
            this.effect = effect;
            this.playerAnimation = playerAnimation;
            this.audioClip = audioClip;
            this.cardSprite = cardSprite;
        }
    }

    protected string cardName;
    protected string description;
    protected CardFXData cardFXData;

    public CardType Type { get; protected set; }
    public byte CardData { get; protected set; } // card code

    protected Card(string cardName, string description, CardType type, byte cardData, CardFXData fxData)
    {
        this.cardName = cardName;
        this.description = description;
        cardFXData = fxData;
        Type = type;
        CardData = cardData;
    }

    public virtual void Active()
    {
        cardFXData.effect.Play();
        cardFXData.playerAnimation.Play();
        // TODO Sound PlayOneShot
    }
}
