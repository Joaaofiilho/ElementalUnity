using System.Collections.Generic;
using Manas;
using Modifiers;

namespace Receptors
{
    public class Receptor : Modifiable
    {
        public List<Mana> _manas;

        protected override void Start()
        {
            base.Start();
            _manas = new List<Mana>();
        }

        public void AddMana(Mana mana)
        {
            _manas.Add(mana);
            mana.OnManaAttached(this);
        }

        public void RemoveMana(Mana mana)
        {
            _manas.Remove(mana);
            mana.OnManaDetached(this);
        }
    }
}
