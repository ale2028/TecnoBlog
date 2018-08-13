using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecnoBlog.Business.Abstractions;
using TecnoBlog.Services.Impl;

namespace TecnoBlog.Controllers
{
    public class HomeController : Controller
    {

        // La variable es del tipo de la interfaz y usa como parámetro de tipo
        // el tipo de modelo que va a manejar este controlador. Y lo inicializamos
        // con una instancia del servicio que implementa esta interfaz con este model
        // en específico. 
        private IModelService<Business.Models.Article, Guid> articleService = new ArticleService();

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}