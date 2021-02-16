using System;
using Characters;

namespace Debuffs
{
    public abstract class Debuff
    {
        private readonly bool _hasDuration;
        private readonly float _duration;
        private float _durationCounter;
        private bool _ended;

        private bool _isPerTick;
        private readonly float _tickCooldown;
        private float _tickCounter;

        protected Debuff(bool hasDuration = false, float duration = 0)
        {
            _hasDuration = hasDuration;
            _duration = duration;
        }

        protected Debuff(bool isPerTick = false, float duration = 0, float tickCooldown = 0)
        {
            _hasDuration = true;
            _duration = duration;
            _isPerTick = isPerTick;
            _tickCooldown = tickCooldown;
        }
        
        public virtual void OnDebuffAttached()
        {
            
        }

        public virtual void OnDebuffDetached()
        {
            
        }

        public virtual void OnUpdateDebuff(Character character, float deltaTime)
        {
            if (_isPerTick)
            {
                if (_tickCounter >= _tickCooldown)
                {
                    OnTickDebuff(character);
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
                    character.RemoveDebuff(this);
                    _ended = true;
                }
                else
                {
                    _durationCounter += deltaTime;
                }
            }
        }

        protected virtual void OnTickDebuff(Character character)
        {
            
        }
    }
}