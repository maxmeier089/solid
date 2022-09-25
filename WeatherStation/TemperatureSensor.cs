namespace WeatherStation
{
    public class TemperatureSensor : IWeatherSensors
    {

        public double ReadTemperature()
        {
            return 26.9;
        }

        public double ReadHumidity()
        {
            throw new NotImplementedException();
        }

        public double ReadWindSpeed()
        {
            return 0.0;
        }

    }
}
