using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Items.Behaviors
{
    [CreateAssetMenu(fileName = "IncreaseMovementSpeedBehavior", menuName = "Items/Behaviors/CreateIncreaseMovementSpeedBehavior", order = 0)]
    public class IncreaseMovementSpeedBehavior : ItemBehavior
    {
        [SerializeField]
        private float _movementSpeed = 1f;
        public float MovementSpeed { get => this._movementSpeed; set { this._movementSpeed = value; } }
        public override void OnEquip(GameObject owner)
        {
            SimpleMovement hs = owner.GetComponentInChildren<SimpleMovement>();
            hs.Speed += this._movementSpeed;
        }
        public override void OnUnequip(GameObject owner)
        {
            SimpleMovement hs = owner.GetComponentInChildren<SimpleMovement>();
            hs.Speed -= this._movementSpeed;
        }
    }
}
