namespace WeatherStation
{
    public interface IWeatherSensors
    {

        public double ReadTemperature();

        public double ReadHumidity();

        public double ReadWindSpeed();

    }
}
