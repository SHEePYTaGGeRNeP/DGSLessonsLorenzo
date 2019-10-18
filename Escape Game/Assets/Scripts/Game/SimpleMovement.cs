using UnityEngine;

namespace Assets.Scripts.Game
{
    public class SimpleMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 8f;
        public float Speed { get => this._speed; set => this._speed = value; }

        [SerializeField]
        private float _rotationSpeed = 300f;

        public void MoveByInput(float horizontal, float vertical)
        {
            this.transform.localEulerAngles = this.transform.localEulerAngles.AddY(horizontal * this._rotationSpeed * Time.deltaTime);
            this.transform.position += this.transform.forward * vertical * this._speed * Time.deltaTime;
        }

    }
}
