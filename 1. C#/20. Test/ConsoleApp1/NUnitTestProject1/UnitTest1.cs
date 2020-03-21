using NUnit.Framework;
using ConsoleApp1;
using Moq;

namespace NUnitTestProject1
{
    [TestFixture]
    public class Tests
    {
        Registration registration;
        Mock<EmailRepository> Emails;
        [SetUp]
        public void Setup()
        {
            registration = new Registration();
            Emails = new Mock<EmailRepository>();
            Emails.Setup(e => e.TryFind(It.IsAny<string>())).Returns (false);
            registration.Emails = Emails.Object;
        }
        [Test]

        public void UserNameIsGood()
        {
           var result = registration.SetUserName("wqdewas");
            Assert.AreEqual("UserName is setted", result);
        }

        [TestCase ("bndeue\'")]
        public void UserNameIsNotGood(string name)
        {
           var result = registration.SetUserName(name);
            Assert.AreEqual("UserName is not good", result);
        }

        [Test, TestCaseSource("Condition")]
        public void UserNameIsNotGoodEmptyCondition(string name)
        {
           var result = registration.SetUserName(name);
            Assert.AreEqual("UserName is empty", result);
        }

        static string[] Condition = { "", null };
        [TestCase("addafe@mail.ru")]
        
        public void EmailIsGood(string email)
        {
           var result = registration.SetEmail(email);
            Assert.AreEqual("Email is setted", result);
        }
    }
}