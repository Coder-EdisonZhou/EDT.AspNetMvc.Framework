using System;
using System.Collections.Generic;

namespace Manulife.Web.Mvc.Models
{
    public class ProductStub
    {
        public IList<Product> GetProductList()
        {
            IList<Product> productList = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                Product model = new Product();
                model.Id = 1000 + i;
                model.Name = "Product-" + model.Id.ToString();
            
                productList.Add(model);
            }

            return productList;
        }
    }
}
