using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Config/Bullet")]
    public sealed class BulletConfig : ScriptableObject
    {
        [SerializeField] public PhysicsLayer PhysicsLayer;
        [SerializeField] public Color Color;
        [SerializeField] public int Damage;
        [SerializeField] public float Speed;
    }
}
