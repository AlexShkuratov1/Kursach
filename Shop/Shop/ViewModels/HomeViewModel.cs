using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Camera> favCameras { get; set; }
        public IEnumerable<Camera> available { get; set; }
    }
}
