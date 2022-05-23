using Safuillin.Kursach.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Safuillin.Kursach.Models
{
    public class Connector
    {
        public static List<Connector> Connectors = new List<Connector>();
        public static List<Connector> DelConnectors = new List<Connector>();
        public Receipt receipt { get; set; }
        public Button btn { get; set; }
        public Button btn2 { get; set; }
    }
}
