public sealed class SkillCard : Card
{
    public int Amount { get; private set; }
    public int[,] Range { get; private set; }

    public SkillCard(byte cardData, int amount, int[,] range) : base(CardType.Skill, cardData)
    {
        Amount = amount;
        Range = range;
    }

    public override void Active()
    {
        base.Active();
    }
}
