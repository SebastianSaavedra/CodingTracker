using CodingTracker.Controllers;
using CodingTracker.GUI;
using CodingTracker.GUI.MainMenuExample;
using CodingTracker.Interface;
using CodingTracker.Model;
using CodingTracker.Utils;
using ConsoleTableExt;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Terminal.Gui;

namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<IDatabaseController, DatabaseController>()
            .BuildServiceProvider();

            IDatabaseController? dbController = serviceProvider.GetService<IDatabaseController>();
            //CodingGoalsController codingGoalsController = new CodingGoalsController();
            //Reports reports = new Reports();

            Application.Init();

            var mainMenu = new MainMenuWindow(dbController!);

            mainMenu.Show();

            Application.Run();

            //var lookupTable = new Dictionary<int, Period>
            //{
            //    {1,Period.Day},
            //    //{2,Period.Week},
            //    {2,Period.Month},
            //    {3,Period.Year},
            //};

            //Console.WriteLine("filter: 1 2 3");
            //string userInput = Console.ReadLine();

            //Period result = lookupTable.TryGetValue(int.Parse(userInput!), out var period) ? period : default;

            //Console.WriteLine("value: ");
            //string value = Console.ReadLine();

            //Console.WriteLine("ascending: 0 1");
            //string asc = Console.ReadLine();

            //var sessions = databaseController.GetAllSessions(result, int.Parse(value!), bool.Parse(asc!));

            //var report = reports.GenerateReports(sessions,result);

            //ConsoleTableBuilder.From(sessions).ExportAndWriteLine();
            //ConsoleTableBuilder.From(report).ExportAndWriteLine();
        }
    }
}