using UnityEngine;
using UnityEngine.UI;

public sealed class ShieldCard : Card
{
    public byte Rotation { get; private set; } // 1 2 4 8 16 ... pip-line 이용

    //card_id,card_name,rotation,amount,description
    public ShieldCard(int cardId, string cardName, byte rotation, 
        int amount, string description, CardFXData fxData) : 
        base(cardId, cardName, description, CardType.Shield, fxData)
    {
        Amount = amount;
        Rotation = rotation;
    }
    
    public override void Active()
    {
        base.Active();
        // TODO shield to rotation
    }
    
}
