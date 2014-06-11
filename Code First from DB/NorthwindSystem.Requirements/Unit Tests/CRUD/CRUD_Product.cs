using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindSystem.BLL; // for access to the system
using NorthwindSystem.Entities; // for the EF entities
using Xunit; // the core for testing
using Xunit.Extensions; // for Theories, AutoRollback, etc.

namespace NorthwindSystem.Requirements.Unit_Tests.CRUD
{
    public class CRUD_Product
    {
        [Fact]
        [AutoRollback]
        public void Should_Add_Product()
        {
            // Arrange
            var sut = new NorthwindManager(); // sut is short for "Situation Under Test"
            var expected = new Product()
            {
                ProductName = "VS 2012",
            };

            // Act
            var actualId = sut.AddProduct(expected);

            // Assert
            Assert.True(actualId > 0);
            Product actual = sut.GetProduct(actualId);
            Assert.Equal(expected.ProductName, actual.ProductName);
            Assert.Equal(actualId, actual.ProductID);
        }

        #region Properties for Test Data
        // backing field
        private static IEnumerable<object[]> _CurrentProducts = null;
        public static IEnumerable<object[]> CurrentProducts
        {
            get
            {
                if (_CurrentProducts == null) // lazy-loading
                {
                    var controller = new NorthwindManager();
                    var temp = new List<object[]>(); // empty list

                    foreach (Product item in controller.ListProducts())
                    {
                        temp.Add(new object[] { item });
                    }
                    _CurrentProducts = temp;
                }
                return _CurrentProducts;
            }
        }
        #endregion

        [Theory] // indicates that this is a test with (potentially) external data
        [PropertyData("CurrentProducts")]
        [AutoRollback]
        public void Should_Update_Product(Product existing)
        {
            // Arrange
            existing.ProductName = "VS 2013"; // new name to replace existing product in DB?
            var sut = new NorthwindManager();

            // Act
            sut.UpdateProduct(existing);

            // Assert
            var actual = sut.GetProduct(existing.ProductID);
            Assert.NotNull(actual);
            Assert.Equal(existing.ProductName, actual.ProductName);
            
        }

        [Fact]
        [AutoRollback]
        public void Should_Delete_Product()
        {
            // Arrange
            var sut = new NorthwindManager(); // sut is short for "Situation Under Test"
            var expected = new Product()
            {
                ProductName = "VS 2012",
            };
            expected.ProductID = sut.AddProduct(expected);

            // Act
            sut.DeleteProduct(expected);

            // Assert
            Product actual = sut.GetProduct(expected.ProductID);
            Assert.Null(actual);
        }

    }
}
