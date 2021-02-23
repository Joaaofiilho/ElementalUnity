using System.Collections.Generic;
using Modifiers;
using Receptors;

namespace Manas
{
    public abstract class Mana
    {
        public ManaTypes Type;
        protected Receptor Owner;
        private readonly List<Modifier> _modifiersToReceptor;

        public Mana(Receptor receptor, ManaTypes type)
        {
            Owner = receptor;
            Type = type;
            _modifiersToReceptor = new List<Modifier>();
        }
        
        //Class methods
        public void OnManaAttached(Receptor receptor)
        {
            foreach (var debuff in _modifiersToReceptor)
            {
                receptor.AddModifier(debuff);
            }
        }

        public void OnManaDetached(Receptor receptor)
        {
            foreach (var debuff in _modifiersToReceptor)
            {
                receptor.RemoveModifier(debuff);
            }
        }

        protected void AddModifierToReceptor(Modifier modifier)
        {
            _modifiersToReceptor.Add(modifier);
        }
    }
}
