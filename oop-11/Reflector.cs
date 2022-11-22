using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_11
{

    class Configuration
    {
        public string funcname { get; set; }
        public string className { get; set; }
        public param param { get; set; }
    }
    public class param
    {
        public string name { get; set; }
        public int course { get; set; }
    }
    static class Reflector
    {
        static void Write(string text)
        {
            string path = "Lab11.txt";
            File.AppendAllText(path, text);
        }
        public static void GetAssemblyName<T>(T obj)
        {
            Assembly a = typeof(T).Assembly;
            Write("Имя сборки, в которой определен класс: " + a.FullName + "\n\n");
            Console.WriteLine("Имя сборки: " + a.FullName + "\n");
        }
        public static void IsPublicConstructors<T>(T obj)
        {
            ConstructorInfo[] constructorInfo = typeof(T).GetConstructors();
            for (int i = 0; i < constructorInfo.Length; i++)
                if ((constructorInfo[i].IsPublic))
                {
                    Write("Публичный конструктор: " + constructorInfo[i].Name + "\n");
                    Console.WriteLine("Публичный конструктор " + (i + 1) + "\n");
                }
                else
                {
                    Write("Класс не имеет публичный конструктор\n");
                    Console.WriteLine("Публичный конструктор отсутствует \n");

                }
        }
        public static void GetAllMethods<T>(T obj)
        {
            MethodInfo[] methodInfo = typeof(T).GetMethods();
            Console.Write($"Публичные методы класса: \n");
            Write($"\nИзвлекает все общедоступные публичные методы класса: \n");
            foreach (MethodInfo method in methodInfo)
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                if (method.IsAbstract)
                    modificator += "abstract";
                Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} \n");
                Write($"{modificator} {method.ReturnType.Name} {method.Name} \n");
            }
        }
        public static void GetFieldsProp<T>(T obj)
        {

            FieldInfo[] fieldInfo = typeof(T).GetFields();
            PropertyInfo[] propertyInfo = typeof(T).GetProperties(); 
            Console.WriteLine("\nИнформация о полях:");
            Write("\nИнформация о полях:\n");
            foreach (FieldInfo field in fieldInfo)
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
                Write($"{field.FieldType} {field.Name}\n");
            }
            Write("\nСвойства класса:\n");
            Console.WriteLine("\nСвойства класса:");
            foreach (PropertyInfo prop in propertyInfo)
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}\n");
                Write($"{prop.PropertyType} {prop.Name}\n");
            }
        }
        public static void GetInterface<T>(T obj) {
            Type[] interfacesInfo = typeof(T).GetInterfaces();
            Write("\nИнтерфейсы, реализованные классом:\n");
            Console.WriteLine("Все реализованные классом интерфейсы:");
            foreach (Type i in interfacesInfo)
            {
                Console.WriteLine(i.Name);
            }
        }
        public static void GetSpecialMethod<T>(T obj, string type)
        {
            {
                MethodInfo[] methods = typeof(T).GetMethods();
                Console.WriteLine($"\nМетоды, содержащие параметр типа {type}:");
                Write($"\nМетоды, содержащие параметр типа {type}:\n");
                foreach (MethodInfo method in methods)
                {
                    ParameterInfo[] parameters = method.GetParameters();
                    foreach (ParameterInfo param in parameters)
                    {
                        string modificator = "";
                        if (method.IsPublic) modificator += "public ";
                        if (method.IsPrivate) modificator += "private ";
                        if (method.IsStatic) modificator += "static ";
                        if (method.IsVirtual) modificator += "virtual ";
                        Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} \n");
                        Write($"{modificator} {method.ReturnType.Name} {method.Name} \n");
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            if (parameters[i].ParameterType.Name == type)
                            {
                                Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} \n");
                                Write($"{modificator} {method.ReturnType.Name} {method.Name}\n");
                                break;
                            }
                        }
                    }
                }
            }
        }
        public static void gMethod()
        {
            Configuration conf;
            using (var stream = new StreamReader("oop-11.json"))
            {
                var cont = stream.ReadToEnd();
                conf = JsonSerializer.Deserialize<Configuration>(cont);
            }

            Student student = new Student("Kate", "Ivanova", 2);
            Type.GetType($"oop_11.{conf.className}").GetMethod(conf.funcname).Invoke(student, new object[] { conf.param.name, conf.param.course });
        }
        public static object Create(Type t) => Activator.CreateInstance(t);
    }
}
