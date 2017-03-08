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
    public class CotizacionProductoController : Controller
    {
        CommonClass _common = new CommonClass();
        //
        // GET: /CotizacionProducto/

        public ActionResult Index(int _Filtro)
        {
            try
            {
                List<CotizacionProducto> _ListCotizaciones = null;

                if (_Filtro != 0)
                {
                    _ListCotizaciones = (from m in _common.bd.CotizacionProducto
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
        // GET: /CotizacionProducto/Details/5
        public ActionResult Details(int _id)
        {
            try
            {
                CotizacionProducto _ListCotizacion = _common.bd.CotizacionProducto.Find(_id);

                if (_ListCotizacion != null)
                {
                    ViewBag.TipoProductos = from tp in _common.bd.TipoProducto orderby tp.NombreTipoProducto ascending select tp;
                }
                return View(_ListCotizacion);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /CotizacionProducto/Create

        public ActionResult Create(int _id)
        {
            Cotizaciones cot = _common.bd.Cotizacion.Find(_id);
            ViewBag.CotizacionID = cot.CotizacionId;
            ViewBag.CotizacionCodInter = cot.CodigoInterno;
            ViewBag.TipoProductos = from tp in _common.bd.TipoProducto orderby tp.NombreTipoProducto ascending select tp;

            return View();
        }

        //
        // POST: /CotizacionProducto/Create

        [HttpPost]
        public ActionResult Create(CotizacionProducto _CotProd, int CotizacionId)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    _common.bd.CotizacionProducto.Add(_CotProd);
                    _common.bd.SaveChanges();

                    //return RedirectToAction("Create", "EP", routeValues: new { est = est });
                    return this.RedirectToAction("Index");
                }

                return View(_CotProd);
            }
            catch (Exception ex)
            {
                return this.View("Error", ex);
            }
        }

        //
        // GET: /CotizacionProducto/Edit/5

        public ActionResult Edit(int _id)
        {
            if (_id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CotizacionProducto _cot = _common.bd.CotizacionProducto.Find(_id);

            if (_cot == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipoProductos = from tp in _common.bd.TipoProducto orderby tp.NombreTipoProducto ascending select tp;

            return View(_cot);
        }

        //
        // POST: /CotizacionProducto/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, CotizacionProducto _cot)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.Entry(_cot).State = EntityState.Modified;
                    _common.bd.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(_cot);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /CotizacionProducto/Delete/5

        public ActionResult Delete(int _id)
        {
            if (_id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CotizacionProducto _cot = _common.bd.CotizacionProducto.Find(_id);

            if (_cot == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipoProductos = from tp in _common.bd.TipoProducto orderby tp.NombreTipoProducto ascending select tp;

            return View(_cot);
        }

        //
        // POST: /CotizacionProducto/Delete/5

        [HttpPost]
        public ActionResult Delete(int _id, CotizacionProducto _cotProd)
        {
            try
            {
                CotizacionProducto _cot = _common.bd.CotizacionProducto.Find(_id);
                if (ModelState.IsValid)
                {
                    _common.bd.CotizacionProducto.Remove(_cot);
                    _common.bd.SaveChanges();
                    return RedirectToAction("Index");
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
                if (int.TryParse(_CodigoTipoProducto, out  codigoSubProducto))
                {
                    _ListSubTipoProducto = _common.GetSubProductos(codigoSubProducto);
                }
            }
            return Json(_ListSubTipoProducto, JsonRequestBehavior.AllowGet);
        }
    }
}
