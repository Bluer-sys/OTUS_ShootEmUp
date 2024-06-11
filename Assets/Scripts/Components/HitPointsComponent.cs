using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        [SerializeField] private int hitPoints;
        
        public event Action<GameObject> OnDead;
        
        public bool IsAlive() =>
            hitPoints > 0;

        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            
            if (hitPoints <= 0)
            {
                OnDead?.Invoke(gameObject);
            }
        }
    }
}
