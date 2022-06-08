using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
       
        public int id { get; set; }

        [Display(Name="Имя")]
        [StringLength(5)]
        [Required(ErrorMessage ="Длинна имени не менее 5 символов")]

        public string name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длинна фамилии не менее 5 символов")]
        public string surname { get; set; }
        [Display(Name = "Адрес")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длинна адреса не менее 5 символов")]
        public string adress { get; set; }
        [Display(Name = "Телефон")]
        [StringLength(18)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длинна телефона не менее 8 символов")]
        public string phone { get; set; }
        [Display(Name = "email")]
        [StringLength(35)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длинна email не менее 8 символов")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDatail { get; set; }

    }
}
