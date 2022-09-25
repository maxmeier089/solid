using WeatherStationDI;

namespace WeatherStationDI1
{
    public class WeatherSensors1 : IWeatherSensors
    {

        public double ReadTemperature()
        {
            return 26.9;
        }

        public double ReadHumidity()
        {
            return 23.4;
        }

        public double ReadWindSpeed()
        {
            return 7.4;
        }

    }
}
