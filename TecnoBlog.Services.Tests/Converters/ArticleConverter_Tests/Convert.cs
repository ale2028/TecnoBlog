using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TecnoBlog.Services.Converters;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Tests.Converters.ArticleConverter_Tests
{
    /// <summary>
    /// Descripción resumida de Convert
    /// </summary>
    [TestClass]
    public class Convert
    {
        public Convert()
        {
            //
            //
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private TecnoBlog.Business.Models.Article GenerateArticleModel()
        {
            var model = new Business.Models.Article
            {
                Author = "Test Author",
                Content = "Test Content",
                Created = new DateTime(2018, 1, 1),
                Description = "Test Description",
                Id = Guid.Parse("b4a87b22-097a-46fa-845f-e88a250b834e"),
                Title = "Test Title"
            };
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private TecnoBlog.Services.Article GenerateArticleEntity()
        {
            var model = new TecnoBlog.Services.Article
            {
                Author = "Test Author",
                Content = "Test Content",
                Created = new DateTime(2018, 1, 1),
                Description = "Test Description",
                Id = Guid.Parse("b4a87b22-097a-46fa-845f-e88a250b834e"),
                Title = "Test Title"
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
        public void TestConvert_FromEntityToModel_IdIsCorrect()
        {
            // Prepare
            var entity = GenerateArticleEntity();
            var expected = Guid.Parse("b4a87b22-097a-46fa-845f-e88a250b834e");

            // Act
            var actual = ArticleConverter.Convert(entity).Id;

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
        public void TestConvert_FromModelToEntity_IdIsCorrect()
        {
            // Prepare
            var model = GenerateArticleModel();
            var expected = Guid.Parse("b4a87b22-097a-46fa-845f-e88a250b834e");

            // Act
            var actual = ArticleConverter.Convert(model).Id;

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
        public void TestConvert_FromEntityToModel_TitleIsCorrect()
        {
            // Prepare
            var entity = GenerateArticleEntity();
            var expected = "Test Title";

            // Act
            var actual = ArticleConverter.Convert(entity).Title;

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
        public void TestConvert_FromModelToEntity_TitleIsCorrect()
        {
            // Prepare
            var model = GenerateArticleModel();
            var expected = "Test Title";

            // Act
            var actual = ArticleConverter.Convert(model).Title;

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
        public void TestConvert_FromEntityToModel_DescriptionIsCorrect()
        {
            // Prepare
            var entity = GenerateArticleEntity();
            var expected = "Test Description";

            // Act
            var actual = ArticleConverter.Convert(entity).Description;

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
        public void TestConvert_FromModelToEntity_DescriptionIsCorrect()
        {
            // Prepare
            var model = GenerateArticleModel();
            var expected = "Test Description";

            // Act
            var actual = ArticleConverter.Convert(model).Description;

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
        public void TestConvert_FromEntityToModel_CreatedIsCorrect()
        {
            // Prepare
            var entity = GenerateArticleEntity();
            var expected = new DateTime (2018, 1, 1);

            // Act
            var actual = ArticleConverter.Convert(entity).Created;

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
        public void TestConvert_FromModelToEntity_CreatedIsCorrect()
        {
            // Prepare
            var model = GenerateArticleModel();
            var expected = new DateTime (2018, 1, 1);

            // Act
            var actual = ArticleConverter.Convert(model).Created;

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
        public void TestConvert_FromEntityToModel_ContentIsCorrect()
        {
            // Prepare
            var entity = GenerateArticleEntity();
            var expected = "Test Content";

            // Act
            var actual = ArticleConverter.Convert(entity).Content;

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
        public void TestConvert_FromModelToEntity_ContentIsCorrect()
        {
            // Prepare
            var model = GenerateArticleModel();
            var expected = "Test Content";
            
            // Act
            var actual = ArticleConverter.Convert(model).Content;

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
        public void TestConvert_FromEntityToModel_AuthorIsCorrect()
        {
            // Prepare
            var entity = GenerateArticleEntity();
            var expected = "Test Author";

            // Act
            var actual = ArticleConverter.Convert(entity).Author;

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
        public void TestConvert_FromModelToEntity_AuthorIsCorrect()
        {
            // Prepare
            var model = GenerateArticleModel();
            var expected = "Test Author";

            // Act
            var actual = ArticleConverter.Convert(model).Author;

            // Assert
            Assert.AreEqual(expected, actual);
        } // TEST METHOD ENDS

    }   // -------------------------------------------------------------------- //
} //-------------------------------------------------------------------------------------//

