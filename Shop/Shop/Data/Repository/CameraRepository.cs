using Microsoft.EntityFrameworkCore;
using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CameraRepository : IAllCameras
    {
        private readonly AppDBContent appDBContent;
        public CameraRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Camera> Cameras => appDBContent.Camera.Include(c => c.Category);

        public IEnumerable<Camera> getFavCameras => appDBContent.Camera.Where(p => p.isFavourite).Where(p=>p.available == true).Include(c => c.Category);

        public Camera getObjectCamera(int cameraId) => appDBContent.Camera.FirstOrDefault(p => p.id == cameraId);
    }
}
