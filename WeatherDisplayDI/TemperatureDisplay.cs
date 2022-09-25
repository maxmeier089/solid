using WeatherStationDI;

namespace WeatherDisplayDI
{
    public class TemperatureDisplay
    {

        public ITemperatureSensor Sensor { get; }

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

        public TemperatureDisplay(ITemperatureSensor sensor)
        {
            Sensor = sensor;
        }

    }
}
