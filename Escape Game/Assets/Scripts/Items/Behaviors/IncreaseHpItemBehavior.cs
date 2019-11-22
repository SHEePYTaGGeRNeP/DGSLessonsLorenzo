using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Items.Behaviors
{
    [CreateAssetMenu(fileName = "IncreaseHPItemBehavior", menuName = "Items/Behaviors/CreateHpItemBehavior", order = 0)]
    public class IncreaseHpItemBehavior : ItemBehavior
    {
        [SerializeField]
        private int _hpIncrease = 20;
        public int HpIncrease { get => this._hpIncrease; set { this._hpIncrease = value; } }

        public override void OnEquip(GameObject owner)
        {
            IHealthSystem hs = owner.GetComponentInChildren<IHealthSystem>();
            hs.SetMaxHealth(hs.MaxHealth + this.HpIncrease);
            hs.Heal(this.HpIncrease);
        }
        public override void OnUnequip(GameObject owner)
        {
            IHealthSystem hs = owner.GetComponentInChildren<IHealthSystem>();
            hs.SetMaxHealth(hs.MaxHealth - this.HpIncrease);
        }
    }
}
