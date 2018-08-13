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
    public class TagController : Controller
    {
        // La variable es del tipo de la interfaz y usa como parámetro de tipo
        // el tipo de modelo que va a manejar este controlador. Y lo inicializamos
        // con una instancia del servicio que implementa esta interfaz con este model
        // en específico. 
        private IModelService<Business.Models.Tag , string> tagService = new TagService();

        // GET: Tag
        public ActionResult Index()
        {
            List<Business.Models.Tag> model = new List<Business.Models.Tag>();
            var results = this.tagService.Get();
            foreach (var tag in results)
            {
                model.Add(tag);
            }
            return View(model);
        }

        // GET: Tag/Details/5
        public ActionResult Details(string name)
        {
            var model = this.tagService.Get(name);
            return View(model);
        }

        // GET: Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tag/Create
        [HttpPost]
        public ActionResult Create(Business.Models.Tag model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTag = this.tagService.Create(model);
                    if (newTag != null && newTag.Name != string.Empty)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError(null, "Unable to create a new tag. Please try again.");
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

        // GET: Tag/Edit/5
        public ActionResult Edit(string id)
        {
            var model = this.tagService.Get(id);
            ViewBag.tag = model.Name;
            return View(model);
        }

        // POST: Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Business.Models.Tag model)
        {
            ViewBag.tag = id;
            try
            {
                if (ModelState.IsValid)
                {
                    this.tagService.Update(id, model);
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
        public ActionResult Delete(string name)
        {
            var model = this.tagService.Get(name);
            return View(model);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(string name, FormCollection collection)
        {
            try
            {

                this.tagService.Delete(name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
