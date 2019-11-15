using Assets.Scripts.AI.Sensors;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.Game
{
    class Turret : MonoBehaviour
    {
        [SerializeField]
        [Range(0.01f, 60f)]
        private int _cooldown = 1;

        [SerializeField]
        private GameObject _bulletToSpawn;

        [SerializeField]
        private TouchSensor3D _touchSensor;

        [SerializeField]
        [Range(0.1f, 100f)]
        private float _rotationSpeed;

        [SerializeField]
        private Transform _bulletSpawnLocation;

        private float _timeOfLastShot;

        [Header("Debug")]
        [SerializeField]
        private Vector3 _side;

        private void Update()
        {
            if (!_touchSensor.IsTouching)
                return;
            this.RotateTowardsTarget();
            this.TryShoot();
        }

        private void RotateTowardsTarget()
        {
            _side = Utils.ObjectSide(this.transform, _touchSensor.TouchingGameObjects.First().transform.position);
            Debug.DrawRay(this.transform.position, this._side * 3, Color.cyan, 0.2f);
            this.transform.Rotate(0, this._side.x * this._rotationSpeed, 0);
        }

        private void TryShoot()
        {
            if (this._side.x < 0.5f && Time.time - _timeOfLastShot > this._cooldown)
            {
                Instantiate(_bulletToSpawn, _bulletSpawnLocation.position, this.transform.rotation);
                _timeOfLastShot = Time.time;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Color prev = Gizmos.color;
            Gizmos.color = Color.white;
            Gizmos.DrawLine(this.transform.position.AddY(0.5f), this.transform.position.AddY(0.5f) + this.transform.forward * 5);
            Gizmos.color = prev;
        }
    }
}
