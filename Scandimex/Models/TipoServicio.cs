using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class TipoServicio
    {
        [Key]
        public int TipoServicioCodigo { get; set; }

        [StringLength(70, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "Tipo Servicio")]
        public String NombreTipoServicio { get; set; }
    }
}