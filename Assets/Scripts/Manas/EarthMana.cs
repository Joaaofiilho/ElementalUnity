using System.Collections.Generic;
using Characters;
using Characters.Casters;
using Debuffs;

namespace Manas
{
    public class EarthMana : Mana
    {
        public EarthMana(Caster caster)
        {
            Type = ManaTypes.Earth;

            var owner = caster.Character;
            
            if (owner is CharacterWalkable walkable)
            {
                DebuffsToCaster.Add(new HeavyDebuff(walkable, false, 0));
            }
        }
    }
}
