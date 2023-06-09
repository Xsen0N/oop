using System;

namespace checked_unchecked
{
    class Checked_unchecked
    {
        static void Main(string[] args)
        {
            int Fun1() {
                checked{ // проверяется на переполнение, происходит обработка исключений               
                    int x = int.MaxValue;
                    try{
                        return x + 1;

                    }catch (OverflowException){
                        Console.WriteLine("Переполнение");
                        return x;
                    }
                }
            }

            int Fun2()
            {
                unchecked{// не проверяется на переполнение                
                    int x = int.MaxValue;
                    try{                   
                        return x + 1;
                    }catch (OverflowException){                   
                        Console.WriteLine("Переполнение");
                        return x;
                    }
                }
            }
            Console.WriteLine(Fun1());
            Console.WriteLine(Fun2());
        }
    }
}
