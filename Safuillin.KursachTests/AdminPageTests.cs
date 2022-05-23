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
    public class AdminPageTests
    {
        [TestMethod()]
        public void ValidateRecTest1()
        {
            string naim = "";
            string time = "";
            string type = "";
            string desc = "";

            Receipt expected = null;
            Receipt actual = AdminPage.ValidateRec(naim, time, desc, type, null);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ValidateRecTest2()
        {
            string naim = null;
            string time = null;
            string type = null;
            string desc = null;

            Receipt expected = null;
            Receipt actual = AdminPage.ValidateRec(naim, time, desc, type, null);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ValidateRecTest3()
        {
            string naim = "Мраморная говядина";
            string time = "30 мин";
            string type = "Мясо";
            string desc = "Мраморная говядина медиум прожарки";

            Receipt expected = new Receipt()
            {
                Name = naim,
                Time = time,
                Desc = desc,
                Type = type,
                Photo = null
            };
            Receipt actual = AdminPage.ValidateRec(naim, time, desc, type, null);

            Assert.AreEqual(expected.Name, actual.Name);
        }

        [TestMethod()]
        public void ValidateRecTest4()
        {
            string naim = "Мраморная говядина";
            string time = "";
            string type = "Мясо";
            string desc = "Мраморная говядина медиум прожарки";

            Receipt expected = null;
            Receipt actual = AdminPage.ValidateRec(naim, time, desc, type, null);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ValidateRecTest5()
        {
            string naim = "Мраморная говядина";
            string time = "30 мин";
            string type = "Мясо";
            string desc = "";

            Receipt expected = null;
            Receipt actual = AdminPage.ValidateRec(naim, time, desc, type, null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ValidateRecTest6()
        {
            string naim = "Мраморная говядина";
            string time = "30 мин";
            string type = "";
            string desc = "Мраморная говядина медиум прожарки";

            Receipt expected = null;
            Receipt actual = AdminPage.ValidateRec(naim, time, desc, type, null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ValidateRecTest7()
        {
            string naim = "";
            string time = "30 мин";
            string type = "Мясо";
            string desc = "Мраморная говядина медиум прожарки";

            Receipt expected = null;
            Receipt actual = AdminPage.ValidateRec(naim, time, desc, type, null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ValidateRecTest8()
        {
            string naim = null;
            string time = "30 мин";
            string type = "Мясо";
            string desc = "Мраморная говядина медиум прожарки";

            Receipt expected = null;
            Receipt actual = AdminPage.ValidateRec(naim, time, desc, type, null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ValidateRecTest9()
        {
            string naim = "Мясо по французски";
            string time = "         ";
            string type = "Мясо";
            string desc = "Вкуснота!";

            Receipt expected = new Receipt()
            {
                Name = naim,
                Time = time,
                Desc = desc,
                Type = type,
                Photo = null
            };
            Receipt actual = AdminPage.ValidateRec(naim, time, desc, type, null);

            Assert.AreEqual(expected.Name, actual.Name);
        }

        [TestMethod()]
        public void ValidateRecTest10()
        {
            string naim = "Паста карбонара";
            string time = "30 мин";
            string type = "Мясо";
            string desc = "Пальчики сьешь!";

            Receipt expected = new Receipt()
            {
                Name = naim,
                Time = time,
                Desc = desc,
                Type = type,
                Photo = null
            };
            Receipt actual = AdminPage.ValidateRec(naim, time, desc, type, null);

            Assert.AreEqual(expected.Name, actual.Name);
        }
    }
}