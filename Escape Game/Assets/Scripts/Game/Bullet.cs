using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve _velocityIncrease;

        [SerializeField]
        private float _startVelocity;

        [SerializeField]
        private float _lifeTime = 10f;

        private float _currentVelocity;
        private float _startTime;

        private void Start()
        {
            this._startTime = Time.time;
            this._currentVelocity = this._startVelocity;
        }

        void Update()
        {
            if (Time.time - this._startTime > this._lifeTime)
                Destroy(this.gameObject);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float evaluated = this._velocityIncrease.Evaluate(Time.time - this._startTime);
            this._currentVelocity += evaluated * Time.fixedDeltaTime;
            this.transform.position += this.transform.forward * _currentVelocity ;
        }

        private void OnTriggerEnter(Collider other)
        {
            this.StartCoroutine(DestroyNextFrame());
        }
        private void OnCollisionEnter(Collision other)
        {
            this.StartCoroutine(DestroyNextFrame());
        }

        private IEnumerator DestroyNextFrame()
        {
            yield return null;
            Destroy(this.gameObject);
        }
    }
}