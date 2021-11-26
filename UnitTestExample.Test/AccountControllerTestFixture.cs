using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]

        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();
            var result = accountController.ValidateEmail(email);
            Assert.AreEqual(result, expectedResult);
        }

        [
            Test,
            TestCase("abcd1234", false),
            TestCase("ABCD1234", false),
            TestCase("abcdABCD", false),
            TestCase("abCD12", false),
            TestCase("abCD1234", true),
            TestCase("abCDEF1234", true)
        ]

        public void TestValidatePassword(string password, bool expectedResult)
        {
            var accountController = new AccountController();
            var result = accountController.ValidatePassword(password);
            Assert.AreEqual(result, expectedResult);
        }
    }
}
