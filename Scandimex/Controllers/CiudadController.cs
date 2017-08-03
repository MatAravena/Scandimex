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
    public class CiudadController : Controller
    {
        CommonClass _common = new CommonClass();

        //
        // GET: /Ciudad/

        public ActionResult Index(String _Filtro)
        {
            try
            {

                var _ListCiudades = (from m in _common.bd.Ciudades
                                     select m).ToList();

                if (!String.IsNullOrEmpty(_Filtro))
                {
                    _ListCiudades = _ListCiudades.Where(s => s.CiudadNombre.Contains(_Filtro)).ToList();
                }
                ViewBag.Paises = _common.GetPaises();

                return View(_ListCiudades);

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }


        //
        // GET: /Ciudad/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var _ListCiudades = (from m in _common.bd.Ciudades
                                        where m.CiudadCodigo == id
                                        select m).First();

                return View(_ListCiudades);

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /Ciudad/Create
        public ActionResult Create()
        {
            ViewBag.Paises = _common.GetPaises();
            return View();
        }

        //
        // POST: /Ciudad/Create
        [HttpPost]
        public ActionResult Create(Ciudad _City)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.Ciudades.Add(_City);
                    _common.bd.SaveChanges();

                    return this.RedirectToAction("Index");
                }

                return View(_City);
            }
            catch (Exception ex)
            {
                return this.View("Error", ex);
            }
        }

        //
        // GET: /Ciudad/Edit/5
        public ActionResult Edit(int id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Paises = _common.GetPaises();
            Ciudad _city = _common.bd.Ciudades.Find(id);
            if (_city == null)
            {
                return HttpNotFound();
            }

            return View(_city);
        }

        //
        // POST: /Ciudad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Ciudad _city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Ciudad _ciud = _common.bd.Ciudades.Find(id);
                    if (_ciud != null)
                    {
                        _ciud.CiudadNombre = _city.CiudadNombre;
                        _ciud.PaisAbreviacion = _city.PaisAbreviacion;

                        _common.bd.Entry(_ciud).State = EntityState.Modified;
                        _common.bd.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }

                return View(_city);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /Ciudad/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                var _ListCiudades = (from m in _common.bd.Ciudades
                                     where m.CiudadCodigo == id
                                     select m).First();

                return View(_ListCiudades);

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // POST: /Ciudad/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Ciudad _city)
        {
            try
            {
                Ciudad _ciud = _common.bd.Ciudades.Find(id);
                if (_ciud != null)
                {
                    _common.bd.Ciudades.Remove(_ciud);
                    _common.bd.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(_city);



                //Pais _pais = _common.bd.Paises.Find(_CodigoAbreviacion);
                //if (_pais != null)
                //{
                //    _common.bd.Paises.Remove(_pais);
                //    _common.bd.SaveChanges();
                //    return RedirectToAction("Index");
                //}

                //return View(_pais);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }


    }
}
