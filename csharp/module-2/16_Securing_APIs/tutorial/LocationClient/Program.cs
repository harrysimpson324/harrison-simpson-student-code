namespace LocationClient
{
    class Program
    {
        private const string ApiUrl = "https://localhost:44387/";
        static void Main()
        {
            LocationApp app = new LocationApp(ApiUrl);
            app.Run();
        }
    }
}
