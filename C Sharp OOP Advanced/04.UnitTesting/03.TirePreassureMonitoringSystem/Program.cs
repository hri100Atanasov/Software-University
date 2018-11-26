using System;

namespace _03.TirePreassureMonitoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var alaram = new Alarm();
            var sensor = new Sensor();
            //var psiValue = sensor.PopNextPressurePsiValue();
            alaram.Check(-1);
            Console.WriteLine(alaram.AlarmOn);
        }
    }
}
