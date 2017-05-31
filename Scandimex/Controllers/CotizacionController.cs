using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scandimex.Models;

namespace Scandimex.Controllers
{
    public class CotizacionController : Controller
    {
        CommonClass _common = new CommonClass();
        //
        // GET: /Cotizacion/

        public ActionResult Index(string _Filtro)
        {
            try
            {
                var _ListCotizaciones = (from m in _common.bd.Cotizacion
                                         select m).ToList(); ;

                if (!String.IsNullOrEmpty(_Filtro))
                {
                    _ListCotizaciones = _ListCotizaciones.Where(s => s.CodigoInterno.Contains(_Filtro)).ToList();
                }

                return View(_ListCotizaciones);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        private List<CotizacionProducto> getCotProductos(int _id)
        {
            return (from p in _common.bd.CotizacionProducto
                    where p.CotizacionId == _id
                    select p).ToList();

        }
        private List<CotizacionProducto> getCotProductos()
        {
            return (from p in _common.bd.CotizacionProducto
                    select p).ToList();
        }

        private List<CotizacionServicio> getCotServicios(int _id)
        {
            return (from p in _common.bd.CotizacionServicio
                    where p.CotizacionId == _id
                    select p).ToList();

        }
        private List<CotizacionServicio> getCotServicios()
        {
            return (from p in _common.bd.CotizacionServicio
                    select p).ToList();
        }

        //
        // GET: /Cotizacion/Details/5

        public ActionResult Details(int _id)
        {
            try
            {
                var _ListCotizacion = _common.bd.Cotizacion.Find(_id);

                if (_ListCotizacion != null)
                {
                    ViewBag.CotServicios = getCotServicios(_id);
                    ViewBag.CotProductos = getCotProductos(_id);
                }

                return View(_ListCotizacion);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public JsonResult ObtenerCiudad(String _CodigoPais)
        {
            List<Ciudad> _ListCiudades = null;
            if (!String.IsNullOrEmpty(_CodigoPais))
            {
                _ListCiudades = _common.GetCiudades(_CodigoPais);
            }
            return Json(_ListCiudades, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Cotizacion/Create

        public ActionResult Create()
        {
            ViewBag.Paises = _common.GetPaises();
            ViewBag.Ciudades = _common.GetCiudades();
            ViewBag.Clientes = _common.GetClientes();

            return View();
        }

        //
        // POST: /Cotizacion/Create
        //public ActionResult Create(Cotizaciones _cotizacion, FormCollection _Formulario, PartialViewResult _Particiones)

        [HttpPost]
        public ActionResult Create(Cotizaciones _cotizacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.Cotizacion.Add(_cotizacion);
                    _common.bd.SaveChanges();

                    return this.RedirectToAction("Index");
                }

                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                
                ViewBag.Paises = _common.GetPaises();
                ViewBag.Ciudades = _common.GetCiudades();
                ViewBag.Clientes = _common.GetClientes();
                return View();
            }
            catch (Exception ex)
            {
                return this.View("Error", ex);
            }
        }

        //
        // GET: /Cotizacion/Edit/5

        public ActionResult Edit(int _id)
        {
            if (_id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cotizaciones _cot = _common.bd.Cotizacion.Find(_id);

            if (_cot == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Paises = _common.GetPaises();
                ViewBag.Ciudades = _common.GetCiudades();
                ViewBag.Clientes = _common.GetClientes();

                ViewBag.CotServicios = getCotServicios(_id);
                ViewBag.CotProductos = getCotProductos(_id);
            }

            return View(_cot);
        }

        //
        // POST: /Cotizacion/Edit/5

        [HttpPost]
        public ActionResult Edit(int _id, Cotizaciones _Cotizacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.Entry(_Cotizacion).State = EntityState.Modified;
                    _common.bd.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(_Cotizacion);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /Cotizacion/Delete/5

        public ActionResult Delete(int _id)
        {
            if (_id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cotizaciones _cot = _common.bd.Cotizacion.Find(_id);

            if (_cot == null)
            {
                return HttpNotFound();
            }

            ViewBag.CotServicios = getCotServicios(_id);
            ViewBag.CotProductos = getCotProductos(_id);

            return View(_cot);
        }

        //
        // POST: /Cotizacion/Delete/5

        [HttpPost]
        public ActionResult Delete(int _id, Cotizaciones _cotizacion)
        {
            try
            {
                Cotizaciones _cot = _common.bd.Cotizacion.Find(_id);

                if (_cot != null)
                {
                    _common.bd.Cotizacion.Remove(_cot);
                    _common.bd.SaveChanges();
                    return RedirectToAction("Index");
                }


                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
