using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TecnoBlog.Services.Converters;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Tests.Converters.ArticleTagConverter_Tests
{
    /// <summary>
    /// Descripción resumida de ArticleTagConvert
    /// </summary>
    [TestClass]
    public class Convert
    {
        public Convert()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TecnoBlog.Business.Models.ArticleTag GenerateArticleTagModel()
        {
            var model = new Business.Models.ArticleTag
            {
                Tag = "Test Name",
                ArticleId = Guid.Parse("cdfec528-a2a2-43b4-a310-5b1aab61e8da")
            };
            return model;
        }

        private TecnoBlog.Services.Article_Tag GenerateArticleTagEntity()
        {
            var model = new TecnoBlog.Services.Article_Tag
            {
                Tag = "Test Name",
                ArticleId = Guid.Parse("cdfec528-a2a2-43b4-a310-5b1aab61e8da")
            };
            return model;
        }

        // ============================================================================== //
        // TEST METHOD                                                                    //
        // ============================================================================== //
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestConvert_FromEntityToModel_TagIsCorrect()
        {
            // Prepare
            var entity = GenerateArticleTagEntity();
            var expected = "Test Tag";

            // Act
            var actual = ArticleTagConverter.Convert(entity).Tag;

            // Assert
            Assert.AreEqual(expected, actual);
        } // TEST METHOD ENDS 

        // ============================================================================== //
        // TEST METHOD                                                                    //
        // ============================================================================== //
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestConvert_FromModelToEntity_TagIsCorrect()
        {
            // Prepare
            var model = GenerateArticleTagModel();
            var expected = "Test Tag";

            // Act
            var actual = ArticleTagConverter.Convert(model).Tag;

            // Assert
            Assert.AreEqual(expected, actual);
        } // TEST METHOD ENDS

        // ============================================================================== //
        // TEST METHOD                                                                    //
        // ============================================================================== //
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestConvert_FromEntityToModel_ArticleIdIsCorrect()
        {
            // Prepare
            var entity = GenerateArticleTagEntity();
            var expected = Guid.Parse("cdfec528-a2a2-43b4-a310-5b1aab61e8da");

            // Act
            var actual = ArticleTagConverter.Convert(entity).ArticleId;

            // Assert
            Assert.AreEqual(expected, actual);
        } // TEST METHOD ENDS 

        // ============================================================================== //
        // TEST METHOD                                                                    //
        // ============================================================================== //
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestConvert_FromModelToEntity_ArticleIdIsCorrect()
        {
            // Prepare
            var model = GenerateArticleTagModel();
            var expected = Guid.Parse("cdfec528-a2a2-43b4-a310-5b1aab61e8da");

            // Act
            var actual = ArticleTagConverter.Convert(model).ArticleId;

            // Assert
            Assert.AreEqual(expected, actual);
        } // TEST METHOD ENDS

       
        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Agregar aquí la lógica de las pruebas
            //
        }
    }
}
