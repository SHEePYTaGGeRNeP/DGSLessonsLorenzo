using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HealthSystemTests
    {
        private const int _DEFAULT_MAX_HP = 100;
        private const int _DEFAULT_DMG_OR_HEAL = 20;

        private static HealthSystem CreateHealthSystem(int maxHp, int currentHp) => HealthSystem.CreateHealthSystem(new GameObject(), maxHp, currentHp);
        private static HealthSystem CreateHealthSystem() => CreateHealthSystem(_DEFAULT_MAX_HP, _DEFAULT_MAX_HP);

        [Test]
        public void Can_Create()
        {
            HealthSystem hs = CreateHealthSystem();
            Assert.IsNotNull(hs);
        }

        [Test]
        public void Healing_MoreThanZero_IncreasesHP()
        {
            HealthSystem hs = CreateHealthSystem(_DEFAULT_MAX_HP, _DEFAULT_DMG_OR_HEAL * 2);
            hs.Heal(_DEFAULT_DMG_OR_HEAL);
            Assert.AreEqual(_DEFAULT_DMG_OR_HEAL, hs.CurrentHealth);
        }

        [Test]
        public void Healing_Zero_HPStaysSame()
        {
            HealthSystem hs = CreateHealthSystem(_DEFAULT_MAX_HP, _DEFAULT_DMG_OR_HEAL);
            hs.Heal(0);
            Assert.AreEqual(_DEFAULT_DMG_OR_HEAL, hs.CurrentHealth);
        }

        [Test]
        public void Healing_DoesNotExceedMax()
        {
            HealthSystem hs = CreateHealthSystem();
            hs.Heal(_DEFAULT_MAX_HP);
            Assert.AreEqual(_DEFAULT_MAX_HP, hs.CurrentHealth);
        }
    }
}
