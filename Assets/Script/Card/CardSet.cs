﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class CardSet
{
    private static List<KeyValuePair<CardType, int>> _cards = new List<KeyValuePair<CardType, int>>();
    private static List<KeyValuePair<CardType, int>> _cardSetBuffer = new List<KeyValuePair<CardType, int>>();
    private static Queue<KeyValuePair<CardType, int>> _cardSet = new Queue<KeyValuePair<CardType, int>>();
    
    public static KeyValuePair<CardType, int>[] Hands { get; private set;} = 
    {
        new KeyValuePair<CardType, int>(CardType.None, -1), new KeyValuePair<CardType, int>(CardType.None, -1),
        new KeyValuePair<CardType, int>(CardType.None, -1), new KeyValuePair<CardType, int>(CardType.None, -1),
        new KeyValuePair<CardType, int>(CardType.None, -1), new KeyValuePair<CardType, int>(CardType.None, -1)
    };

    private static bool[] _handFlags = new bool[6];
    
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
        _cards.Add(new KeyValuePair<CardType, int>(type, cardId));
    }

    public static void ResetCardSet()
    {
        _cardSet.Clear();
        _cardSetBuffer = _cards;

        while (_cardSetBuffer.Count > 0)
        {
            int idx = Random.Range(0, _cardSetBuffer.Count);
            _cardSet.Enqueue(_cardSetBuffer[idx]);
            _cardSetBuffer.RemoveAt(idx);
        }
        
        CardMover.Instance.ResetCardSet();
    }

    public static void PullCard()
    {
        for (int i = 0; i < _handFlags.Length; ++i)
        {
            if (!_handFlags[i])
            {
                Hands[i] = _cardSet.Dequeue();
                _handFlags[i] = true;
                CardMover.Instance.PullCard(i);
                return;
            }
        }
    }

    public static bool UseCard(byte rotation)
    {
        if (_handFlags[CodeToIdx[rotation]])
        {
            CardDataParser.GetCard(Hands[CodeToIdx[rotation]]).Active();
            _handFlags[CodeToIdx[rotation]] = false;
            CardMover.Instance.UseCard(CodeToIdx[rotation]);
            return true;
        }

        return false;
    }

    public static int GetCardSetCount()
    {
        return _cardSet.Count;
    }
}
