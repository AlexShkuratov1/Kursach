using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCameras _cameraRep;
       
        public HomeController(IAllCameras cameraRep)
        {
            _cameraRep = cameraRep;
            
        }
        public ViewResult Index()
        {
            var homeCameras = new HomeViewModel
            {
                favCameras = _cameraRep.getFavCameras
            };
            return View(homeCameras);
        }
    }
}
