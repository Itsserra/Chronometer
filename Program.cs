using System;
using System.Timers;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            int hh = 0;
            int mm = 0;
            double ss = 0.00;
            Console.WriteLine("Welcome To The Chronometer Application! \n\n" +
                "Please Enter The Hours:");
            hh = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter The Minutes:");
            mm = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter The Seconds:");
            ss = double.Parse(Console.ReadLine());
            Console.WriteLine("Press Enter Key To Start");
            Console.ReadLine();
            Timer chronometer = new Timer();
            object locker = 0;
            chronometer.Interval = 0.01;
            chronometer.Elapsed += delegate
            {

                lock (locker)
                {
                    Console.Write($"\r{hh.ToString("0#")}:{mm.ToString("0#")}:{ss.ToString("0#.00")}");
                    ss = ss - 0.01;
                    if (mm == 0)
                    {
                        if (hh != 0)
                        {
                            hh--;
                            mm = 59;
                        }
                        else if (ss < 0)
                        {
                            chronometer.Stop();
                        }
                    }
                    if (ss < 0 && mm != 0)
                    {

                        mm--;
                        ss = 59.99;

                    }
                }

            };
            chronometer.Start();
            Console.ReadLine();
        }

    }
}
