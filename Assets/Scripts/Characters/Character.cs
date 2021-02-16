using System;
using System.Collections.Generic;
using Debuffs;
using UnityEngine;

namespace Characters
{
    public class Character : MonoBehaviour
    {
        [HideInInspector] public Rigidbody2D rb;
        private List<Debuff> _activeDebuffs;
        [SerializeField] private float health = 100f;

        protected virtual void Start()
        {
            _activeDebuffs = new List<Debuff>();
            rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void Update()
        {
            foreach (var activeDebuff in _activeDebuffs)
            {
                activeDebuff.OnUpdateDebuff(this, Time.deltaTime);
            }
        }

        public void ChangeGravityScaleBy(float amount)
        {
            rb.gravityScale += amount;
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
        }

        public void AddDebuff(Debuff debuff)
        {
            _activeDebuffs.Add(debuff);
            debuff.OnDebuffAttached();
        }

        public void RemoveDebuff(Debuff debuff)
        {
            _activeDebuffs.Remove(debuff);
            debuff.OnDebuffDetached();
        }
    }
}
