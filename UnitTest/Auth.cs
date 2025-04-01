using System;
using System.Windows.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_2.Pages;

namespace UnitTest
{
    [TestClass]
    public class Auth
    {
        [TestMethod]
        public void AuthTest()
        {
            var page = new AuthPage();
            Assert.IsTrue(page.Auth("user@example.com", "12345678"));
            Assert.IsFalse(page.Auth("test", "test"));
            Assert.IsFalse(page.Auth("", ""));
            Assert.IsFalse(page.Auth(" ", " "));
        }
    }
}
