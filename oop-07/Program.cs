namespace oop07
{
    public class Technique
    {
        int ID;
        string name = "Техника";
        int lifespan { get; set; }
        double cost { get; set; }
        protected const string power = "50 W/hr.";
        public void Power() {
            Console.WriteLine(power);
        }
        public Technique()
        {
            ID = GetHashCode();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            CollectionType<int> collectionType = new CollectionType<int>();
            CollectionType<double> collectionTyped = new CollectionType<double>();
            CollectionType<char> collectionTypec = new CollectionType<char>();
            CollectionType<Technique> collectionTypeС = new CollectionType<Technique>();
            Technique technique = new Technique();
            try
            {
                collectionTypec.Add('g');
                collectionTypec.Add('r');
                collectionTypec.Add('1');
                collectionTyped.Add(148.962);
                collectionTyped.Add(-96.475);
                collectionType.Add(1);
                collectionType.Add(2);
                collectionType.Remove(1);
                collectionType.Show();
                collectionTypeС.Add(technique);
                collectionType.Add("sjsjjs");
            }
            catch (NotImplementedException ex) {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                collectionType.WriteTextFile();
                collectionType.ReadTextFile();
                collectionType.FileInfo();
                Console.WriteLine("Завершение");
            }
            
            collectionTyped.Add(148.962);
            collectionTyped.Add(-96.475);
        }
    }
}