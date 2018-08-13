using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TecnoBlog.Services.Converters;
using TecnoBlog.Business.Models;


namespace TecnoBlog.Services.Tests.Converters.UserConverter_Tests
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

        private TecnoBlog.Business.Models.User GenerateUserModel()
        {
            var model = new Business.Models.User
            {
                Email = "Test Email",
                UserName = "Test UserName",
                Id = "Test Id"
                
            };
            return model;
        }

        private TecnoBlog.Services.AspNetUsers GenerateUserEntity()
        {
            var model = new TecnoBlog.Services.AspNetUsers
            {
                Email = "Test Email",
                UserName = "Test UserName",
                Id = "Test Id"

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
            var entity = GenerateUserEntity();
            var expected = "Test Id";

            // Act
            var actual = UserConverter.Convert(entity).Id;

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
            var model = GenerateUserModel();
            var expected = "Test Id";

            // Act
            var actual = UserConverter.Convert(model).Id;

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
        public void TestConvert_FromEntityToModel_EmailIsCorrect()
        {
            // Prepare
            var entity = GenerateUserEntity();
            var expected = "Test Email";

            // Act
            var actual = UserConverter.Convert(entity).Email;

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
        public void TestConvert_FromModelToEntity_EmailIsCorrect()
        {
            // Prepare
            var model = GenerateUserModel();
            var expected = "Test Email";

            // Act
            var actual = UserConverter.Convert(model).Email;

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
        public void TestConvert_FromEntityToModel_UserNameIsCorrect()
        {
            // Prepare
            var entity = GenerateUserEntity();
            var expected = "Test UserName";

            // Act
            var actual = UserConverter.Convert(entity).UserName;

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
            var model = GenerateUserModel();
            var expected = "Test UserName";

            // Act
            var actual = UserConverter.Convert(model).UserName;

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
