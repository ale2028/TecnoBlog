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
    public class ArticleController : Controller
    {

        // La variable es del tipo de la interfaz y usa como parámetro de tipo
        // el tipo de modelo que va a manejar este controlador. Y lo inicializamos
        // con una instancia del servicio que implementa esta interfaz con este model
        // en específico. 
        private IModelService<Business.Models.Article, Guid> articleService = new ArticleService();
        private IModelService<Business.Models.Tag, string> tagService = new TagService();
        private IModelService<Business.Models.ArticleTag, Guid> articleTagService = new ArticleTagService();

        // GET: Article
        public ActionResult Index()
        {
            List<Business.Models.Article> model = new List<Business.Models.Article>();
            var results = this.articleService.Get();
            foreach (var article in results)
            {
                model.Add(article);
            }
            return View(model);
        }

        // GET: Article/Details/5
        public ActionResult Details(Guid id)
        {
            var model = this.articleService.Get(id);
            return View(model);
        }

        // GET: Article/Create
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Create(Business.Models.Article model, string tags)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tagList = tags.Split(',');
                    foreach (var tag in tagList) {
                        this.tagService.Create(new Business.Models.Tag { Name = tag.ToUpper() });
                    }
                    model.Created = DateTime.Now;
                    model.Author = User.Identity.Name;
                    var newArticle = this.articleService.Create(model);
                    if (newArticle != null && newArticle.Id != Guid.Empty) {
                        foreach (var tag in tagList)
                        {
                            this.articleTagService.Create(new ArticleTag { Tag = tag.ToUpper(), ArticleId = newArticle.Id });
                        }
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError(null, "Unable to create a new article. Please try again.");
                    return View(model);
                }
                else
                {
                    // Si entra acá es porque alguno de los campos requeridos no está presente
                    // entonces volvemos a mostrar la vista y pasamos el modelo.
                    return View(model);
                }
                
            }
            catch(Exception e)
            {
                return View(model);
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = this.articleService.Get(id);
            return View(model);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Business.Models.Article model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.articleService.Update(id, model);
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
        public ActionResult Delete(Guid id)
        {
            var model = this.articleService.Get(id);
            return View(model);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {

                this.articleService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
