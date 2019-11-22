using UnityEngine;

namespace Assets.Scripts.Items.Behaviors
{
    public interface IItemBehavior
    {
        void OnEquip(GameObject owner);
        void OnUnequip(GameObject owner);
    }
}