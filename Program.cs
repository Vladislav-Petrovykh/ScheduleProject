using System;
using ScheduleProject.schedule;

namespace ScheduleProject
{
    class Program
    {
        static Schedule schedule;

        static void PrintResult(DateTime input)
        {
            Console.WriteLine();
            Console.WriteLine($"  Prev = " + schedule.NextPrev(input).ToString("yyyy.MM.dd HH:mm:ss.fff"));
            Console.WriteLine($" Preve = " + schedule.NearestPrev(input).ToString("yyyy.MM.dd HH:mm:ss.fff"));
            Console.WriteLine($"Input  = " + input.ToString("yyyy.MM.dd HH:mm:ss.fff"));
            Console.WriteLine($" Neare = " + schedule.Nearest(input).ToString("yyyy.MM.dd HH:mm:ss.fff"));
            Console.WriteLine($"  Next = " + schedule.Next(input).ToString("yyyy.MM.dd HH:mm:ss.fff"));
        }

        static string InputPattern()
        {
            string pattern;
            string readed;

            while (true)
            {
                Console.Write("Please, input pattern : ");

                readed = Console.ReadLine();

                if (readed.Contains("def"))
                {
                    schedule = new Schedule();
                    return "dafault";
                }

                try
                {
                    schedule = new Schedule(readed);
                    pattern = readed;
                    return pattern;
                }
                catch
                {
                    Console.WriteLine();
                    continue;
                }
            }
        }

        static void CustomCheck()
        {
            string pattern = InputPattern();
            string readed;
            DateTime input;
            
            while (true)
            {
                Console.WriteLine($"\nPattn = {pattern}");
                Console.Write("Please, input datetime : ");

                readed = Console.ReadLine();

                if (readed.Contains("exit"))
                {
                    break;
                }

                if (readed.Contains("patt"))
                {
                    Console.WriteLine();
                    pattern = InputPattern();
                    continue;
                }

                try
                {
                    input = DateTime.Parse(readed);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                PrintResult(input);
            }
        }

        static void SpecificCheck()
        {
            string pattern = "2021.7.12 21:20:15.5";

            schedule = new Schedule(pattern);

            DateTime input = DateTime.Parse("1:01:12.223");

            Console.WriteLine($"Patte = {pattern}");
            PrintResult(input);
        }

        static void Main(string[] args)
        {
            //CustomCheck();
            SpecificCheck();
        }
    }
}
