using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class CotizacionArchivo
    {

        [Key]
        public int IdArchivo { get; set; }

        public int CotiId { get; set; }
        [ForeignKey("CotizacionId")]
        public virtual Cotizaciones Cotizacion { get; set; }


        [StringLength(500, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Display(Name = "Description File")]
        public String Descripcion { get; set; }

        [Display(Name = "File")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Archivo { get; set; }

    }
}