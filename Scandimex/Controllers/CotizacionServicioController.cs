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
    public class CotizacionServicioController : Controller
    {
        CommonClass _common = new CommonClass();
        //
        // GET: /CotizacionServicio/

        public ActionResult Index(int _Filtro)
        {
            try
            {
                var _ListCotizaciones = (from m in _common.bd.CotizacionServicio
                                         select m).ToList();

                if (_Filtro != 0)
                {
                    _ListCotizaciones = (from m in _common.bd.CotizacionServicio
                                         where m.CotizacionId == _Filtro
                                         select m).ToList();
                }

                return View(_ListCotizaciones);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /CotizacionServicio/Details/5

        public ActionResult Details(int _id, int _IdCotizacion)
        {
            try
            {
                var _ListCotizacion = _common.bd.CotizacionServicio.Find(_id);
                ViewBag.TipoServicios = from ts in _common.bd.TipoServicio orderby ts.NombreTipoServicio ascending select ts;

                Cotizaciones cot = _common.bd.Cotizacion.Find(_IdCotizacion);
                ViewBag.CotizacionID = cot.CotizacionId;
                ViewBag.CotizacionCodInter = cot.CodigoInterno;

                return View(_ListCotizacion);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /CotizacionServicio/Create

        public ActionResult Create(int _id)
        {

            Cotizaciones cot = _common.bd.Cotizacion.Find(_id);
            ViewBag.CotizacionID = cot.CotizacionId;
            ViewBag.CotizacionCodInter = cot.CodigoInterno;

            ViewBag.TipoServicios = from ts in _common.bd.TipoServicio orderby ts.NombreTipoServicio ascending select ts;
            return View();
        }

        //
        // POST: /CotizacionServicio/Create

        [HttpPost]
        public ActionResult Create(CotizacionServicio _CotServ, int? CotId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.CotizacionServicio.Add(_CotServ);
                    _common.bd.SaveChanges();
                    return RedirectToAction("Details", "Cotizacion", new { _id = _CotServ.CotizacionId });
                }

                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();

                return View(_CotServ);
            }
            catch (Exception ex)
            {
                return this.View("Error", ex);
            }
        }

        //
        // GET: /CotizacionServicio/Edit/5

        public ActionResult Edit(int _id, int _IdCotizacion)
        {
            if (_id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CotizacionServicio _cot = _common.bd.CotizacionServicio.Find(_id);

            if (_cot == null)
            {
                return HttpNotFound();
            }

            Cotizaciones cot = _common.bd.Cotizacion.Find(_IdCotizacion);
            ViewBag.CotizacionID = cot.CotizacionId;
            ViewBag.CotizacionCodInter = cot.CodigoInterno;

            ViewBag.TipoServicios = from ts in _common.bd.TipoServicio orderby ts.NombreTipoServicio ascending select ts;

            return View(_cot);
        }

        //
        // POST: /CotizacionServicio/Edit/5

        [HttpPost]
        public ActionResult Edit(int _id, CotizacionServicio _cot)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.Entry(_cot).State = EntityState.Modified;
                    _common.bd.SaveChanges();
                    return RedirectToAction("Details", "Cotizacion", new { _id = _cot.CotizacionId });
                }

                return View(_cot);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /CotizacionServicio/Delete/5

        public ActionResult Delete(int _id, int _IdCotizacion)
        {
            if (_id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CotizacionServicio _cot = _common.bd.CotizacionServicio.Find(_id);

            if (_cot == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipoServicios = from ts in _common.bd.TipoServicio orderby ts.NombreTipoServicio ascending select ts;

            return View(_cot);
        }

        //
        // POST: /CotizacionServicio/Delete/5

        [HttpPost]
        public ActionResult Delete(int _id, CotizacionServicio _CotServ)
        {
            try
            {
                CotizacionServicio _cot = _common.bd.CotizacionServicio.Find(_id);
                if (ModelState.IsValid)
                {
                    Int32 id = _cot.CotizacionId;
                    _common.bd.CotizacionServicio.Remove(_cot);
                    _common.bd.SaveChanges();
                    return RedirectToAction("Details", "Cotizacion", new { _id = id });
                }

                return View();
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public JsonResult ObtenerSubTipoProducto(String _CodigoTipoProducto)
        {
            List<TipoProductoSub> _ListSubTipoProducto = null;
            if (!String.IsNullOrEmpty(_CodigoTipoProducto))
            {
                int codigoSubProducto;
                if (int.TryParse(_CodigoTipoProducto, out codigoSubProducto))
                {
                    _ListSubTipoProducto = _common.GetSubProductos(codigoSubProducto);
                }
            }
            return Json(_ListSubTipoProducto, JsonRequestBehavior.AllowGet);
        }
    }
}
