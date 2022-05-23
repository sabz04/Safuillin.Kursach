using Microsoft.VisualStudio.TestTools.UnitTesting;
using Safuillin.Kursach.DBModel;
using Safuillin.Kursach.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safuillin.Kursach.Pages.Tests
{
    [TestClass()]
    public class LogPageTests
    {
        [TestMethod()]
        public void LoginTest1()
        {
            string login = "";
            string password = "";
            User expected = null; 
            User actual = LogPage.Login(login, password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LoginTest2()
        {
            string login = null;
            string password = null;
            User expected = null;
            User actual = LogPage.Login(login, password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LoginTest3()
        {
            string login = "admin";
            string password = "admin";
            User expected = null;
            using (DbModelContainer db = new DbModelContainer())
            {
                expected = db.Users.FirstOrDefault(x => x.Login == login &&
                                                          x.Password == password);
            }
            User actual = LogPage.Login(login, password);
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [TestMethod()]
        public void LoginTest4()
        {
            string login = "saf";
            string password = "saf";
            User expected = null;
            using (DbModelContainer db = new DbModelContainer())
            {
                expected = db.Users.FirstOrDefault(x => x.Login == login &&
                                                          x.Password == password);
            }
            User actual = LogPage.Login(login, password);
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [TestMethod()]
        public void LoginTest5()
        {
            string login = "saf    ";
            string password = "saf    ";
            User expected = null;
            using (DbModelContainer db = new DbModelContainer())
            {
                expected = db.Users.FirstOrDefault(x => x.Login == login &&
                                                          x.Password == password);
            }
            User actual = LogPage.Login(login, password);
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [TestMethod()]
        public void LoginTest6()
        {
            string login = "password0";
            string password = "user1";
            User expected = null;
            User actual = LogPage.Login(login, password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LoginTest7()
        {
            string login = "34534534tdfvvbdfvvf";
            string password = "sa   4tdvvdsvsvsdvf";
            User expected = null;
            User actual = LogPage.Login(login, password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LoginTest8()
        {
            string login = "       ";
            string password = "       ";
            User expected = null;
            User actual = LogPage.Login(login, password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LoginTest9()
        {
            string login = "user";
            string password = "user";
            User expected = null;
            User actual = LogPage.Login(login, password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LoginTest10()
        {
            string login = "user1";
            string password = "password0";
            User expected = null;
            using (DbModelContainer db = new DbModelContainer())
            {
                expected = db.Users.FirstOrDefault(x => x.Login == login &&
                                                          x.Password == password);
            }
            User actual = LogPage.Login(login, password);
            Assert.AreEqual(expected.Id, actual.Id);
        }
    }
}