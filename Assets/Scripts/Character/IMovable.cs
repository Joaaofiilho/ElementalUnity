using UnityEngine;

namespace Character
{
    public interface IMovable
    {
        void Move(Vector2 direction);

        void Jump();
    }
}
