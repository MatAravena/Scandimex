using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scandimex.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class LstCotizaciones
    {
        [JsonProperty]
        public int CotizacionId { get; set; }

        [JsonProperty]
        public String CodigoInterno { get; set; }
        [JsonProperty]
        public DateTime FechaCotizacion { get; set; }

        [JsonProperty]
        public int CotIdProducto { get; set; }

        [JsonProperty]
        public int CotIdServicio { get; set; }

        [JsonProperty]
        public int IdCliente { get; set; }
        [JsonProperty]
        public virtual Clientes Cliente { get; set; }

            
    }
}