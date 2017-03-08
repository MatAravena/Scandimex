using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class TipoProductos
    {
        [Key]
        public int TipoProductoCodigo { get; set; }

        [StringLength(70, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "Tipo Producto")]
        public String NombreTipoProducto { get; set; }

    }
}