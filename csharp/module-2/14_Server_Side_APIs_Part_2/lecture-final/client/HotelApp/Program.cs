namespace HotelReservationsClient
{
    class Program
    {
        private const string ApiUrl = "https://localhost:44322/";
        static void Main()
        {
            HotelApp app = new HotelApp(ApiUrl);
            app.Run();
        }
    }
}
