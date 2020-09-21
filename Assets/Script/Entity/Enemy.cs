public class Enemy : Entity
{
    // routine 관리
    public bool IsHit { get; private set; }
    
    public Enemy(int hp, EntityTransform entityTransform) : base(hp, entityTransform)
    {
        IsHit = false;
    }

    public override void Move(byte rotation, int value)
    {
        base.Move(rotation, value);
        IsHit = false;
    }

    public virtual void HitPlayer() // enemy do skill or attack
    {
        // TODO show enemy's attack effect
    }
}
