using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class Ciudad
    {
        [Key]
        public int CiudadCodigo { get; set; }

        [StringLength(70, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "Ciudad")]
        public String CiudadNombre { get; set; }

        public String PaisAbreviacion { get; set; }
        [ForeignKey("PaisAbreviacion")]
        public virtual Pais Pais { get; set; }
    }
}