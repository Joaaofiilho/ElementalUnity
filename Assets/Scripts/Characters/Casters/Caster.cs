using System;
using System.Collections.Generic;
using Manas;
using UnityEngine;

namespace Characters.Casters
{
    [RequireComponent(typeof(Character))]
    public class Caster : MonoBehaviour, ICasterListener
    {
        public Character Character { get; private set; }
        private List<Mana> _manas;

        private void Start()
        {
            Character = GetComponent<Character>();
            _manas = new List<Mana>();
        }

        public void AddMana(Mana mana)
        {
            _manas.Add(mana);
            mana.OnManaAttached(Character);
            OnAddMana?.Invoke(mana);
        }

        public void RemoveMana(Mana mana)
        {
            _manas.Remove(mana);
            mana.OnManaDetached(Character);
            OnRemoveMana?.Invoke(mana);
        }

        public event Action<Mana> OnAddMana;
        public event Action<Mana> OnRemoveMana;
    }
}
