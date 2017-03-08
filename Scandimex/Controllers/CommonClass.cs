using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scandimex.Models;

namespace Scandimex.Controllers
{
    public class CommonClass
    {
        public ScandimexContexto bd = new ScandimexContexto();

        public List<Pais> GetPaises()
        {
            try
            {
                var _Lst = (from p in bd.Paises
                            orderby p.PaisOrden, p.PaisNombre ascending
                            select p).ToList();

                return _Lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Ciudad> GetCiudades(String _Abreviacion)
        {
            try
            {
                var _Lst = (from p in bd.Ciudades

                            where p.PaisAbreviacion == _Abreviacion
                            orderby p.CiudadNombre ascending
                            select p).ToList();

                return _Lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Ciudad> GetCiudades()
        {
            try
            {
                var _Lst = (from c in bd.Ciudades
                            join p in bd.Paises on c.PaisAbreviacion equals p.PaisAbreviacion
                            orderby p.PaisNombre ascending
                            select c).ToList();

                return _Lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Clientes> GetClientes()
        {
            try
            {
                var _Lst = (from c in bd.Clientes
                            orderby c.NombreCompañia ascending
                            select c).ToList();
                return _Lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Clientes> GetClientes(String _NombreCom)
        {
            try
            {
                var _Lst = (from c in bd.Clientes
                            where c.NombreCompañia.Contains(_NombreCom)
                            orderby c.NombreCompañia ascending
                            select c).ToList();
                return _Lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<TipoProductoSub> GetSubProductos(int _CodigoTipoProducto)
        {
            try
            {
                var _Lst = (from tp in bd.TipoProductoSub
                            where tp.TipoProductoCodigo == _CodigoTipoProducto
                            orderby tp.NombreSubCategoria ascending
                            select tp).ToList();

                return _Lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}