using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CardSet
{
    private static List<Card> _cards = new List<Card>();
    private static List<Card> _randCards = new List<Card>();
    public static Text CardCount;
    private static Queue<Card> _cardSet = new Queue<Card>();
    private static List<Card> _hands = new List<Card>();
    public const int MaxHandsCount = 6;
    
    private static readonly Dictionary<byte, int> CodeToIdx = new Dictionary<byte, int>
    {
        {(byte)(Rotation.Up | Rotation.Right), 0},    // {3, 0}
        {(byte)(Rotation.Up | Rotation.Down), 1},     // {5, 1}
        {(byte)(Rotation.Right | Rotation.Down), 2},  // {6, 2}
        {(byte)(Rotation.Up | Rotation.Left), 3},     // {9, 3}
        {(byte)(Rotation.Right | Rotation.Left), 4},  // [10, 4}
        {(byte)(Rotation.Down | Rotation.Left), 5}    // [12, 5}
    };

    public static void AddCardSet(CardType type, int cardId)
    {
        Card card = null;
        
        switch (type)
        {
            case CardType.Attack:
                card = CardDataParser.AttackCards[cardId];
                break;
            case CardType.Shield:
                card = CardDataParser.ShieldCards[cardId];
                break;
            case CardType.Skill:
                card = CardDataParser.SkillCards[cardId];
                break;
        }

        _cards.Add(card);
    }

    public static void ResetCardSet()
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

    public static void PullCard()
    {
        if (_hands.Count < MaxHandsCount)
        {
            _hands.Add(_cardSet.Dequeue());
        }
    }

    public static bool UseCard(byte rotation)
    {
        if (_hands.Count == 0)
        {
            return false;
        }
        
        if (CodeToIdx.ContainsKey(rotation))
        {
            _hands[CodeToIdx[rotation]].Active();
            _hands.RemoveAt(CodeToIdx[rotation]);
            return true;
        }
        else
        {
            return false;
        }
    }
}
