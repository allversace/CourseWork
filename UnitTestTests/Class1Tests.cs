using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void vslidatePasswordTest()
        {
            string password = "Leaael07@12";
            bool expected = true;

            bool actual = Class1.vslidatePassword(password);
            Assert.AreEqual(expected, actual);
        }
    }
}