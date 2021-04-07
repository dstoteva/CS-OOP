using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void MockDemo()
        {
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
            Mock<ITarget> mockTarget = new Mock<ITarget>();

            mockWeapon.Setup(t => t.Attack(mockTarget.Object));

            mockTarget.Setup(t => t.GiveExperience()).Returns(() => 55);

            var exp = mockTarget.Object.GiveExperience();

            Hero batman = new Hero("Batman", mockWeapon.Object);
        }
    }
}
