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
    public class PersonaContactoController : Controller
    {
        CommonClass _common = new CommonClass();

        //
        // GET: /PersonaContacto/

        public ActionResult Index(Int32? cmbClientes)
        {
            try
            {
                var _ListPerContactos = (from m in _common.bd.PersonasContactos
                                         select m).ToList();

                if (cmbClientes != 0 && cmbClientes != null)
                {
                    _ListPerContactos = (from per in _common.bd.PersonasContactos
                                         where per.Cliente.IdCliente == cmbClientes
                                         select per).ToList();
                }

                ViewBag.Clientes = (from cli in _common.bd.Clientes
                                    orderby cli.NombreCompañia
                                    select cli).ToList();

                return View(_ListPerContactos);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /PersonaContacto/Details/5

        public ActionResult Details(String Clientes, int _Id)
        {
            try
            {
                if (String.IsNullOrEmpty(_Id.ToString()))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                PersonaContacto _ListPerContact = (from m in _common.bd.PersonasContactos
                                                   where m.PersonaContactoId == _Id
                                                   select m).First();

                return View(_ListPerContact);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /PersonaContacto/Create

        public ActionResult Create(int _id)
        {
            //if (_id != 0)
            //{
            //    ViewBag.Clientes = (from cli in _common.bd.Clientes
            //                        where cli.IdCliente == _id
            //                        orderby cli.NombreCompañia
            //                        select cli).ToList();
            //}
            //else
            //{
            //}
            ViewBag.Clientes = (from cli in _common.bd.Clientes
                                orderby cli.NombreCompañia
                                select cli).ToList();
            return View();
        }

        //
        // POST: /PersonaContacto/Create

        [HttpPost]
        public ActionResult Create(PersonaContacto _per)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.PersonasContactos.Add(_per);
                    _common.bd.SaveChanges();

                    return this.RedirectToAction("Index");
                }

                return View(_per);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PersonaContacto/Edit/5

        public ActionResult Edit(int _id)
        {
            try
            {
                if (String.IsNullOrEmpty(_id.ToString()))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                PersonaContacto _per = _common.bd.PersonasContactos.Find(_id);
                if (_per == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Clientes = _common.GetClientes();

                return View(_per);

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // POST: /PersonaContacto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int _id, PersonaContacto _per)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _common.bd.Entry(_per).State = EntityState.Modified;
                    _common.bd.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(_per);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // GET: /PersonaContacto/Delete/5
        public ActionResult Delete(int _id)
        {
            try
            {
                if (String.IsNullOrEmpty(_id.ToString()))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                PersonaContacto _per = _common.bd.PersonasContactos.Find(_id);
                if (_per == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Clientes = _common.GetClientes();

                return View(_per);

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //
        // POST: /PersonaContacto/Delete/5

        [HttpPost]
        public ActionResult Delete(int _id, PersonaContacto _PerView)
        {
            try
            {

                PersonaContacto _per = _common.bd.PersonasContactos.Find(_id);
                if (_per != null)
                {
                    _common.bd.PersonasContactos.Remove(_per);
                    _common.bd.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(_PerView);
            }
            catch
            {
                return View();
            }
        }

    }
}
