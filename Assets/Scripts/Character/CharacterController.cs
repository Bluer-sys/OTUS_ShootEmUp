using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject character; 
        [SerializeField] private GameManager gameManager;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;

        private HitPointsComponent hitPointsComponent;
        
        private bool fireRequired;


        private void Awake()
        {
            hitPointsComponent = character.GetComponent<HitPointsComponent>();
        }
        
        private void OnEnable()
        {
            hitPointsComponent.OnDead += OnCharacterDeath;
        }

        private void OnDisable()
        {
            hitPointsComponent.OnDead -= OnCharacterDeath;
        }


        private void FixedUpdate()
        {
            if (!fireRequired)
                return;

            OnFlyBullet();
            fireRequired = false;
        }


        public void SetFireActive(bool state)
        {
            fireRequired = state;
        }


        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();


        private void OnFlyBullet()
        {
            var weapon = character.GetComponent<WeaponComponent>();
            bulletSystem.FlyBulletByArgs(new BulletData
            {
                IsPlayerOwner = true,
                PhysicsLayer = (int) bulletConfig.PhysicsLayer,
                Color = bulletConfig.Color,
                Damage = bulletConfig.Damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * bulletConfig.Speed
            });
        }
    }
}
