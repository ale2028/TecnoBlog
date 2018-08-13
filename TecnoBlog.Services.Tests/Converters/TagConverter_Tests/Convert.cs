using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TecnoBlog.Services.Converters;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Tests.Converters.TagConverter_Tests
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

        private TecnoBlog.Business.Models.Tag GenerateTagModel()
        {
            var model = new Business.Models.Tag
            {
                Name = "Test Name",
            };
            return model;
        }

        private TecnoBlog.Services.Tag GenerateTagEntity()
        {
            var model = new TecnoBlog.Services.Tag
            {
                Name = "Test Name",
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
        public void TestConvert_FromEntityToModel_NameIsCorrect()
        {
            // Prepare
            var entity = GenerateTagEntity();
            var expected = "Test Name";

            // Act
            var actual = TagConverter.Convert(entity).Name;

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
        public void TestConvert_FromModelToEntity_NameIsCorrect()
        {
            // Prepare
            var model = GenerateTagModel();
            var expected = "Test Name";

            // Act
            var actual = TagConverter.Convert(model).Name;

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
