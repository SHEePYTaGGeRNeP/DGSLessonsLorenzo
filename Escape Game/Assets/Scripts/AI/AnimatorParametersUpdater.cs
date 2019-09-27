﻿using UnityEngine;
using Assets.Scripts.AI.Sensors;

namespace Assets.Scripts.AI
{
    public class AnimatorParametersUpdater : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private PlayerTouchSensor3D _sensor;
        public PlayerTouchSensor3D Sensor => _sensor;

        [SerializeField]
        private float _attackRange = 1f;

        private Vector3 _startPos;
        private const float _STARTPOS_TOLERANCE = 1f;

        /// <summary>We don't want to attack whenever we enter AttackBehavior, because it might be getting in and out of range.</summary>
        public float LastAttackTime { get; set; }

        private void Awake()
        {
            this._startPos = this.transform.position;
        }

        private void Update()
        {
            _animator.SetBool(AnimatorParameters.IN_RANGE_FOR_CHASE, _sensor.IsTouching);
            _animator.SetBool(AnimatorParameters.IN_ORIGINAL_SPOT, Vector3.Distance(this.transform.position, this._startPos) < _STARTPOS_TOLERANCE);

            if (!this._sensor.IsTouching)
            {
                _animator.SetBool(AnimatorParameters.IN_RANGE_FOR_ATTACK, false);
                return;
            }
            _animator.SetBool(AnimatorParameters.IN_RANGE_FOR_ATTACK, Vector3.Distance(this.transform.position, _sensor.Player.transform.position) < _attackRange);
            
        }
    }
}
