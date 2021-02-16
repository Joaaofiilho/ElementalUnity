using Characters;

namespace Debuffs
{
    public class DamageOverTimeDebuff: Debuff
    {
        private float _damagePerTick;
        
        public DamageOverTimeDebuff(float damagePerTick, float duration, float tickCooldown): base(true, duration, tickCooldown)
        {
            _damagePerTick = damagePerTick;
        }

        protected override void OnTickDebuff(Character character)
        {
            character.TakeDamage(_damagePerTick);
        }
    }
}