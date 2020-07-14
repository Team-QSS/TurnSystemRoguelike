using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class JsonParser
{
    public static Dictionary<string, AttackCard> AttackCards { get; private set; } = new Dictionary<string, AttackCard>();
    public static Dictionary<string, ShieldCard> ShieldCards { get; private set; } = new Dictionary<string, ShieldCard>();
    public static Dictionary<string, SkillCard> SkillCards { get; private set; } = new Dictionary<string, SkillCard>();

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
        byte attackCardId = 0;
        byte shieldCardId = 0;
        byte skillCardId = 0;
        string path = string.Format(@"Json\{0}Card.json", GetCardTypeString(type));
        string str = Resources.Load<Text>(path).text;
        JArray array = new JArray(str);

        foreach (JObject jsonObj in array)
        {
            var fxData = ResourceExtension.LoadCardFXData(jsonObj["CardName"].ToString());

            if (type == CardType.Attack)
            {
                var rangeData = jsonObj["Range"].
                    ToString().
                    Split(' ').
                    Select(s => int.Parse(s)).
                    Take(2)
                    .ToArray();
                var range = (rangeData[0], rangeData[1]);

                AttackCards.Add(
                    jsonObj["CardName"].ToString(),
                    new AttackCard(
                        jsonObj["CardName"].ToString(),
                        jsonObj["Description"].ToString(),
                        attackCardId++,
                        fxData,
                        int.Parse(jsonObj["Damage"].ToString()),
                        range));
            }
            else if (type == CardType.Shield)
            {
                ShieldCards.Add(
                    jsonObj["CardName"].ToString(),
                    new ShieldCard(
                        jsonObj["CardName"].ToString(),
                        jsonObj["Description"].ToString(),
                        shieldCardId++,
                        fxData,
                        int.Parse(jsonObj["ShieldDamage"].ToString()),
                        byte.Parse(jsonObj["Rotation"].ToString())));
            }
            else if (type == CardType.Skill)
            {
                var range = jsonObj["Range"]
                    .ToString()
                    .Split(' ').
                    Select(s => byte.Parse(s))
                    .ToArray();

                SkillCards.Add(
                    jsonObj["CardName"].ToString(),
                    new SkillCard(
                        jsonObj["CardName"].ToString(),
                        jsonObj["Description"].ToString(),
                        skillCardId++,
                        fxData,
                        int.Parse(jsonObj["Amount"].ToString()),
                        range));
            }
        }
    }
}
