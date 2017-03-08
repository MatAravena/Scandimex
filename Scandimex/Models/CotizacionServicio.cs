using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class CotizacionServicio
    {
        [Key]
        public Int32 CotServId { get; set; }

        public int CotizacionId { get; set; }
        [ForeignKey("CotizacionId")]
        public virtual Cotizaciones Cotizacion { get; set; }


        [Display(Name = "Tipo Servicio")]
        public int TipoServicioCodigo { get; set; }
        [ForeignKey("TipoServicioCodigo")]
        public virtual TipoServicio TipoServicio { get; set; }


        [StringLength(70, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "Sub Categoría")]
        public String SubCategoría { get; set; }

        [StringLength(5000, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }


        [Display(Name = "Horas de Servicio")]
        public double HorasServicio { get; set; }

        [Display(Name = "Valor Hora")]
        public double ValorHora { get; set; }

        [Display(Name = "Total")]
        public double ValorFinal { get; set; }

    }
}
