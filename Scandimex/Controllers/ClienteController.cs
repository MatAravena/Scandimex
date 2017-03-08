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
    public class ClienteController : Controller
    {
        CommonClass _common = new CommonClass();

        //
        // GET: /Cliente/

        public ActionResult Index(string _Filtro)
        {
            try
            {
                var _ListClientes = (from m in _common.bd.Clientes
                                     select m).ToList(); ;

                if (!String.IsNullOrEmpty(_Filtro))
                {
                    _ListClientes = _ListClientes.Where(s => s.NombreCompañia.Contains(_Filtro)).ToList();
                }

                return View(_ListClientes);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int? _Filtro)
        {
            try
            {
                var _ListContactPerson = _common.bd.Clientes.Find(_Filtro);

                if (_ListContactPerson != null)
                {
                    List<PersonaContacto> _PersCont = (from per in _common.bd.PersonasContactos
                                                       join cli in _common.bd.Clientes on per.IdCliente equals cli.IdCliente
                                                       where cli.IdCliente == _Filtro
                                                       orderby per.Name ascending
                                                       select per).ToList();

                    ViewBag.Contactos = _PersCont;
                }

                return View(_ListContactPerson);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            ViewBag.Paises = _common.GetPaises();
            ViewBag.Ciudades = _common.GetCiudades();

            return View();
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
        // POST: /Cliente/Create

        [HttpPost]
        public ActionResult Create(Clientes _cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.Clientes.Add(_cliente);
                    _common.bd.SaveChanges();

                    return this.RedirectToAction("Index");
                }

                return View(_cliente);
            }
            catch (Exception ex)
            {
                return this.View("Error", ex);
            }
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(Int32 _Filtro)
        {
            if (_Filtro == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Paises = _common.GetPaises();
            ViewBag.Ciudades = _common.GetCiudades();

            Clientes _cli = _common.bd.Clientes.Find(_Filtro);

            if (_cli == null)
            {
                return HttpNotFound();
            }

            return View(_cli);
        }

        //
        // POST: /Cliente/Edit/539

        [HttpPost]
        public ActionResult Edit(int _Filtro, Clientes _cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.Entry(_cliente).State = EntityState.Modified;
                    _common.bd.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(_cliente);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int _Filtro)
        {
            try
            {
                var _ListClientes = (from m in _common.bd.Clientes
                                     where m.IdCliente == _Filtro
                                     select m).First();

                return View(_ListClientes);

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int _Filtro)
        {
            try
            {
                Clientes _cli = _common.bd.Clientes.Find(_Filtro);
                if (ModelState.IsValid)
                {
                    _common.bd.Clientes.Remove(_cli);
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

    }
}
