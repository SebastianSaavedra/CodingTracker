using CodingTracker.Model;

namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseController controller = new DatabaseController();

            //Console.WriteLine("1: ");
            //string texto1 = Console.ReadLine();
            //Console.WriteLine("2: ");
            //string texto2 = Console.ReadLine();

            //CodingSession session = new CodingSession
            //{
            //    StartTime = texto1,
            //    EndTime = texto2,
            //};

            //Task<CodingSession> task = controller.UpdateNewSession(2,session);

            //Console.WriteLine("___");
            //Console.WriteLine("1: ");
            //string texto3 = Console.ReadLine();
            //Console.WriteLine("2: ");
            //string texto4 = Console.ReadLine();

            //CodingSession session1 = new CodingSession
            //{
            //    StartTime = texto3,
            //    EndTime = texto4,
            //};
            //controller.CreateNewSession(session1);

            //Console.ReadKey();
            //controller.DeleteNewSession(1);
        }
    }
}