using System;
using System.Collections.Generic;
using MNStoneStore.Domain.Entities;

namespace MNStoneStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);
        Product DeleteProduct(int productID);
    }
}
