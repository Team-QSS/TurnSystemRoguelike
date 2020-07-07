public sealed class SkillCard : Card
{
    public int Amount { get; private set; }
    public byte Rotation { get; private set; }
    public int[] Range { get; private set; }

    public SkillCard(string cardName, byte cardData, int amount, byte rotation, int[] range) : base(cardName, CardType.Skill, cardData)
    {
        Amount = amount;
        Rotation = rotation;
        Range = range;
    }

    public override void Active()
    {
        base.Active();
        // heal or damage
    }
}
