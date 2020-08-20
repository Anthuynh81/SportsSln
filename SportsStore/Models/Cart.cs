using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItems(Product product, int quantity, string productUrl)
        {
            CartLine line = Lines
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity,
                    ProductUrl = productUrl
                });
            } else
            {
                line.Quantity += quantity;
                line.ProductUrl = productUrl;
            }
        }

        public virtual void RemoveLine(Product product) =>
            Lines.RemoveAll(l => l.Product.ProductID == product.ProductID);

        public decimal ComputeTotalValue() =>
            Lines.Sum(l => l.Product.Price * l.Quantity);

        public virtual void Clear() => Lines.Clear();
    }

    public class CartLine 
    { 
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string ProductUrl { get; set; }
    }

}
