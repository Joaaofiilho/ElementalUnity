using System.Collections.Generic;
using UnityEngine;

namespace Modifiers
{
    public abstract class Modifiable: MonoBehaviour
    {
        private List<Modifier> _activeModifiers;

        protected virtual void Start()
        {
            _activeModifiers = new List<Modifier>();
        }
        
        protected virtual void Update()
        {
            foreach (var activeModifier in _activeModifiers)
            {
                activeModifier.OnUpdateModifier(Time.deltaTime);
            }
        }
        
        public void AddModifier(Modifier modifier)
        {
            _activeModifiers.Add(modifier);
            modifier.OnModifierAttached();
        }

        public void RemoveModifier(Modifier modifier)
        {
            _activeModifiers.Remove(modifier);
            modifier.OnModifierDetached();
        }
    }
}