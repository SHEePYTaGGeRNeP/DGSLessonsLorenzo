using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game;
using Assets.Scripts.Helpers;
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
            IHealthSystem hs = CreateHealthSystem();
            Assert.IsNotNull(hs);
        }

        [Test]
        public void Healing_MoreThanZero_IncreasesHP()
        {
            IHealthSystem hs = CreateHealthSystem(_DEFAULT_MAX_HP, _DEFAULT_DMG_OR_HEAL);
            hs.Heal(_DEFAULT_DMG_OR_HEAL);
            Assert.AreEqual(_DEFAULT_DMG_OR_HEAL * 2, hs.CurrentHealth);
        }

        [Test]
        public void Healing_Zero_HPStaysSame()
        {
            IHealthSystem hs = CreateHealthSystem(_DEFAULT_MAX_HP, _DEFAULT_DMG_OR_HEAL);
            hs.Heal(0);
            Assert.AreEqual(_DEFAULT_DMG_OR_HEAL, hs.CurrentHealth);
        }

        [Test]
        public void Healing_OverMax_TurnsToMax()
        {
            IHealthSystem hs = CreateHealthSystem(100, 80);
            hs.Heal(_DEFAULT_MAX_HP);
            Assert.AreEqual(_DEFAULT_MAX_HP, hs.CurrentHealth);
        }

        [Test]
        public void Healing_DoesNotExceedMax()
        {
            IHealthSystem hs = CreateHealthSystem();
            hs.Heal(_DEFAULT_MAX_HP);
            Assert.AreEqual(_DEFAULT_MAX_HP, hs.CurrentHealth);
        }

        [Test]
        public void Healing_Negative_ThrowsException()
        {
            IHealthSystem hs = CreateHealthSystem();
            Assert.Throws<NegativeInputException>(() => hs.Heal(-1));
        }

        [Test]
        public void Damaging_Negative_ThrowsException()
        {
            IHealthSystem hs = CreateHealthSystem();
            Assert.Throws<NegativeInputException>(() => hs.Damage(-1));
        }
        
        [Test]
        public void Damaging_MoreThanZero_DecreasesHP()
        {
            IHealthSystem hs = CreateHealthSystem();
            hs.Damage(_DEFAULT_DMG_OR_HEAL);
            Assert.AreEqual(_DEFAULT_MAX_HP - _DEFAULT_DMG_OR_HEAL, hs.CurrentHealth);
        }

        [Test]
        public void CurrentHP_CannotBeBelow_Zero()
        {
            IHealthSystem hs = CreateHealthSystem(_DEFAULT_MAX_HP, _DEFAULT_DMG_OR_HEAL);
            hs.Damage(_DEFAULT_MAX_HP);
            Assert.AreEqual(0, hs.CurrentHealth);
        }


        [Test]
        public void Damaging_Zero_HPStaysSame()
        {
            IHealthSystem hs = CreateHealthSystem();
            hs.Damage(0);
            Assert.AreEqual(_DEFAULT_MAX_HP, hs.CurrentHealth);
        }

        [Test]
        public void SettingMaxHp_CannotBeBelow1()
        {
            IHealthSystem hs = CreateHealthSystem();
            Assert.Throws<ArgumentException>(() => hs.SetMaxHealth(-1));
            Assert.Throws<ArgumentException>(() => hs.SetMaxHealth(0));
            hs.SetMaxHealth(1);
            Assert.AreEqual(1, hs.MaxHealth);
        }

        [Test]
        public void Damage_Event_Works()
        {
            HealthSystem hs = CreateHealthSystem();
            bool event1Raised, event2Raised;
            event1Raised = event2Raised = false;
            hs.HealthChanged += (sender, args) =>
            {
                event1Raised = true;
            };
            hs.HealthChangedViaDelegate += (damage, hp) =>
            {
                event2Raised = true;
            };
            hs.Damage(_DEFAULT_DMG_OR_HEAL);
            Assert.IsTrue(event1Raised);
            Assert.IsTrue(event2Raised);
        }

        [Test]
        public void Unity_eventWorks()
        {
            var hs = CreateHealthSystem();
            bool event1Raised = false;
            hs.HealthChangedUnity = new UnityHealthChangedEvent();
            hs.HealthChangedUnity.AddListener((HealthChangedEventArgs args) =>
            {
                event1Raised = true;
            });
            hs.Damage(_DEFAULT_DMG_OR_HEAL);
            Assert.IsTrue(event1Raised);
        }
    }
}
