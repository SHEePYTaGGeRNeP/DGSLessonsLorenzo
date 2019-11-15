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
        private float _angleToStartFiring = 35f;

        [SerializeField]
        private TouchSensor3D _touchSensor;

        [SerializeField]
        [Range(0.1f, 1000f)]
        private float _rotationSpeed = 100;

        [SerializeField]
        private Transform _bulletSpawnLocation;

        private float _timeOfLastShot;

        [Header("Debug")]
        [SerializeField]
        private Vector3 _side;

        private void Update()
        {
            if (!this._touchSensor.IsTouching)
                return;
            this.RotateTowardsTarget();
            this.TryShoot();
        }

        private void RotateTowardsTarget()
        {
            this._side = Utils.ObjectSide(this.transform, _touchSensor.TouchingGameObjects.First().transform.position);
            float velocity = this._side.x < 0 ? -1f : 1f;
            this.transform.Rotate(0, velocity * this._rotationSpeed * Time.deltaTime, 0);
        }

        private void TryShoot()
        {
            if (IsTargetInFiringAngle() && Time.time - _timeOfLastShot > this._cooldown)
            {
                Instantiate(_bulletToSpawn, _bulletSpawnLocation.position, this.transform.rotation);
                this._timeOfLastShot = Time.time;
            }
        }

        private bool IsTargetInFiringAngle()
        {
            Vector3 targetDir = this._touchSensor.TouchingGameObjects.First().transform.position - this.transform.position;
            float angleToTarget = Vector3.Angle(targetDir, this.transform.forward);
            return Mathf.Abs(angleToTarget) <= this._angleToStartFiring;// >= -this._angleToStartFiring && angleToTarget <= this._angleToStartFiring);
        }

        private void OnDrawGizmos()
        {
            if (!this._touchSensor.IsTouching)
                return;
            Color prev = Gizmos.color;
            Gizmos.color = IsTargetInFiringAngle() ? Color.red : Color.green;
            Gizmos.DrawLine(this.transform.position, this._touchSensor.TouchingGameObjects.First().transform.position);
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(this.transform.position.AddY(0.5f), this._side);
            Gizmos.color = prev;
        }
    }
}
