using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCameras _cameraRep;
        private ShopCart _shopCart;
        private HomeController _homeController;
        public ShopCartController(IAllCameras cameraRep, ShopCart shopCart)

        {
            _cameraRep = cameraRep;
            _shopCart = shopCart;
            
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel { shopCart = _shopCart };
            return View(obj);
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = _cameraRep.Cameras.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult changesAvailbleRemove(int id)
        {
            _shopCart.ChangesAvailbleRemove(id);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult changesAvailbleAdd(int id)
        {
            _shopCart.ChangesAvailbleAdd(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public RedirectToActionResult changesAvailbleSearh(string str)
        {
            _shopCart.ChangesAvailbleSearch(str);
            return RedirectToAction("Index", "Home");
        }
        
        public RedirectToActionResult removeFromCart(string id)
        {
            _shopCart.RemoveFromCart(id);
            return RedirectToAction("Home/Index");
        }
    }
}
