using Microsoft.VisualStudio.TestTools.UnitTesting;
using Safuillin.Kursach.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safuillin.Kursach.Pages.Tests
{
    [TestClass()]
    public class RegPageTests
    {
        [TestMethod()]
        public void RegistTest()
        {
            string login = "";
            string password = "";

            string expected = "Поля не должны быть пустыми.";

            string actual = RegPage.Regist(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RegistTest2()
        {
            string login = "admin";
            string password = "";

            string expected = "Поля не должны быть пустыми.";

            string actual = RegPage.Regist(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RegistTest3()
        {
            string login = "";
            string password = "admin";

            string expected = "Поля не должны быть пустыми.";

            string actual = RegPage.Regist(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RegistTest4()
        {
            string login = "admin";
            string password = "admin";

            string expected = "Вы уже есть в моей базе, пройдите авторизацию!";

            string actual = RegPage.Regist(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RegistTest5()
        {
            string login = "saf";
            string password = "saf";

            string expected = "Вы уже есть в моей базе, пройдите авторизацию!";

            string actual = RegPage.Regist(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RegistTest6()
        {
            string login = "test1";
            string password = "test1";

            string expected = "Регистрация успешна!";

            string actual = RegPage.Regist(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RegistTest7()
        {
            string login = "yetanotheruser";
            string password = "132215cvc5scdcs15cs541v5415v41v5sdv465v45d4v";

            string expected = "Регистрация успешна!";

            string actual = RegPage.Regist(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RegistTest8()
        {
            string login = " ";
            string password = " ";

            string expected = "Поля не должны быть пустыми.";

            string actual = RegPage.Regist(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RegistTest9()
        {
            string login = "    ";
            string password = "     ";

            string expected = "Поля не должны быть пустыми.";

            string actual = RegPage.Regist(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RegistTest10()
        {
            string login = "212522 2";
            string password = "123 513";

            string expected = "Регистрация успешна!";

            string actual = RegPage.Regist(login, password);

            Assert.AreEqual(expected, actual);
        }
    }
}