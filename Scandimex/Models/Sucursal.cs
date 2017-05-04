using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class Sucursal
    {
        [Key]
        public int IdCliente { get; set; }
    }
}