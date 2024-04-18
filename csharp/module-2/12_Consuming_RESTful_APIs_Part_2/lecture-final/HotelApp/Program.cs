namespace HotelReservationsClient
{
    class Program
    {
        private const string ApiUrl = "http://localhost:3000/";
        static void Main()
        {
            HotelApp app = new HotelApp(ApiUrl);
            app.Run();
        }
    }
}
