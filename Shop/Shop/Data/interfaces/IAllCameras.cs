using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.interfaces
{
    public interface IAllCameras
    {
        IEnumerable<Camera> Cameras { get; }
        IEnumerable<Camera> getFavCameras { get;}
        Camera getObjectCamera(int cameraId);
    }
}
