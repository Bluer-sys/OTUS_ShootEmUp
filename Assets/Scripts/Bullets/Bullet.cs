using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public bool IsPlayer { get; set; }
        public int Damage { get; set; }
        

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetVelocity(Vector2 velocity) =>
            rigidbody2D.velocity = velocity;
        
        public void SetPhysicsLayer(int physicsLayer) =>
            gameObject.layer = physicsLayer;

        public void SetPosition(Vector3 position) =>
            transform.position = position;

        public void SetColor(Color color) =>
            spriteRenderer.color = color;
    }
}
