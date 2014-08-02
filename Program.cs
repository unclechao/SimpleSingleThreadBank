using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Bank crashBank = Bank.GetInstance();
            #region single thread
            //crashBank.SaveMoney(r.Next(1, 1000));
            //crashBank.SaveMoney(r.Next(1, 1000));
            //crashBank.DrawMoney(r.Next(1, 1000));
            //crashBank.SaveMoney(r.Next(1, 1000));
            //crashBank.DrawMoney(r.Next(1, 1000));
            //crashBank.DrawMoney(r.Next(1, 1000));
            //crashBank.SaveMoney(r.Next(1, 1000));
            //crashBank.DrawMoney(r.Next(1, 1000));
            //crashBank.DrawMoney(r.Next(1, 1000));
            #endregion
            #region Multithreading
            Thread t1 = new Thread(crashBank.SaveMoney);
            Thread t2 = new Thread(crashBank.DrawMoney);
            Thread t3 = new Thread(crashBank.SaveMoney);
            Thread t4 = new Thread(crashBank.DrawMoney);
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            #endregion
            Console.ReadKey();
        }
    }
}
