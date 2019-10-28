using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts.UI
{
    class ItemEquipper : MonoBehaviour
    {
        [SerializeField]
        private ItemSO _itemToEquip;

        [SerializeField]
        private EquippedGear _gear;
        
        public void Equip()
        {
            _gear.Equip(_itemToEquip);
        }
    }
}
