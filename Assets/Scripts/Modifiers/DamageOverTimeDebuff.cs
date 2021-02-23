using Characters;
using Receptors;

namespace Modifiers
{
    public class DamageOverTimeDebuff: Modifier<Character>
    {
        private readonly float _damagePerTick;
        
        public DamageOverTimeDebuff(Character character, float damagePerTick, float duration, float tickInterval): base(character, true, duration, tickInterval)
        {
            _damagePerTick = damagePerTick;
        }

        protected override void OnTickDebuff(Character character)
        {
            character.TakeDamage(_damagePerTick);
        }
    }
}