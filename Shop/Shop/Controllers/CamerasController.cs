using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Shop.Controllers
{
    public class CamerasController : Controller
    {
        private readonly IAllCameras _allCameras;
        private readonly ICamerasCategory _allCategories;
        public CamerasController(IAllCameras iAllCameras, ICamerasCategory iCamerasCategory)
        {
            _allCameras = iAllCameras;
            _allCategories = iCamerasCategory;
        }
        [Route("Cameras/List")]
        [Route("Cameras/List/{Category}")]
        
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Camera> cameras = null;
            string currCategory = "";
            if(string.IsNullOrEmpty(category))
            {
                cameras = _allCameras.Cameras.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("IP", category, StringComparison.OrdinalIgnoreCase))
                {
                    cameras = _allCameras.Cameras.Where(i => i.Category.categoryName.Equals("IP")).OrderBy(i => i.id).Where(i=>i.available == true);
                }
                else if (string.Equals("WIFI", category, StringComparison.OrdinalIgnoreCase))
                { 
                
                    cameras = _allCameras.Cameras.Where(i => i.Category.categoryName.Equals("WIFI")).OrderBy(i => i.id).Where(i => i.available == true);
                }
                else if (string.Equals("VideoRecorder", category, StringComparison.OrdinalIgnoreCase))
                {

                    cameras = _allCameras.Cameras.Where(i => i.Category.categoryName.Equals("VideoRecorder")).OrderBy(i => i.id).Where(i => i.available == true);
                }
                else if (string.Equals("Cable", category, StringComparison.OrdinalIgnoreCase))
                {

                    cameras = _allCameras.Cameras.Where(i => i.Category.categoryName.Equals("Cable")).OrderBy(i => i.id).Where(i => i.available == true);
                }

                currCategory = _category;
                

            }
            
            var cameraobj = new CamerasListViewModel
            {

                allCameras = cameras,
                currCategory = currCategory
            };
            ViewBag.Title = "Страница с камерами";
           
            
            return View(cameraobj);
        }

    }
}
