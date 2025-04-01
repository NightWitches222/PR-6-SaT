using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_2.Pages;

namespace UnitTest
{
	[TestClass]
	public class RegistrationTest
	{
		[TestMethod]
		public void RegisrtationTestSoccess()
		{
			var page = new RegistrationsPage();
			Assert.IsTrue(page.Registration("Ivan Ivanov Ivanovich", "test1@example.com", "12345678", "12345678", "user"));
            Assert.IsTrue(page.Registration("Ivan Ivanov Ivanovich", "test1@example.com", "12345678", "12345678", "admin"));
            Assert.IsTrue(page.Registration("Ivan Ivanov Ivanovich", "test1@example.com", "12345678", "12345678", "manager"));
        }

		[TestMethod]
		public void RegisrtationTestFailed()
		{
            var page = new RegistrationsPage();
            Assert.IsFalse(page.Registration("Ivan Ivanov Ivanovich", "test1@example.com", "12345678", "0982", "user"));
            Assert.IsFalse(page.Registration("Ivan Ivanov Ivanovich", "test1@example.com", "1234", "1234", "user"));
            Assert.IsFalse(page.Registration("Ivan Ivanov Ivanovich", "abc", "12345678", "12345678", "user"));
            Assert.IsFalse(page.Registration("", "test1@example.com", "12345678", "12345678", "user"));
            Assert.IsFalse(page.Registration("Ivan Ivanov Ivanovich", "", "12345678", "12345678", "user"));
            Assert.IsFalse(page.Registration("Ivan Ivanov Ivanovich", "test1@example.com", "", "", "user"));
            Assert.IsFalse(page.Registration("Ivan Ivanov Ivanovich", "test1@example.com", "12345678", "12345678", ""));
        }
    }
}
