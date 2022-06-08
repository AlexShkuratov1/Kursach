using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Nest;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        public void ChangesAvailble(int id)
        {
            foreach (var item in appDBContent.Camera.Where(x => x.id == id))
            {
                item.available = false;
            }
            appDBContent.SaveChanges();
        }
        public void ChangesAvailbleRemove(int id)
        {
            foreach (var item in appDBContent.Camera.Where(x => x.id == id))
            {
                item.available = false;
            }
            appDBContent.SaveChanges();
        }
        public void ChangesAvailbleAdd(int id)
        {
            foreach (var item in appDBContent.Camera.Where(x => x.id == id))
            {
                item.available = true;
            }
            appDBContent.SaveChanges();
        }
        
        public void ChangesAvailbleSearch(string str)
        {
            foreach (var item in appDBContent.Camera.Where(x => x.name != str))
            {
                item.available = false;
            }
            foreach (var item in appDBContent.Camera.Where(x => x.name == str))
            {
                item.available = true;
            }
            appDBContent.SaveChanges();
        }
        public void AddToCart(Camera camera)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                camera = camera,
                price = camera.price
            }
                );
            appDBContent.SaveChanges();
        }
        public void RemoveFromCart(string id)
        {
            var item = appDBContent.ShopCartItem.Where(x => x.ShopCartId == id);
            appDBContent.ShopCartItem.RemoveRange(item);
            appDBContent.SaveChanges();
        }
        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s=>s.camera).ToList();
        }
    }
}
