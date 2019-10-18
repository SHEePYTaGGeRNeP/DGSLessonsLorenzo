using Assets.Scripts.Game;
using Assets.Scripts.Items;
using Assets.Scripts.Items.Behaviors;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class ItemTests
    {
        [Test]
        public void Equipping_HpItem_ChangesMaxHealth()
        {
            const int hpIncrease = 10;
            GameObject go = new GameObject();
            HealthSystem hs = HealthSystem.CreateHealthSystem(go, 50);
            EquippedGear eg = go.AddComponent<EquippedGear>();
            ItemSO item = ScriptableObject.CreateInstance<ItemSO>();
            item.Slot = GearSlot.Head;
            var behavior = ScriptableObject.CreateInstance<IncreaseHpItemBehavior>();
            behavior.HpIncrease = hpIncrease;
            item.SetBehaviors(new[] { behavior });
            int currentMaxHp = hs.MaxHealth;

            eg.Equip(item);
            Assert.AreEqual(currentMaxHp + hpIncrease, hs.MaxHealth);
            eg.Unequip(item);
            Assert.AreEqual(currentMaxHp, hs.MaxHealth);
        }
    }
}
