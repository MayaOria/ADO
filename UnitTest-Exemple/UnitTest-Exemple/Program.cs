using System;

namespace UnitTest_Exemple
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int a = 3; 
            int b = 5;
            Operation op = new Operation();
            int somme = op.Addition(a, b);
            Console.WriteLine($"La somme de {a} + {b} = {somme}");
            Console.ReadLine();
        }
    }
}
