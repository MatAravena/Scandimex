using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Scandimex.Models
{
    public class PersonaContacto
    {
        [Key]
        public Int32 PersonaContactoId { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(70, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        public String Name { get; set; }

        [Display(Name = "Apellidos")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        public String LastName { get; set; }


        [Display(Name = "Posición")]
        //[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        public String Position { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fono Fijo")]
        public String LandLinePhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fono Movil")]
        public String PhoneMovil { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fono Extra")]
        public String PhoneExtra { get; set; }


        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Dirección Email inválida.")]
        public String Email { get; set; }

        [Display(Name = "Email2")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Dirección Email inválida.")]
        public String Email2 { get; set; }


        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Clientes Cliente { get; set; }
    }
}
