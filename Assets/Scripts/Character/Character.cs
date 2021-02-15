using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        protected Rigidbody2D Rb;

        protected virtual void Start()
        {
            Rb = GetComponent<Rigidbody2D>();
        }
    }
}
