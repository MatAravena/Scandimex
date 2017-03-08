using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class TipoPago
    {

        [Key]
        public Int32 TipoPagoId { get; set; }


        [Display(Name = "Tipo Pago")]
        [Required]
        public String TipoPAgo { get; set; }

    }
}