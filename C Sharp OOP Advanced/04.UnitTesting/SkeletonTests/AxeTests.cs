using NUnit.Framework;

namespace SkeletonTests
{
    public class AxeTests
    {
        [Test]
        public void AxeLoseDurabilityAfterAttack()
        {
            //Arrange
            var axe = new Axe(5, 10);
            var dummy = new Dummy(20, 20);
            //Act
            axe.Attack(dummy);
            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }

        [Test]
        public void BrokenAxeCannotAttack()
        {
            //Arrange
            var axe = new Axe(5, 1);
            var dummy = new Dummy(20, 20);
            //Act
            axe.Attack(dummy);
            //Assert
            Assert.That(()=>axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}