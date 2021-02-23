using Modifiers;
using Skills;
using UnityEngine;

namespace Characters
{
    public class CharacterWalkable : Character
    {
        [Header("Movement")]
        private float _horizontalMovementDirection;

        private bool _canMove = true;
        
        [SerializeField] public float movementSpeed = 7f;

        [Header("Jump")]
        [SerializeField] protected float jumpVelocity = 5f;

        protected override void Start()
        {
            base.Start();
            
            AddModifier(new DamageOverTimeDebuff(this, 5, 10, 0.5f));
            AddModifier(new HeavyDebuff(this, 3f));
            AddSkill(new SmashSkill(this, 5f, 5f));
        }

        protected void FixedUpdate()
        {
            if (_canMove)
            {
                MoveCharacter();
            }
        }

        //Class methods
        public void Move(Vector2 direction)
        {
            _horizontalMovementDirection = direction.x;
            FaceMovementDirection();
        }

        public void Jump()
        {
            if (IsOnGround())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            }
        }

        private void FaceMovementDirection()
        {
            if (_horizontalMovementDirection == 0) return;
            
            var rotation = transform.rotation;
            transform.rotation = Quaternion.Euler(rotation.x, _horizontalMovementDirection > 0 ? 180 : 0, rotation.z);
        }

        public void MoveCharacter()
        {
            var velocity = rb.velocity;
            rb.velocity = new Vector2(_horizontalMovementDirection * movementSpeed, velocity.y);
        }

        public void SetCanMove(bool canMove)
        {
            _canMove = canMove;
            
            if (!_canMove)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}