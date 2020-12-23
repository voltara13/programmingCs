using System;
using System.Globalization;

namespace programmingCs
{
    class Airline
    {
        private string destination;
        private string flightNumber;
        private string dayWeek;
        private DateTime departureTime;
        public Airline(string destination, string flightNumber, string departureTime)
        {
            try
            {
                this.destination = destination;
                this.flightNumber = flightNumber;
                DateTime.TryParse(departureTime, out this.departureTime);
                dayWeek = this.departureTime.ToString("dddd", new CultureInfo("ru-RU"));
            }
            catch (Exception)
            {
                Console.WriteLine("Введены неверные данные");
                throw;
            }
        }
        public override string ToString()
        {
            string outAirline =
                $"Рейс: {flightNumber}\n" +
                $"Место прибытия: {destination}\n" +
                $"Время вылета: {departureTime}";
            return outAirline;
        }
        public string Destination => destination;
        public string FlightNumber => flightNumber;
        public string DayWeek => dayWeek;
        public DateTime DepartureTime => departureTime;
    }
}
