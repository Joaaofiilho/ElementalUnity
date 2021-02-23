using Characters;
using UnityEngine;

namespace Skills
{
    public class SmashSkill: Skill
    {
        private CharacterWalkable _characterWalkable;
        private float _gravityScaleDiff;
        public float GravityScale;
        public float DamageMultiplier = 1f;
        private Vector2 DamageRange;

        public SmashSkill(CharacterWalkable character, float gravityScale, float damageRange): base(character, SkillTypes.Smash)
        {
            _characterWalkable = Character as CharacterWalkable;
            GravityScale = gravityScale;
            DamageRange = new Vector2(damageRange, 0.5f);
        }

        public override void TryToPerform()
        {
            if (!Performing && !_characterWalkable.IsOnGround())
            {
                Performing = true;
                _characterWalkable.SetCanMove(false);
                _gravityScaleDiff = _characterWalkable.rb.gravityScale - GravityScale;
                _characterWalkable.rb.gravityScale = GravityScale;
            }
        }

        public override void Update(Character character, float deltaTime)
        {
            if (Performing && character.IsOnGround())
            {
                Performing = false;
                _characterWalkable.SetCanMove(true);
                _characterWalkable.rb.gravityScale += _gravityScaleDiff;

                DealDamage();
            }
        }

        private void DealDamage()
        {
            var position = _characterWalkable.groundCheck.position;
            var colliders = Physics2D.OverlapBoxAll(position, DamageRange, 0);

            foreach (var collider in colliders)
            {
                var character = collider.GetComponent<Character>();
                if (character)
                {
                    character.TakeDamage(_characterWalkable.attackDamage * DamageMultiplier);
                }
            }
        }

        public void SetDamageRange(float damageRange)
        {
            DamageRange = new Vector2(damageRange, 0.5f);
        }
    }
}