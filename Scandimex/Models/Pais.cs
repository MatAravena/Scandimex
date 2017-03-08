using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Scandimex.Models
{
    public class Pais
    {
        [Key]
        [StringLength(3, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "País Abreviación")]
        public String PaisAbreviacion { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "País")]
        public String PaisNombre { get; set; }


        [Display(Name = "Orden")]
        public int PaisOrden { get; set; }
    }


}
