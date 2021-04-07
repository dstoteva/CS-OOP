using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    class DummyTests
    {
        [Test]
        public void LoseHealth()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }
        [Test]
        public void DeadDummy()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        }

        [Test]
        public void GiveXP()
        {
            Dummy dummy = new Dummy(0, 10);

            int xP = dummy.GiveExperience();

            Assert.AreEqual(10, xP);
        }
        [Test]
        public void CantGiveXP()
        {
            Dummy dummy = new Dummy(2, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
