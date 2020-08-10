using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public sealed class ShieldCard : Card
{
    public byte _Rotation { get; private set; } // Rotation enum 참고

    //card_id,card_name,rotation,amount,description
    public ShieldCard(int cardId, string cardName, byte rotation, 
        int amount, string description, CardFXData fxData) : 
        base(cardId, cardName, description, CardType.Shield, fxData)
    {
        Amount = amount;
        _Rotation = rotation;
    }
    
    public override void Active()
    {
        base.Active();
        // TODO 
        var rotations = GameManager.Instance.Enemies.
            Where(enemy => enemy.IsHit).
            Select(enemy => 
                (enemy._Transform.x - Player.Instance._Transform.x, 
                    enemy._Transform.y - Player.Instance._Transform.y)).ToArray();
    }
    
}
