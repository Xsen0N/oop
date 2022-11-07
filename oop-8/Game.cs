using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_8
{
    public class Game
    {
        public delegate void GameAction(string message);
        public event GameAction Notify;
        public int heart { get; set; }
        public Game(int heart) => this.heart = heart;
        public int Figth(int hearts, string bumb) {
            int hero = 0;
            if (bumb == "сильный") {
                Console.WriteLine("Не повезло. Противник нанес неплохой удар");
                heart -= 2;
            }
            else if (bumb == "суперсильный")
            {
                Console.WriteLine("Очень сильное ранение");
                heart -= 3;
            }
            else if (bumb == "слабый")
            {
                Console.WriteLine("Слабое ранение");
                heart -= 1;
            }
            if (heart <= 0)
            {
                Console.WriteLine("Убиты!!!");
                hero += hero;
                DeadHero(hero);
                heart = 0;
                Notify?.Invoke("У вас 0 жизней");//Вызов события
                return 0;
            }
            else {
                Notify?.Invoke($"Осталось еще {heart} ");
                return heart; } 
        }
        public override string ToString() => $"Кол-во сердец: {heart}";
        public void Heal(int hearts) {
            heart += 1;
        Notify?.Invoke($"Вылечились до {heart} ");
        }
        public void DeadHero(int hero) => Console.WriteLine($"Кол-во проигравших игроков{hero}");
    }
}
