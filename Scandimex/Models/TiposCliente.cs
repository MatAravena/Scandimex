using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class TiposCliente
    {

        [Key]
        public int IDTipoCliente { get; set; }
        public int NombreCategoría { get; set; }

    }
}