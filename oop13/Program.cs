using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace lab13
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Computer computer = new Computer("hp", 500, 1500);
            Workstation workstation = new Workstation("Lenovo", 0, 2500);
            BinFormat.BinSeria(computer, "comput.dat");
            BinFormat.BinDeSeria("comput.dat");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            SoapForm.SoapSeria(computer, "seccomput.soap");
            SoapForm.SoapDeSeria("seccomput.soap");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            XMLForm.XMLSeria(workstation, "xcomput.xml");
            XMLForm.XMLDeSeria( "xcomput.xml");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            JsonForm.JsonSeria(computer, "workstat.json");
            JsonForm.JsonDeSeria("workstat.json");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Computer computer1 = new Computer("Lenovo", 123, 2500);
            Computer computer2 = new Computer("hp", 200, 1570);
            Computer[] somecomputer = new Computer[] { computer, computer1, computer2 };
            JsonFormMas.JsonSeria(somecomputer, "computers.json");
            JsonFormMas.JsonDeSeria("computers.json");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("thecomput.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            // выбор узла по условию
            XmlNode childnode = xRoot.SelectSingleNode("model[name='Lenovo']");
            if (childnode != null)
                Console.WriteLine(childnode.OuterXml);
            else
                Console.WriteLine($"\nНайден узел, у которого вложенный элемент 'model' имеет значение 'Lenovo'!\n");
            AddSelectors();
            LQX1();
            LQX2();
        }
        public static void AddSelectors()
        {
            XDocument xdoc = new XDocument(new XElement("Computers",
                new XElement("model",
                new XAttribute("name", "Lenovo"),
                new XElement("cost", 600),
                new XElement("power", 1000)),

                new XElement("model",
                new XAttribute("name", "Asus"),
                new XElement("cost", 320),
                new XElement("power", 2000)))
         );
            xdoc.Save("thecomput.xml");

        }
        public static void LQX1()
        {
            XDocument xdoc1 = XDocument.Load("thecomput.xml");
        var items = from elem in xdoc1.Element("Computers").Elements("model")
                    where elem.Element("cost").Value == "600"
                    select new Computer
                    {
                        name = elem.Attribute("name").Value,
                        cost = int.Parse(elem.Element("cost").Value),
                        power = int.Parse(elem.Element("power").Value)
                    };
            foreach (var item in items)
            {
                Console.WriteLine($"Модель: {item.name}");
                Console.WriteLine($"Цена: {item.cost}");
                Console.WriteLine($"Мощность: {item.power}");
            }
            Console.WriteLine("- - - - - - - - - - - -");
        }
        public static void LQX2()
        {
            XDocument xdoc1 = XDocument.Load("thecomput.xml");
            var items = from elem in xdoc1.Element("Computers").Elements("model")
                        where int.Parse(elem.Element("power").Value) > 1000
                        select new Computer
                        {
                            name = elem.Attribute("name").Value,
                            cost = int.Parse(elem.Element("cost").Value),
                            power = int.Parse(elem.Element("power").Value)
                        };
            foreach (var item in items)
            {
                Console.WriteLine($"Модель: {item.name}");
                Console.WriteLine($"Цена: {item.cost}");
                Console.WriteLine($"Мощность: {item.power}");
            }
            Console.WriteLine("- - - - - - - - - - - -");
        }
    }
        public static class BinFormat {
            public static void BinSeria(object name, string filename) {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    binaryFormatter.Serialize(fs, name);
                    Console.WriteLine("Объект сериализован");
                    fs.Close();
                }
            }
            public static void BinDeSeria( string filename)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    Computer newcomputer = (Computer)binaryFormatter.Deserialize(fs);
                    Console.WriteLine("Объект десериализован");
                    Console.WriteLine($"Название: {newcomputer.name} --- Цена: {newcomputer.cost}$ Мощность {newcomputer.power}");
                }
            }
        }
    public static class SoapForm {
        public static void SoapSeria(object name, string filename) {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, name);

                Console.WriteLine("Объект сериализован");
            }
        }
        public static void SoapDeSeria(string filename)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Computer newcomputer = (Computer)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Название: {newcomputer.name} --- Цена: {newcomputer.cost}$ и Мощность {newcomputer.power}");
            }

        }
    }
    public static class XMLForm
    {
        public static void XMLSeria(Workstation name, string filename)
        {
            XmlSerializer xSer = new XmlSerializer(typeof(Workstation));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                xSer.Serialize(fs, name);

                Console.WriteLine("Объект сериализован");
            }
        }
        public static void XMLDeSeria(string filename)
        {
            XmlSerializer xSer = new XmlSerializer(typeof(Workstation));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Computer newP = xSer.Deserialize(fs) as Workstation;
                Console.WriteLine(newP.ToString());
            }

        }
    }
    public static class JsonForm
    {
        public static void JsonSeria(Computer name, string filename)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Computer));
            using (FileStream fs = new FileStream(filename,FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, name);
                Console.WriteLine("Объект сериализован");
            }
        }
        public static void JsonDeSeria(string filename)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Computer));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Computer newсomp = (Computer)jsonFormatter.ReadObject(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine(newсomp.ToString());
            }

        }
    }
    public static class JsonFormMas
    {
        public static void JsonSeria(Computer[] name, string filename)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Computer[]));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, name);
                Console.WriteLine("Объект сериализован");
            }
        }
        public static void JsonDeSeria(string filename)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Computer[]));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Computer[] newсomp = (Computer[])jsonFormatter.ReadObject(fs);
                Console.WriteLine("Объект десериализован");
                foreach (object items in newсomp) { Console.WriteLine(items.ToString()); }
            }

        }

    }


}