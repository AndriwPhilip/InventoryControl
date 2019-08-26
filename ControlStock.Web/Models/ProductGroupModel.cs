using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlStock.Web.Models
{
    public class ProductGroupModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome!")]
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}