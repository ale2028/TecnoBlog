using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TecnoBlog.Services.Converters;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Tests.Converters.ImageConverter_Test
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

        private TecnoBlog.Business.Models.Image GenerateImageModel()
        {
            var model = new Business.Models.Image
            {
                Path = "Test Path",
                Format = "Test Format",
                Id = Guid.Parse("d0257b18-cb43-4065-92d2-42539c12bd84"),
                ArticleId = Guid.Parse("e21b164a-c705-4a80-9fce-f878be267c54"),
            };
            return model;
        }

        private TecnoBlog.Services.Image GenerateImageEntity()
        {
            var model = new TecnoBlog.Services.Image
            {
                Path = "Test Path",
                Format = "Test Format",
                Id = Guid.Parse("d0257b18-cb43-4065-92d2-42539c12bd84"),
                ArticleId = Guid.Parse("e21b164a-c705-4a80-9fce-f878be267c54"),
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
            var entity = GenerateImageEntity();
            var expected = Guid.Parse("d0257b18-cb43-4065-92d2-42539c12bd84");

            // Act
            var actual = ImageConverter.Convert(entity).Id;

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
            var model = GenerateImageModel();
            var expected = Guid.Parse("d0257b18-cb43-4065-92d2-42539c12bd84");

            // Act
            var actual = ImageConverter.Convert(model).Id;

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
            var entity = GenerateImageEntity();
            var expected = Guid.Parse("e21b164a-c705-4a80-9fce-f878be267c54");

            // Act
            var actual = ImageConverter.Convert(entity).ArticleId;

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
            var model = GenerateImageModel();
            var expected = Guid.Parse("e21b164a-c705-4a80-9fce-f878be267c54");

            // Act
            var actual = ImageConverter.Convert(model).ArticleId;

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
        public void TestConvert_FromEntityToModel_PathIsCorrect()
        {
            // Prepare
            var entity = GenerateImageEntity();
            var expected = "Test Path";

            // Act
            var actual = ImageConverter.Convert(entity).Path;

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
        public void TestConvert_FromModelToEntity_PathIsCorrect()
        {
            // Prepare
            var model = GenerateImageModel();
            var expected = "Test Path";

            // Act
            var actual = ImageConverter.Convert(model).Path;

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
        public void TestConvert_FromEntityToModel_FormatIsCorrect()
        {
            // Prepare
            var entity = GenerateImageEntity();
            var expected = "Test Format";

            // Act
            var actual = ImageConverter.Convert(entity).Format;

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
        public void TestConvert_FromModelToEntity_FormatIsCorrect()
        {
            // Prepare
            var model = GenerateImageModel();
            var expected = "Test Format";

            // Act
            var actual = ImageConverter.Convert(model).Format;

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
