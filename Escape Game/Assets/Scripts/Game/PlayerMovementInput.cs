using UnityEngine;

namespace Assets.Scripts.Game
{
    class PlayerMovementInput : MonoBehaviour
    {
        [SerializeField]
        private SimpleMovement _simpleMovement;

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            _simpleMovement.MoveByInput(horizontal, vertical);
        }
    }
}
