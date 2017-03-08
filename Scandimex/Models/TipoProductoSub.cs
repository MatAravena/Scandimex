using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class TipoProductoSub
    {
        [Key]
        public int SubProductoCodigo { get; set; }

        [StringLength(70, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "Sub Tipo Producto")]
        public String NombreSubCategoria { get; set; }

        public int TipoProductoCodigo { get; set; }
        [ForeignKey("TipoProductoCodigo")]
        public virtual TipoProductos TipoProducto { get; set; }
    }
}