using NUnit.Framework;
using UnityEngine;

namespace Assets.Tests
{
    class ExtensionMethodsTests
    {
        [Test]
        public void Add_AddsToVector()
        {
            Vector3 v = Vector3.one;
            Assert.AreEqual(new Vector3(2, 1, 1), v.AddX(1));
            Assert.AreEqual(new Vector3(1, 2, 1), v.AddY(1));
            Assert.AreEqual(new Vector3(1, 1, 2), v.AddZ(1));
        }
        [Test]
        public void With_ChangesThatAxis()
        {
            Vector3 v = Vector3.one;
            Assert.AreEqual(new Vector3(2, 1, 1), v.WithX(2));
            Assert.AreEqual(new Vector3(1, 2, 1), v.WithY(2));
            Assert.AreEqual(new Vector3(1, 1, 2), v.WithZ(2));
        }
    }

}
