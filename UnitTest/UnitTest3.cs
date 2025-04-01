using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_2.Pages;

namespace UnitTest
{
	[TestClass]
	public class UnitTest3
	{
		[TestMethod]
		public void AuthTestSoccess()
		{
            var page = new AuthPage();
            Assert.IsTrue(page.Auth("user@example.com", "12345678"));
            Assert.IsTrue(page.Auth("user2@example.com", "12345678"));
            Assert.IsTrue(page.Auth("admin@example.com", "admin123"));
            Assert.IsTrue(page.Auth("user3@example.com", "qwerty123"));
            Assert.IsTrue(page.Auth("manager@example.com", "manager2024"));
            Assert.IsTrue(page.Auth("user4@example.com", "password1"));
            Assert.IsTrue(page.Auth("user5@example.com", "hello123"));
            Assert.IsTrue(page.Auth("support@example.com", "support!"));
            Assert.IsTrue(page.Auth("user6@example.com", "1234abcd"));
            Assert.IsTrue(page.Auth("superadmin@example.com", "root#5678"));
        }

        [TestMethod]
        public void AuthTestFailed()
        {
            var page = new AuthPage();
            Assert.IsFalse(page.Auth("user10@example.com", "1234567812"));
            Assert.IsFalse(page.Auth("", ""));
            Assert.IsFalse(page.Auth(" ", " "));
            Assert.IsFalse(page.Auth("user@example.com", " "));
            Assert.IsFalse(page.Auth(" ", "12345678"));
        }
	}
}
