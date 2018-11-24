using System;
using System.Collections.Generic;
using System.Text;

namespace _04.TrafficLight
{
    class TrafficLight
    {
        private Signals currentSignal;

        public TrafficLight(string signal)
        {
            currentSignal = (Signals) Enum.Parse(typeof(Signals), signal);
        }

        public void Update()
        {
            var previous = (int)currentSignal;
            currentSignal = (Signals)(++previous % Enum.GetValues(typeof(Signals)).Length);
        }
    }
}