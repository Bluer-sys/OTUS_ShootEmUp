using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed;
        
        public void Move(Vector2 direction)
        {
            var nextPosition = rigidbody2D.position + direction * speed;
            
            rigidbody2D.MovePosition(nextPosition);
        }
    }
}
