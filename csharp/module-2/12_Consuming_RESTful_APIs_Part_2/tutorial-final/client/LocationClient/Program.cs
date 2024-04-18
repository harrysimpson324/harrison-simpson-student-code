namespace LocationClient
{
    class Program
    {
        private const string ApiUrl = "http://localhost:3000/";
        static void Main()
        {
            LocationApp app = new LocationApp(ApiUrl);
            app.Run();
        }
    }
}
