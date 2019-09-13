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
        [Test]
        public void Can_Create()
        {
            HealthSystem hs = new GameObject().AddComponent<HealthSystem>();
            Assert.IsNotNull(hs);
        }
    }
}
