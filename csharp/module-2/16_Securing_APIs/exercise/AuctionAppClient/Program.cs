namespace AuctionApp
{
    public class Program
    {
        private const string apiUrl = "https://localhost:44390/";
        static void Main()
        {
            AuctionApp app = new AuctionApp(apiUrl);
            app.Run();
        }
    }
}
