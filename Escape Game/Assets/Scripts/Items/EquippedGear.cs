using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class EquippedGear : MonoBehaviour
    {
        private readonly Dictionary<GearSlot, ItemSO> _gear = new Dictionary<GearSlot, ItemSO>();
        
        public void Equip(ItemSO item)
        {
            ItemSO equippedItem = this.GetItemFromSlot(item.Slot);
            if (equippedItem != null)
                this.Unequip(equippedItem);
            this._gear[item.Slot] = item;
            item.Equip(this.gameObject);
        }

        public void Unequip(ItemSO item)
        {
            if (!this.IsEquipped(item))
                throw new ArgumentException("Item is not equipped");
            this._gear.Remove(item.Slot);
            item.UnEquip(this.gameObject);
        }

        public ItemSO GetItemFromSlot(GearSlot slot)
        {
            if (this._gear.ContainsKey(slot))
                return this._gear[slot];
            return null;
        }

        public bool IsEquipped(ItemSO item)
        {
            if (item.Slot == GearSlot.None)
                throw new ApplicationException("Can't add an item with slot None");
            if (!this._gear.ContainsKey(item.Slot))
                return false;
            return this._gear[item.Slot] == item;
        }
    }
}
