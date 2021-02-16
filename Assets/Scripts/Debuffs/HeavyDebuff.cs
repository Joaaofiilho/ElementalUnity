using Characters;

namespace Debuffs
{
    public class HeavyDebuff: Debuff
    {
        private readonly CharacterWalkable _characterWalkable;

        private const float IncreaseGravityScale = 0.8f;
        private const float DecreaseVelocity = 1f;

        public HeavyDebuff(CharacterWalkable characterWalkable, bool hasDuration, float duration) : base(hasDuration, duration)
        {
            _characterWalkable = characterWalkable;
        }

        public override void OnDebuffAttached()
        {
            _characterWalkable.ChangeGravityScaleBy(IncreaseGravityScale);
            _characterWalkable.movementSpeed -= DecreaseVelocity;
        }

        public override void OnDebuffDetached()
        {
            _characterWalkable.ChangeGravityScaleBy(-IncreaseGravityScale);
            _characterWalkable.movementSpeed += DecreaseVelocity;
        }
    }
}
