using Debuffs;
using UnityEngine;

namespace Characters
{
    public class CharacterWalkable : Characters.Character
    {
        [Header("Check references")]
        
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private Transform groundReference;
        private Vector2 _groundCheckSize;
        
        [Header("Movement")]
        private float _horizontalMovementDirection;
        [SerializeField] public float movementSpeed = 7f;

        [Header("Jump")]
        [SerializeField] protected float jumpVelocity = 5f;

        protected override void Start()
        {
            base.Start();
            _groundCheckSize = new Vector2(transform.lossyScale.x, 0.01f);
            AddDebuff(new DamageOverTimeDebuff(5,  10, 0.5f));
            AddDebuff(new HeavyDebuff(this, true, 3f));
        }

        protected void FixedUpdate()
        {
            MoveCharacter();
            FaceMovementDirection();
        }

        //Class methods
        public void Move(Vector2 direction)
        {
            _horizontalMovementDirection = direction.x;
        }

        public void Jump()
        {
            if (IsOnGround())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            }
        }
        
        private bool IsOnGround()
        {
            var other = Physics2D.OverlapBox(groundReference.transform.position, _groundCheckSize, 0f, whatIsGround);
            var onGround = other != null;

            return onGround;
        }
        
        private void FaceMovementDirection()
        {
            if (_horizontalMovementDirection == 0) return;
            
            var rotation = transform.rotation;
            transform.rotation = Quaternion.Euler(rotation.x, _horizontalMovementDirection > 0 ? 180 : 0, rotation.z);
        }

        private void MoveCharacter()
        {
            var velocity = rb.velocity;
            rb.velocity = new Vector2(_horizontalMovementDirection * movementSpeed, velocity.y);
        }
    }
}