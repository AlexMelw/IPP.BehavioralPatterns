namespace Mediator
{
    using System;
    using Handler;
    using Models;

    public class Program
    {
        static void Main(string[] args)
        {
            var airCenter = new CIACenter(); // Chisinau International Airport Center

            var flight1 = new Airbus321("AC159", airCenter)
            {
                Altitude = 10000
            };
            var flight2 = new Boeing737200("WS203", airCenter)
            {
                Altitude = 12000
            };
            var flight3 = new Embraer190("AC602", airCenter)
            {
                Altitude = 8000
            };


            Console.Out.WriteLine($"Manually alter the altitude of {flight1.CallSign}");
            flight1.Altitude -= 2000;

            Console.ReadKey();
        }
    }
}