using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TecnoBlog.Services.Converters;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Tests.Converters.CommentConverter_Tests
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
            // TODO: Agregar aquí la lógica del constructor
            //
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private TecnoBlog.Business.Models.Comment GenerateCommentModel()
        {
            var model = new Business.Models.Comment
            {
                UserName = "Test UserName",
                Content = "Test Content",
                Created = new DateTime(2018, 1, 1),
                Id = Guid.Parse("c23f5a47-5256-4a2d-9748-3b50eeb1a5d8"),
                ArticleId = Guid.Parse("e605822e-d4c0-4b4c-929e-09628573485f")
            };
            return model;
        }

        private TecnoBlog.Services.Comment GenerateCommentEntity()
        {
            var model = new TecnoBlog.Services.Comment
            {
                UserName = "Test UserName",
                Content = "Test Content",
                Created = new DateTime(2018, 1, 1),
                Id = Guid.Parse("c23f5a47-5256-4a2d-9748-3b50eeb1a5d8"),
                ArticleId = Guid.Parse("e605822e-d4c0-4b4c-929e-09628573485f")
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
        public void TestConvert_FromEntityToModel_UserNameIsCorrect()
        {
            // Prepare
            var entity = GenerateCommentEntity();
            var expected = "Test UserName";

            // Act
            var actual = CommentConverter.Convert(entity).UserName;

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
        public void TestConvert_FromModelToEntity_UserNameIsCorrect()
        {
            // Prepare
            var model = GenerateCommentModel();
            var expected = "Test UserName";

            // Act
            var actual = CommentConverter.Convert(model).UserName;

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
            var entity = GenerateCommentEntity();
            var expected = Guid.Parse("e605822e-d4c0-4b4c-929e-09628573485f");

            // Act
            var actual = CommentConverter.Convert(entity).ArticleId;

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
            var model = GenerateCommentModel();
            var expected = Guid.Parse("e605822e-d4c0-4b4c-929e-09628573485f");

            // Act
            var actual = CommentConverter.Convert(model).ArticleId;

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
        public void TestConvert_FromEntityToModel_IdIsCorrect()
        {
            // Prepare
            var entity = GenerateCommentEntity();
            var expected = Guid.Parse("c23f5a47-5256-4a2d-9748-3b50eeb1a5d8");

            // Act
            var actual = CommentConverter.Convert(entity).Id;

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
            var model = GenerateCommentModel();
            var expected = Guid.Parse("c23f5a47-5256-4a2d-9748-3b50eeb1a5d8");

            // Act
            var actual = CommentConverter.Convert(model).Id;

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
            var entity = GenerateCommentEntity();
            var expected = new DateTime(2018, 1, 1);

            // Act
            var actual = CommentConverter.Convert(entity).Created;

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
            var model = GenerateCommentModel();
            var expected = new DateTime(2018, 1, 1);

            // Act
            var actual = CommentConverter.Convert(model).Created;

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
            var entity = GenerateCommentEntity();
            var expected = "Test Content";

            // Act
            var actual = CommentConverter.Convert(entity).Content;

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
            var model = GenerateCommentModel();
            var expected = "Test Content";

            // Act
            var actual = CommentConverter.Convert(model).Content;

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
