using TecnoBlog.Reposirories;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TecnoBlogTest
{
    [TestClass]
    public class ArticleRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ArticleRepository articleRepository = new ArticleRepository();
            var result = articleRepository.GetArticles();
            Assert.IsNull(result); 
        }
    }
}
