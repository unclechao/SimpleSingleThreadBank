using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public sealed class Bank
    {
        private Random r = new Random();
        private static int balance = 0;
        private static readonly Bank p_bank = new Bank();
        private static object lockObj = new object();
        private Bank() { }
        public static Bank GetInstance()
        {
            return p_bank;
        }

        public void SaveMoney()
        {
            while (true)
            {
                lock (lockObj)
                {
                    int amount = r.Next(1, 10);
                    balance += amount;
                    Console.WriteLine("Save:{0},balance:{1}", amount, Bank.balance);
                }
            }
        }

        public void DrawMoney()
        {
            while (true)
            {
                lock (lockObj)
                {
                    int amount = r.Next(1, 10);
                    if ((balance - amount) >= 0)
                    {
                        balance -= amount; ;
                        Console.WriteLine("Draw:{0},balance:{1}", amount, Bank.balance);
                    }
                    else
                    {
                        Console.WriteLine("Want to Draw:{0},Not enough money! Balance:{1}", amount, Bank.balance);
                    }
                }
            }
        }
    }
}
