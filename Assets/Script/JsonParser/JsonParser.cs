using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class JsonParser
{
    public static List<AttackCard> AttackCards { get; private set; } = new List<AttackCard>();
    public static List<ShieldCard> ShieldCards { get; private set; } = new List<ShieldCard>();
    public static List<SkillCard> SkillCards { get; private set; } = new List<SkillCard>();
    
    private static string GetCardTypeString(CardType type)
    {
        switch (type)
        {
            case CardType.Attack: return "Attack";
            case CardType.Shield: return "Shield";
            case CardType.Skill: return "Skill";
        }
    }
    
    public static void ParseData(CardType type)
    {
        string path = string.Format(@"Json\{0}Card.json", GetCardTypeString(type));
        string str = Resources.Load<Text>(path).text;
        JArray array = new JArray(str);

        for (int i = 0; i < array.Count; ++i)
        {
            switch (type)
            {
                case CardType.Attack:
                    AttackCards.Add(new AttackCard(array[i]["CardName"], i, array[i]["Damage"], array[i]["Range"]));
                    break;
                case CardType.Shield:
                    break;
                case CardType.Skill:
                    break;
            }
        }

        foreach (JObject jObject in array)
        {
            switch (type)
            {
                case CardType.Attack:
                    AttackCards.Add(new AttackCard());
                    break;
                case CardType.Shield:
                    break;
                case CardType.Skill:
                    break;
            }
        }
    }
    
}
