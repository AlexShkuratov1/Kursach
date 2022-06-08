using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
/*<li class="nav-item">
                            <a class="nav-link" asp-controller="Home" asp-action="Index">Поиск</a>
                        </li>
 <form class="form-inline mt-2 mt-md-0">
                        <input class="form-control mr-sm-2" type="text" placeholder="Поиск" aria-label="Search">
                        <button class="btn btn-outline-success my-2 my-ms-0" type="submit">Поиск</button>
                        <p><a class="btn btn-warning" asp-controller="ShopCart" asp-action="changesAvailbleAdd" asp-route-id="@Model.id">Вернуть</a></p>
                    </form>
<input name="s" placeholder="Поиск" type="search" >
                        <p><a class="btn btn-warning" asp-controller="ShopCart" asp-action="changesAvailbleSearh" asp-route-text="EZVIZ C2C">Вернуть</a></p>
*/
