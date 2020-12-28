using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StereoShop.Models
{
    public class StereoShopSession
    {
        private const string CartKey = "mycart";
        private const string CountKey = "cartcount";

        private ISession session { get; set; }

        public StereoShopSession(ISession session)
        {
            this.session = session;
        }

        public void SetMyCart(List<Product> products)
        {
            session.SetObject(CartKey, products);
            session.SetInt32(CountKey, products.Count);
        }

        public List<Product> GetMyCart()
        {
            return session.GetObject<List<Product>>(CartKey) ?? new List<Product>();
        }

        public int GetCartProductCount() => session.GetInt32(CountKey) ?? 0;

        public void ClearMyCart()
        {
            session.Remove(CartKey);
            session.Remove(CountKey);
        }
    }
}
