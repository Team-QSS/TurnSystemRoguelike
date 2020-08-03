using UnityEngine;
using UnityEngine.UI;

public sealed class AttackCard : Card
{
    public (int x, int y) Range { get; private set; }
    
    //card_id,card_name,range_x,range_y,amount,description
    public AttackCard(int cardId, string cardName, (int x, int y) range, 
        int amount, string description, CardFXData fxData) : 
        base(cardId, cardName, description, CardType.Attack, fxData)
    {
        Amount = amount;
        Range = range;
    }

    public override void Active()
    {
        base.Active();
        
        foreach (var enemy in GameManager.Instance.GetEnemiesWithinAttackRanges(Player.Instance._transform.rotation, Range))
        {
            enemy.Hp -= Amount;
        }
    }
    
}
