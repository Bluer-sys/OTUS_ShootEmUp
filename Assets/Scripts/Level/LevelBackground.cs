using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour
    {
        [SerializeField] public float startPositionY;
        [SerializeField] public float endPositionY;
        [SerializeField] public float movingSpeedY;
        
        private float positionX;
        private float positionZ;
        
        
        private void Awake()
        {
            var position = transform.position;
            
            positionX = position.x;
            positionZ = position.z;
        }

        private void FixedUpdate()
        {
            if (transform.position.y <= endPositionY)
            {
                transform.position = new Vector3(
                        positionX,
                        startPositionY,
                        positionZ
                    );
            }

            transform.position -= new Vector3(
                    positionX,
                    movingSpeedY * Time.fixedDeltaTime,
                    positionZ
                );
        }
    }
}
