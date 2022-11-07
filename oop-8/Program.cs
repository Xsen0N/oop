namespace oop_8
{
    public class Program
    {
        //обработчик событий
        static void DisplayMessage(string message)
        {
            Console.WriteLine("-------Уведомление!-------");
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {

            Game game1 = new Game(10);
            Game game2 = new Game(1);
            Game game3 = new Game(2);
            Game game4 = new Game(4);
            Console.WriteLine(game1.ToString());
            Console.WriteLine(game2.ToString());
            Console.WriteLine(game3.ToString());
            Console.WriteLine(game4.ToString());
            game1.Notify += new Game.GameAction(DisplayMessage);
            game2.Notify += DisplayMessage;
            game3.Notify += DisplayMessage;
            game4.Notify += DisplayMessage;
            game1.Figth(game1.heart, "сильный");
            game2.Heal(game2.heart);
            game2.Heal(game2.heart);
            game4.Figth(game1.heart, "суперсильный");
            game1.Heal(game1.heart);
            game4.Notify -= DisplayMessage;
            game4.Figth(game1.heart, "суперсильный");
            Console.WriteLine("\n-------Список игроков-------\n");
            Console.WriteLine(game1.ToString());
            Console.WriteLine(game2.ToString());
            Console.WriteLine(game3.ToString());
            Console.WriteLine(game4.ToString());
            Console.WriteLine("\n---------------------\n");

            string changingStr = "Nice String";
            StrAct lowNup = StringAction.Lower;
            lowNup += StringAction.Upper;
            lowNup(changingStr);
            Predicate<int> isLong = (int x) => x > 5;
            Console.WriteLine(isLong(changingStr.Length));
            DoOperation(changingStr, StringAction.Remove);
            DoOperation(changingStr, StringAction.Insert);
            void DoOperation(string str, Action<string> op) => op(changingStr);
            Func<string, string> convertMethod = StringAction.RemoveEleminstr;
            Console.WriteLine(convertMethod(changingStr));
            convertMethod += StringAction.Reverse;
            Console.WriteLine(convertMethod(changingStr));
            Func<string, string> convert = delegate (string str)
            { return str.Insert(str.Length, "!!!!!"); };
            Console.WriteLine(convert(changingStr));
            string secOperation(string str, Func<string, string> operation) => operation(str);
            Console.WriteLine(secOperation(changingStr, str => str.Insert(1, "/")));

        }

    }
}