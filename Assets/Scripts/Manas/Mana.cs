using System.Collections.Generic;
using Debuffs;

namespace Manas
{
    public abstract class Mana
    {
        public ManaTypes Type;
        
        protected readonly List<Debuff> DebuffsToCaster;

        protected Mana()
        {
            DebuffsToCaster = new List<Debuff>();
        }

        public void OnManaAttached(Characters.Character character)
        {
            foreach (var debuff in DebuffsToCaster)
            {
                character.AddDebuff(debuff);
            }
        }

        public void OnManaDetached(Characters.Character character)
        {
            foreach (var debuff in DebuffsToCaster)
            {
                character.RemoveDebuff(debuff);
            }
        }
    }
}
