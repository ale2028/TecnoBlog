using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecnoBlog.Business.Abstractions;
using TecnoBlog.Business.Models;
using TecnoBlog.Services;
using TecnoBlog.Services.Impl;
using TecnoBlog.Services.Converters;

namespace TecnoBlog.Controllers
{
    public class CommentController : Controller
    {

        // La variable es del tipo de la interfaz y usa como parámetro de tipo
        // el tipo de modelo que va a manejar este controlador. Y lo inicializamos
        // con una instancia del servicio que implementa esta interfaz con este model
        // en específico. 
        private IModelService<Business.Models.Comment, Guid> commentService = new CommentService();
        private ArticleCommentService articleCommentService = new ArticleCommentService();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public ActionResult Index(Guid articleId)
        {
            List<Business.Models.Comment> model = this.articleCommentService.GetCommentsForArticle(articleId);
            return View(model);
        }

        // GET: Comment/Details/5
        public ActionResult Details(Guid id)
        {
            var model = this.commentService.Get(id);
            return View(model);
        }

        // GET: Comment/Create
        [Authorize]
        public ActionResult Create(Guid articleId)
        {
            Business.Models.Comment model = new Business.Models.Comment();
            model.ArticleId = articleId;
            return View(model);
        }

        // POST: Comment/Create
        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult PostComment(Business.Models.Comment model)
        {
            ViewBag.ArticleId = model.ArticleId;
            try
            {
                if (ModelState.IsValid)
                {
                    model.Created = DateTime.Now;
                    model.UserName = User.Identity.Name;
                    var newComment = this.commentService.Create(model);
                    if (newComment != null && newComment.Id != Guid.Empty)
                    {
                        return RedirectToAction("Details", "Article", new { id = model.ArticleId });
                    }
                    ModelState.AddModelError(null, "Unable to create a new comment. Please try again.");
                    return RedirectToAction("Details", "Article",  new { id = model.ArticleId});
                }
                else
                {
                    // Si entra acá es porque alguno de los campos requeridos no está presente
                    // entonces volvemos a mostrar la vista y pasamos el modelo.
                    return RedirectToAction("Details", "Article", new { id = model.ArticleId });
                }

            }
            catch (Exception e)
            {
                return RedirectToAction("Details", "Article", new { id = model.ArticleId });
            }

        }

        // GET: Comment/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = this.commentService.Get(id);
            return View(model);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Business.Models.Comment model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.commentService.Update(id, model);
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = this.commentService.Get(id);
            return View(model);
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {

                this.commentService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}