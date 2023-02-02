using CodingTracker.Model;
using CodingTracker.Utils;
using ConsoleTableExt;
using System.Diagnostics;

namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseController databaseController = new DatabaseController();
            CodingGoalsController codingGoalsController = new CodingGoalsController();
            Reports reports = new Reports();

            Console.WriteLine("");


            //Stopwatch stopwatch = Stopwatch.StartNew();

            //while (true)
            //{
            //    Console.WriteLine(stopwatch.Elapsed.Seconds + " Seconds");
            //    Thread.Sleep(1000);
            //    Console.Clear();
            //}

            var lookupTable = new Dictionary<int, Period>
            {
                {1,Period.Day},
                //{2,Period.Week},
                {2,Period.Month},
                {3,Period.Year},
            };

            Console.WriteLine("filter: 1 2 3");
            string userInput = Console.ReadLine();

            Period result = lookupTable.TryGetValue(int.Parse(userInput!), out var period) ? period : default;

            Console.WriteLine("value: ");
            string value = Console.ReadLine();

            Console.WriteLine("ascending: 0 1");
            string asc = Console.ReadLine();

            var sessions = databaseController.GetAllSessions(result, int.Parse(value!), bool.Parse(asc!));

            var report = reports.GenerateReports(sessions,result);

            ConsoleTableBuilder.From(sessions).ExportAndWriteLine();
            ConsoleTableBuilder.From(report).ExportAndWriteLine();
        }
    }
}