using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }

        [StringLength(70, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Required]
        [Display(Name = "Nombre Compañía")]
        public String NombreCompañia { get; set; }

        //Agregar Rut
        [Display(Name = "Rut")]
        [RegularExpression(@"^([0-9]+-[0-9Kk])$")]
        public String Rut { get; set; }

        [Display(Name = "Dirección")]
        public String Direccion { get; set; }


        [Display(Name = "Código Postal")]
        public int? CódigoPostal { get; set; }


        [RegularExpression(@"^([0-9 \.\&\'\-\+\(\)]+)$", ErrorMessage = "Debe ingresar un teléfono válido de la nueva empresa.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fono Fijo")]
        public String LandLinePhone { get; set; }
        [RegularExpression(@"^([0-9 \.\&\'\-\+\(\)]+)$", ErrorMessage = "Debe ingresar un teléfono válido de la nueva empresa.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fono Celular")]
        public String PhoneMovil { get; set; }


        [RegularExpression(@"^([a-zA-Z0-9 \.\&\'\-]+)$", ErrorMessage = "Invalid Fax")]
        public String Fax { get; set; }


        [Display(Name = "País")]
        public String PaisAbreviacion { get; set; }
        [ForeignKey("PaisAbreviacion")]
        public virtual Pais Pais { get; set; }


        [Display(Name = "Ciudad")]
        public int CiudadCodigo { get; set; }
        [ForeignKey("CiudadCodigo")]
        public virtual Ciudad Ciudad { get; set; }

        public virtual List<PersonaContacto> ListadoContactos { get; set; }
    }
}