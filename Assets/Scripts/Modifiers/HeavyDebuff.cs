using Characters;

namespace Modifiers
{
    public class HeavyDebuff: Modifier<CharacterWalkable>
    {
        private float _increaseGravityScale = 0.8f;
        private float _decreaseVelocity = 1f;

        public HeavyDebuff(CharacterWalkable characterWalkable): base(characterWalkable, false, 0f)
        {
        }
        
        public HeavyDebuff(CharacterWalkable characterWalkable, float duration) : base(characterWalkable, true, duration)
        {
        }

        protected override void OnModifierAttached(CharacterWalkable characterWalkable)
        {
            characterWalkable.ChangeGravityScaleBy(_increaseGravityScale);
            characterWalkable.movementSpeed -= _decreaseVelocity;
        }

        protected override void OnModifierDetached(CharacterWalkable characterWalkable)
        {
            characterWalkable.ChangeGravityScaleBy(-_increaseGravityScale);
            characterWalkable.movementSpeed += _decreaseVelocity;
        }
    }
}
