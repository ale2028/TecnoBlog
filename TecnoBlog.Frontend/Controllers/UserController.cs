using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecnoBlog.Business.Models;
using TecnoBlog.Business.Abstractions;
using TecnoBlog.Services;
using TecnoBlog.Services.Impl;
using TecnoBlog.Services.Converters;

namespace TecnoBlog.Controllers
{
    public class UserController : Controller
    {

        // La variable es del tipo de la interfaz y usa como parámetro de tipo
        // el tipo de modelo que va a manejar este controlador. Y lo inicializamos
        // con una instancia del servicio que implementa esta interfaz con este model
        // en específico. 
        private IModelService<Business.Models.User, string> userService = new UserService();

        // GET: Article
        public ActionResult Index()
        {
            List<Business.Models.User> model = new List<Business.Models.User>();
            var results = this.userService.Get();
            foreach (var user in results)
            {
                model.Add(user);
            }
            return View(model);
        }

        // GET: Article/Details/5
        public ActionResult Details(string id)
        {
            var model = this.userService.Get(id);
            return View(model);
        }

        // GET: Article/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }


        // POST: Article/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Business.Models.User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newUser = this.userService.Create(model);
                    if (newUser != null && newUser.Id != string.Empty)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError(null, "Unable to create a new User. Please try again.");
                    return View(model);
                }
                else
                {
                    // Si entra acá es porque alguno de los campos requeridos no está presente
                    // entonces volvemos a mostrar la vista y pasamos el modelo.
                    return View(model);
                }

            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(string id)
        {
            var model = this.userService.Get(id);
            return View(model);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Business.Models.User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.userService.Update(id, model);
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(string id)
        {
            var model = this.userService.Get(id);
            return View(model);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                this.userService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
