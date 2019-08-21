using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlStock.Web.Models
{
    public class ProductGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}