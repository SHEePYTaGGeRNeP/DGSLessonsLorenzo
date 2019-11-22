using UnityEngine;

namespace Assets.Scripts.Items.Behaviors
{
    public abstract class ItemBehavior : ScriptableObject, IItemBehavior
    {
        public abstract void OnEquip(GameObject owner);
        public abstract void OnUnequip(GameObject owner);
    }
}
