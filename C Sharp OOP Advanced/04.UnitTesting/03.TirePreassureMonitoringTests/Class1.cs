using _03.TirePreassureMonitoringSystem;
using Moq;
using NUnit.Framework;

namespace _03.TirePreassureMonitoringTests
{
    public class Class1
    {
        private Alarm alarm = new Alarm();


        [TestCase(-1)]
        [TestCase(16)]
        [TestCase(22)]
        public void AlarmOnTest(double testValues)
        {
            alarm.Check(testValues);
            Assert.AreEqual(true, alarm.AlarmOn);
        }

        [TestCase(18)]
        [TestCase(20)]
        public void AlarmOffTest(double testValues)
        {
            alarm.Check(testValues);
            Assert.AreNotEqual(true, alarm.AlarmOn);
        }
    }
}
