using UnityEngine;

namespace Character
{
    public class CharacterMovement : Character, IMovable
    {
        [Header("Check references")]
        
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private Transform groundReference;
        private Vector2 _groundCheckSize;
        
        [Header("Movement")]
        private float _horizontalMovementDirection;
        [SerializeField] private float movementSpeed = 7f;

        [Header("Jump")]
        [SerializeField] protected float jumpVelocity = 5f;

        protected override void Start()
        {
            base.Start();
            _groundCheckSize = new Vector2(transform.lossyScale.x, 0.01f);
        }

        protected void FixedUpdate()
        {
            MoveCharacter();
            FaceMovementDirection();
        }
        
        //Implemented methods
        public void Move(Vector2 direction)
        {
            _horizontalMovementDirection = direction.x;
        }

        public void Jump()
        {
            if (IsOnGround())
            {
                Rb.velocity = new Vector2(Rb.velocity.x, jumpVelocity);
            }
        }

        //Class methods

        private bool IsOnGround()
        {
            var other = Physics2D.OverlapBox(groundReference.transform.position, _groundCheckSize, 0f, whatIsGround);
            var onGround = other != null;

            return onGround;
        }
        
        private void FaceMovementDirection()
        {
            if (_horizontalMovementDirection != 0)
            {
                var rotation = transform.rotation;
                transform.rotation = Quaternion.Euler(rotation.x, _horizontalMovementDirection > 0 ? 180 : 0, rotation.z);
            }
        }

        private void MoveCharacter()
        {
            var velocity = Rb.velocity;
            Rb.velocity = new Vector2(_horizontalMovementDirection * movementSpeed, velocity.y);
        }
    }
}