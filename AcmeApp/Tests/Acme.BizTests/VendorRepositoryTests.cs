using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetreiveValueTest()
        {

            //Arrange
            var repository = new VendorRepository();
            var expected = 42;

            //Act
            var actual = repository.RetreiveValue<int>("Select..", 42);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetreiveValueStringTest()
        {

            //Arrange
            var repository = new VendorRepository();
            var expected = "test";

            //Act
            var actual = repository.RetreiveValue<string>("Select..", "test");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetreiveValueObjectTest()
        {

            //Arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            //Act
            var actual = repository.RetreiveValue<Vendor>("Select..", vendor);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();
            expected.Add(new Vendor() { VendorId = 1, CompanyName = "Luxoft", Email = "sasa@.sada.com" });
            expected.Add(new Vendor() { VendorId = 2, CompanyName = "opel", Email = "sa@da.com" });

            //Act
            var actual = repository.Retrieve();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveWithKeysTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new Dictionary<string, Vendor>(){
                {"ABC Corp", new Vendor()
                {VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com" }},
                {"XYZ Inc", new Vendor()
                {VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" }}
            };

            //Act
            var actual = repository.RetrieveWithKeys();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
            
        }
    }
}