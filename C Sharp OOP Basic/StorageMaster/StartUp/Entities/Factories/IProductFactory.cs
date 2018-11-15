using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Factories
{
    interface IProductFactory
    {
        Product CreateProduct(string type, double price);
    }
}
