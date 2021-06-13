using System;

namespace spot_a_hub
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class Books
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumberOfPages { get; set; }
        public DateTimeOffset DateAdded { get; set; }

    }
}
