using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class CardDataParser
{
    public static Dictionary<int, AttackCard> AttackCards { get; private set; } = new Dictionary<int, AttackCard>();
    public static Dictionary<int, ShieldCard> ShieldCards { get; private set; } = new Dictionary<int, ShieldCard>();
    public static Dictionary<int, SkillCard> SkillCards { get; private set; } = new Dictionary<int, SkillCard>();

    private const string CSVPath = @"csv\";

    public static void ParseCardData()
    {
        foreach (var typeName in typeof(CardType).GetEnumNames())
        {
            string texts = Resources.Load<Text>(CSVPath + typeName).text;
            string[][] datas = texts.Split('\n'). // string[]
                Select(x => x.Split(',')).ToArray(); // string[][]
            
            foreach (var data in datas)
            {
                if (data[0] == "card_id")
                {
                    continue;
                }

                Card.CardFXData fxData = ResourceExtension.LoadCardFXData(fileName:data[1]);
                
                if (typeName == "Attack")
                {
                    AttackCards.Add(
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
                else if (typeName == "Shield")
                {
                    
                    ShieldCards.Add(
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
                else if (typeName == "Skill")
                {
                    byte[] range = data[3].Split(' ').
                        Select(x => byte.Parse(x)).ToArray();
                        
                    SkillCards.Add(
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
