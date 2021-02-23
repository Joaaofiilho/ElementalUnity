using UnityEngine;

namespace Modifiers
{
    public abstract class Modifier
    {
        protected readonly Modifiable Modifiable;
        protected Modifier(Modifiable modifiable)
        {
            Modifiable = modifiable;
        }
        public virtual void OnModifierAttached()
        {
        }

        public virtual void OnModifierDetached()
        {
        }

        public virtual void OnUpdateModifier(float deltaTime)
        {
        }
    }
    
    public abstract class Modifier<T>: Modifier where T: Modifiable
    {
        private readonly bool _hasDuration;
        private readonly float _duration;
        private float _durationCounter;
        private bool _ended;

        private readonly bool _isPerTick;
        private readonly float _tickInterval;
        private float _tickCounter;

        protected Modifier(Modifiable modifiable, bool hasDuration = false, float duration = 0): base(modifiable)
        {
            _hasDuration = hasDuration;
            _duration = duration;
        }

        protected Modifier(Modifiable modifiable, bool isPerTick = false, float duration = 0, float tickInterval = 0): base(modifiable)
        {
            _hasDuration = true;
            _duration = duration;
            _isPerTick = isPerTick;
            _tickInterval = tickInterval;
        }
        
        //Methods to be called from parent
        public override void OnModifierAttached()
        {
            OnModifierAttached(Modifiable as T);
        }

        public override void OnModifierDetached()
        {
            OnModifierDetached(Modifiable as T);
        }
        
        public override void OnUpdateModifier(float deltaTime)
        {
            OnUpdateModifier(Modifiable as T, deltaTime);
        }

        //Overridable methods to control modifiers
        protected virtual void OnModifierAttached(T target)
        {
        }

        protected virtual void OnModifierDetached(T target)
        {
            
        }

        protected virtual void OnUpdateModifier(T target, float deltaTime)
        {
            if (_isPerTick)
            {
                if (_tickCounter >= _tickInterval)
                {
                    OnTickDebuff(target);
                    _tickCounter = 0;
                }
                else
                {
                    _tickCounter += deltaTime;
                }
            }

            if (_hasDuration)
            {
                if (!_ended && _durationCounter >= _duration)
                {
                    target.RemoveModifier(this);
                    _ended = true;
                }
                else
                {
                    _durationCounter += deltaTime;
                }
            }
        }

        protected virtual void OnTickDebuff(T target)
        {
        }
    }
}