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
    }
}