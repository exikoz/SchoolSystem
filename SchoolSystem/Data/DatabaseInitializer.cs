using System.Threading;
using System.Threading.Tasks;

namespace SchoolSystem.Data
{
    public static class DatabaseInitializer
    {
        public static void WarmUp()
        {
            Console.CursorVisible = false;
            Console.Write("Initializing system... ");
            
            // Run database initialization in a background task
            var initializationTask = Task.Run(() =>
            {
                using (var context = new SchoolSystemContext())
                {
                    // Forces EF Core to initialize
                    _ = context.Students.FirstOrDefault();
                }
            });

            // Animated spinner while waiting
            var spinner = new[] { '|', '/', '-', '\\' };
            int counter = 0;

            while (!initializationTask.IsCompleted)
            {
                Console.Write(spinner[counter % spinner.Length]);
                Thread.Sleep(100);
                Console.Write("\b"); // Backspace
                counter++;
            }

            // Ensure task completes and re-throw any exceptions
            initializationTask.GetAwaiter().GetResult();

            Console.CursorVisible = true;
            Console.Clear();
        }
    }
}
