using Casters;
using Characters;
using Modifiers;
using Receptors;

namespace Manas
{
    public class EarthMana : Mana
    {
        public EarthMana(Receptor receptor) : base(receptor, ManaTypes.Earth)
        {
            var characterWalkable = receptor.GetComponent<CharacterWalkable>();
            
            if(characterWalkable) {
                AddModifierToReceptor(new HeavyDebuff(characterWalkable));
            }
        }
    }
}
