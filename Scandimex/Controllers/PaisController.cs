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
    public class PaisController : Controller
    {
        CommonClass _common = new CommonClass();

        //
        // GET: /Pais/

        public ActionResult Index(string _Filtro)
        {
            try
            {
                var _ListPais = (from m in _common.bd.Paises
                                 select m).ToList(); ;

                if (!String.IsNullOrEmpty(_Filtro))
                {
                    _ListPais = _ListPais.Where(s => s.PaisNombre.Contains(_Filtro)).ToList();
                }

                return View(_ListPais);

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /Pais/Details/5

        public ActionResult Details(String _CodigoAbreviacion)
        {
            if (String.IsNullOrEmpty(_CodigoAbreviacion))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pais _pais = _common.bd.Paises.Find(_CodigoAbreviacion);
            if (_pais == null)
            {
                return HttpNotFound();
            }

            return View(_pais);
        }

        //
        // GET: /Pais/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pais/Create

        [HttpPost]
        public ActionResult Create(Pais _pais)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.Paises.Add(_pais);
                    _common.bd.SaveChanges();

                    return this.RedirectToAction("Index");
                }

                return View(_pais);
            }
            catch (Exception ex)
            {
                return this.View("Error", ex);
            }
        }

        //
        // GET: /Pais/Edit/5

        public ActionResult Edit(String _CodigoAbreviacion)
        {
            if (String.IsNullOrEmpty(_CodigoAbreviacion))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pais _pais = _common.bd.Paises.Find(_CodigoAbreviacion);
            if (_pais == null)
            {
                return HttpNotFound();
            }

            return View(_pais);
        }

        //
        // POST: /Pais/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String _CodigoAbreviacion, Pais _pais)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.Entry(_pais).State = EntityState.Modified;
                    _common.bd.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(_pais);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /Pais/Delete/5

        public ActionResult Delete(String _CodigoAbreviacion)
        {
            try
            {
                var _ListCiudades = (from m in _common.bd.Paises
                                     where m.PaisAbreviacion.ToString() == _CodigoAbreviacion
                                     select m).First();

                return View(_ListCiudades);

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // POST: /Pais/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(String _CodigoAbreviacion, Pais _p)
        {
            try
            {
                Pais _pais = _common.bd.Paises.Find(_CodigoAbreviacion);
                if (_pais != null)
                {
                    _common.bd.Paises.Remove(_pais);
                    _common.bd.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(_pais);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
