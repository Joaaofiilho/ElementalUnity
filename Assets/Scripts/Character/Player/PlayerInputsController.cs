using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character.Player
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerInputsController: MonoBehaviour
    {
        [SerializeField] private CharacterMovement playerMovement;
        private IMovable _movable;

        private void Start()
        {
            _movable = playerMovement;
        }

        //Inputs
        public void Move(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            direction.y = 0;
        
            _movable.Move(direction);
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _movable.Jump();
            }
        }
    }
}
