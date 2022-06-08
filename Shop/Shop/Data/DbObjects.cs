using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDBContent content)
        {
            
            

            if(!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.Camera.Any())
            {
                content.AddRange(
                    new Camera
                    {
                        name = "Reolink RLC-410-5MP",
                        shortDesc = "уличная IP камера с высоким разрешением",
                        longDesc = "Супер качество картинки",
                        img = "/img/Reolink_RLC.jpg",
                        price = 7000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["IP"]
                    },
                    new Camera
                    {
                        name = "EZVIZ C2C",
                        shortDesc = "Домашняя камера для дистанционного наблюдения",
                        longDesc = "Супер качество картинки",
                        img = "/img/c2c_photos.jpg",
                        price = 10000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["WIFI"]
                    },
                    new Camera
                    {
                        name = "Reolink RLC-445-5MP",
                        shortDesc = "уличная IP камера с высоким разрешением",
                        longDesc = "Супер качество картинки",
                        img = "/img/Reolink2.jpg",
                        price = 15000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["IP"]
                    },
                    new Camera
                    {
                        name = "EZVIZ C8C PTZ",
                        shortDesc = "первая уличная панорамная/наклоняемая камера EZVIZ",
                        longDesc = "Супер качество картинки",
                        img = "/img/c8c.png",
                        price = 14000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["WIFI"]
                    },
                    new Camera
                    {
                        name = "Reolink RLN16-410",
                        shortDesc = "канальный видеорегистратор c PoE питанием",
                        longDesc = "Поддержка до 8 ТБ",
                        img = "/img/rlk16.jpg",
                        price = 14000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["VideoRecorder"]
                    },
                    new Camera
                    {
                        name = "CCA 200м КВК-П",
                        shortDesc = "Кабель",
                        longDesc = "Комбинированный, цена за 10 метров",
                        img = "/img/Cabel1.jpg",
                        price = 500,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Cable"]
                    }

                    );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category {categoryName = "IP" , desc = "IP"},
                        new Category { categoryName = "WIFI", desc = "WIFI"},
                        new Category { categoryName = "VideoRecorder", desc = "VideoRecorde"},
                        new Category { categoryName = "Cable", desc = "Cable"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach(Category el in list)
                    {
                        category.Add(el.categoryName, el);
                    }
                }
                return category;
            }
        }
    }
}
