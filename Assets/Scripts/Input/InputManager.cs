using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private CharacterController characterController;
        
        public float HorizontalDirection { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterController.SetFireActive(true);
            }

            if (Input.GetKey(KeyCode.A))
            {
                HorizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                HorizontalDirection = 1;
            }
            else
            {
                HorizontalDirection = 0;
            }
        }
        
        private void FixedUpdate()
        {
            character.GetComponent<MoveComponent>().Move(new Vector2(HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}
