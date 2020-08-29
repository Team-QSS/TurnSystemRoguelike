using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BSLibrary;

public class CardMover : MonoSingleton<CardMover>
{
    public List<Image> Cards;
    private int _cardCount;
    public Text CardSetCount;

    private Sprite emptyCardImage;

    public void PullCard(int index)
    {
        // TODO show card draw effect
        
        Cards[index].gameObject.SetActive(true);
        Cards[index].sprite = 
            CardDataParser.GetCard(CardSet.Hands[index]).cardFXData.cardSprite;
    }

    public void UseCard(int index)
    {
        // TODO show card effect
        // TODO show card to in lost card set effect
        Cards[index].gameObject.SetActive(false);
    }
    
    public void PlayResetCardSet()
    {
        // TODO show card set reset effect
        CardSetCount.text = CardSet.GetCardSetCount().ToString();
    }
}
 