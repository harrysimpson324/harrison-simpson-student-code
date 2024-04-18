using Tutorial.Services;

namespace Tutorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=PizzaShopLite;Trusted_Connection=True;";
            ConsoleService console = new ConsoleService();

            TutorialController controller = new TutorialController(connectionString, console);
            controller.Run();
        }
    }
}
