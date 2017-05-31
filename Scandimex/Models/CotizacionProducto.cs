using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class CotizacionProducto
    {
        [Key]
        public int CotProdId { get; set; }

        public int CotizacionId { get; set; }
        [ForeignKey("CotizacionId")]
        public virtual Cotizaciones Cotizacion { get; set; }


        [Display(Name = "Tipo Producto")]
        public int TipoProductoCodigo { get; set; }
        [ForeignKey("TipoProductoCodigo")]
        public virtual TipoProductos TipoProductos { get; set; }


        [Display(Name = "Sub Tipo Producto")]
        public int SubProductoCodigo { get; set; }
        [ForeignKey("SubProductoCodigo")]
        public virtual TipoProductoSub TipoProductoSub { get; set; }


        [StringLength(70, MinimumLength = 3)]
        //[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "Sub Categoría")]
        public String SubCategoría { get; set; }


        [StringLength(5000, MinimumLength = 3)]
        //[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }


        [Display(Name = "Valor Unitario")]
        public Double ValorUnitario { get; set; }

        [Display(Name = "Cantidad")]
        public Double Cantidad { get; set; }

        [Display(Name = "Total")]
        public Double ValorFinal { get; set; }

    }
}
