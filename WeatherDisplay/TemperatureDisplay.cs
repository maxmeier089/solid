using WeatherStation;

namespace WeatherDisplay
{
    public class TemperatureDisplay
    {

        public IWeatherSensors Sensor { get; }

        public void DisplayTemperature()
        {
            if (Sensor == null)
            {
                Console.WriteLine("No sensor connected!");
            }
            else
            {
                Console.WriteLine(String.Format("{0:0.0}", Sensor.ReadTemperature()) + " °C");
            }
        }

        public TemperatureDisplay(IWeatherSensors sensor)
        {
            Sensor = sensor;
        }

    }
}
