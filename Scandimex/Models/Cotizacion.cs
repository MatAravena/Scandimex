using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    public class Cotizaciones //: IValidatableObject
    {

        [JsonProperty]
        [Key]
        public int CotizacionId { get; set; }

        [Display(Name = "Código Interno")]
        [Required]
        public String CodigoInterno { get; set; }


        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime FechaCotizacion { get; set; }


        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Clientes Cliente { get; set; }


        [Display(Name = "Monto de Cotización")]
        public double? MontoCotizacion { get; set; }

        [Display(Name = "Monto Comprado")]
        public double? MontoComprado { get; set; }


        [StringLength(5000, MinimumLength = 3)]
        [Display(Name = "Requerimiento")]
        public String Requerido { get; set; }


        [StringLength(5000, MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }


        //[DataCompareValidation("PlazoEntregaHasta", ErrorMessage = "Return date should be later than loan date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Plazo Desde")]
        public DateTime PlazoEntregaDesde { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Plazo Hasta")]
        public DateTime PlazoEntregaHasta { get; set; }


        //IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        //{
        //    List<ValidationResult> res = new List<ValidationResult>();
        //    if (PlazoEntregaHasta < PlazoEntregaDesde)
        //    {
        //        ValidationResult mss = new ValidationResult("Fecha plazo desde debe ser mayor a la fecha hasta.");
        //        res.Add(mss);
        //    }
        //    return res;
        //}

        [Display(Name = "Garantía")]
        [StringLength(500, MinimumLength = 3)]
        public String Garantia { get; set; }

        [Display(Name = "Condiciones de Pago")]
        [StringLength(500, MinimumLength = 3)]
        public String CondicionesPago { get; set; }

         [Display(Name = "País")]
        public String PaisAbreviacion { get; set; }
        [ForeignKey("PaisAbreviacion")]
        public virtual Pais Pais { get; set; }


        [Display(Name = "Ciudad")]
        public int CiudadCodigo { get; set; }
        [ForeignKey("CiudadCodigo")]
        public virtual Ciudad Ciudad { get; set; }


        [StringLength(500, MinimumLength = 3)]
        //[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }

        [StringLength(50, MinimumLength = 3)]
        //[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ' ,.]*$")]
        [Display(Name = "Validez")]
        public String Validez { get; set; }


        [Display(Name = "Aceptación")]
        public Boolean Aceptacion { get; set; }

        //public IEnumerable<CotizacionServicio> CotServicios { get; set; }
        //public IEnumerable<CotizacionProducto> CotProducto { get; set; }

        //public List<CotizacionServicio> CotServicios { get; set; }
        //public List<CotizacionProducto> CotProducto { get; set; }

        //public List<CotizacionArchivo> CotArchivos { get; set; }

    }
    
}
