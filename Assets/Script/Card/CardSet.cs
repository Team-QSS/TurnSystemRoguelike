using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSet : MonoBehaviour
{
    private List<Card> _cards = new List<Card>();
    private List<Card> _randCards = new List<Card>();
    public Text CardCount;
    private Queue<Card> _cardSet = new Queue<Card>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCard(CardType type, byte code)
    {
        switch (type)
        {
            case CardType.Attack:
                AttackCard card = new AttackCard(JsonParser.AttackCards[code]);
                break;
            case CardType.Shield:
                break;
            case CardType.Skill:
                break;
        }

        //_cards.Add();
    }

    public void ResetCardSet()
    {
        _cardSet.Clear();
        _randCards = _cards;

        while (_randCards.Count > 0)
        {
            int idx = Random.Range(0, _randCards.Count);
            _cardSet.Enqueue(_randCards[idx]);
            _randCards.RemoveAt(idx);
        }

        CardCount.text = _cardSet.Count.ToString();
    }
}
