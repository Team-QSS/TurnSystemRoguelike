using System.Collections.Generic;
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

        return null;
    }
    
    public static void ParseData(CardType type)
    {
        byte attackCnt = 0;
        byte shieldCnt = 0;
        byte skillCnt = 0;
        string path = string.Format(@"Json\{0}Card.json", GetCardTypeString(type));
        string str = Resources.Load<Text>(path).text;
        JArray array = new JArray(str);

        foreach (JObject jsonObj in array)
        {
            switch (type)
            {
                case CardType.Attack:
                    AttackCards.Add(
                        new AttackCard(
                            jsonObj["CardName"].ToString(), 
                            attackCnt++, 
                            int.Parse(jsonObj["Damage"].ToString()), 
                            jsonObj["Range"].
                                ToString().
                                Split(' ').
                                Select(x => int.Parse(x)).
                                ToArray()));
                    break;
                case CardType.Shield:
                    ShieldCards.Add(
                        new ShieldCard(
                            jsonObj["CardName"].ToString(), 
                            shieldCnt++,
                            int.Parse(jsonObj["ShieldDamage"].ToString()),
                            byte.Parse(jsonObj["Rotation"].ToString())));
                    break;
                case CardType.Skill:
                    SkillCards.Add(
                        new SkillCard(
                            jsonObj["CardName"].ToString(),
                            skillCnt++,
                            int.Parse(jsonObj["Amount"].ToString()),
                            byte.Parse(jsonObj["Rotation"].ToString()),
                            jsonObj["Range"].
                                ToString().
                                Split(' ').
                                Select(x => int.Parse(x)).
                                ToArray()));
                    break;
            }
        }
    }
    
}
