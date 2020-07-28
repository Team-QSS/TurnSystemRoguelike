using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class CardDataParser
{
    private static Dictionary<int, AttackCard> _attackCards = new Dictionary<int, AttackCard>();
    private static Dictionary<int, ShieldCard> _shieldCards = new Dictionary<int, ShieldCard>();
    private static Dictionary<int, SkillCard> _skillCards = new Dictionary<int, SkillCard>();

    private const string CSVPath = @"csv\";
    
    public static Card GetCard(KeyValuePair<CardType, int> cardData)
    {
        switch (cardData.Key.ToString())
        { 
            case "AttackCard": return _attackCards[cardData.Value];
            case "ShieldCard": return _shieldCards[cardData.Value];
            case "SkillCard": return _skillCards[cardData.Value];
            
            default: 
                Debug.LogError("CardType");
                throw new ArgumentException();
        }
    }
    
    public static void ParseCardData()
    {
        foreach (var typeName in typeof(CardType).GetEnumNames())
        {
            string texts = Resources.Load<Text>(CSVPath + typeName).text;
            string[][] datas = texts.Split('\n'). // string[]
                Select(x => x.Split(',')).ToArray(); // string[][]
            
            foreach (var data in datas)
            {
                if (data[0].Equals("card_id"))
                {
                    continue;
                }

                Card.CardFXData fxData = ResourceExtension.LoadCardFXData(fileName:data[1]);
                
                if (typeName.Equals("Attack"))
                {
                    _attackCards.Add(
                        int.Parse(data[0]), 
                        new AttackCard(
                            cardId: int.Parse(data[0]),
                            cardName: data[1],
                            range: (int.Parse(data[2]), int.Parse(data[3])),
                            amount: int.Parse(data[4]),
                            description: data[5],
                            fxData: fxData
                            ));    
                }
                else if (typeName.Equals("Shield"))
                {
                    
                    _shieldCards.Add(
                        int.Parse(data[0]),
                        new ShieldCard(
                            cardId: int.Parse(data[0]),
                            cardName: data[1],
                            rotation: byte.Parse(data[2]),
                            amount: int.Parse(data[3]),
                            description: data[4],
                            fxData: fxData
                            ));
                }
                else if (typeName.Equals("Skill"))
                {
                    byte[] range = data[3].Split(' ').
                        Select(x => byte.Parse(x)).ToArray();
                        
                    _skillCards.Add(
                        int.Parse(data[0]),
                        new SkillCard(
                            cardId: int.Parse(data[0]),
                            cardName: data[1],
                            range: range,
                            amount: int.Parse(data[3]),
                            description: data[4],
                            fxData: fxData
                            ));
                }
            }
        }
    }
}
