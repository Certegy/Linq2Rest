using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linq2Rest.Tests {
    [TestClass]
    public class ExpressionConverterTests {
        [TestMethod]
        public void TestMethod1() {
            var service = new ExpressionConverter();
            var dump = service.ConvertFilter<SimpleClass>(v => v.Date > DateTime.Now);
            //Assert.AreEqual("", dump);
        }

        [TestMethod]
        public void TestMethod2() {
            var service = new ExpressionConverter();
            var dump = service.ConvertOrder<SimpleClass>(v => v.Date);
            

            Assert.AreEqual("Date", dump);
        }

        [TestMethod]
        public void Test_EnumTypes()
        {
            var service = new ExpressionConverter();
            var dump = service.ConvertOrder<SimpleClass>(v => v.Status == TestStatus.Initial);
            Assert.AreEqual("Status eq Linq2Rest.TestStatus'Initial'", dump);
        }
    }
}
