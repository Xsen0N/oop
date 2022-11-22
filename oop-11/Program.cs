namespace oop_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
                        Student student = new Student("Kate", "Ivanova", 2);
            Phone phone = new Phone("Александр", 10, 56);

            Console.WriteLine(student);

            Reflector.GetAssemblyName(student.GetType());
            Reflector.GetAssemblyName(student);
            Reflector.IsPublicConstructors(student);
            Reflector.GetAllMethods(student);
            Reflector.GetFieldsProp(student);
            Reflector.GetInterface(student);
            Reflector.GetSpecialMethod(student, "void");
            Console.WriteLine("\nРабота InvokeMethod:");
            Reflector.gMethod();
            Console.WriteLine(Reflector.Create(typeof(Student)));
            Console.WriteLine(typeof(Student));
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine(phone);
            Reflector.GetAssemblyName(phone.GetType());
            Reflector.IsPublicConstructors(phone);
            Reflector.GetAllMethods(phone);
            Reflector.GetFieldsProp(phone);
            Reflector.GetInterface(phone);
            Reflector.GetSpecialMethod(phone, "void");
        }
    }
}