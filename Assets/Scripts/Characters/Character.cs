using System;
using System.Collections.Generic;
using Modifiers;
using Skills;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : Modifiable
    {
        [Header("Check references")]
        [SerializeField] private LayerMask whatIsGround;
        public Transform groundCheck;
        private Vector2 _groundCheckSize;
        
        [Header("Status")]
        [SerializeField] private float health = 100f;
        [SerializeField] public float attackDamage = 20f;
        
        [HideInInspector] public Rigidbody2D rb;
        private List<Skill> _skills;

        protected override void Start()
        {
            base.Start();
            _skills = new List<Skill>();
            rb = GetComponent<Rigidbody2D>();
            _groundCheckSize = new Vector2(transform.lossyScale.x, 0.01f);
        }

        protected override void Update()
        {
            base.Update();
            foreach (var skill in _skills)
            {
                skill.Update(this, Time.deltaTime);
            }
        }

        public bool IsOnGround()
        {
            var other = Physics2D.OverlapBox(groundCheck.transform.position, _groundCheckSize, 0f, whatIsGround);
            var onGround = other != null;

            return onGround;
        }

        public void ChangeGravityScaleBy(float amount)
        {
            rb.gravityScale += amount;
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
        }

        public void AddSkill(Skill skill)
        {
            if (!_skills.Contains(skill))
            {
                _skills.Add(skill);
            }
        }

        public void RemoveSkill(Skill skill)
        {
            _skills.Remove(skill);
        }

        public void TryToPerformSkill(SkillTypes skillType)
        {
            var skill = _skills.Find((s) => s.Type == skillType);
            skill?.TryToPerform();
        }
    }
}
