using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    class Satchel : Bag
    {
        private const int CAPACITY = 20;
        public Satchel() : base(CAPACITY)
        {
        }
    }
}
