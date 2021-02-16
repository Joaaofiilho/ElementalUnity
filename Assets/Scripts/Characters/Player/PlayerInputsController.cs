using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    [RequireComponent(typeof(CharacterWalkable))]
    public class PlayerInputsController: MonoBehaviour
    {
        [SerializeField] private CharacterWalkable playerWalkable;

        //Inputs
        public void Move(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            direction.y = 0;
        
            playerWalkable.Move(direction);
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                playerWalkable.Jump();
            }
        }
    }
}
