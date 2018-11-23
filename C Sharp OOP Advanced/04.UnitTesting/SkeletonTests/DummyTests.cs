using NUnit.Framework;

namespace SkeletonTests
{
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealthAfterAttack()
        {
            var dummy = new Dummy(10, 20);
            dummy.TakeAttack(10);
            Assert.AreEqual(0, dummy.Health);
        }
    }
}
