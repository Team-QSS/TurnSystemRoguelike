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
    
    public CardFXData cardFXData { get; private set; }
    public int Amount { get; protected set; }
    public CardType Type { get; protected set; }
    public int CardId { get; protected set; } // card code

    protected Card(int cardId, string cardName, string description, CardType type, CardFXData fxData)
    {
        this.cardName = cardName;
        this.description = description;
        cardFXData = fxData;
        Type = type;
        CardId = cardId;
    }

    public virtual void Active()
    {
        cardFXData.effect.Play();
        cardFXData.playerAnimation.Play();
        // TODO Sound PlayOneShot
    }
}
