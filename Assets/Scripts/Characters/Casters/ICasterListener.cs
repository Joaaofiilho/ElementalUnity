using System;
using Manas;

namespace Characters.Casters
{
    public interface ICasterListener
    {
        event Action<Mana> OnAddMana;
        event Action<Mana> OnRemoveMana;
    }
}