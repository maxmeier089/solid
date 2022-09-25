using WeatherStationDI;
using WeatherStationUSA;

namespace WeatherStationUSAAdapter
{
    public class AdapterSensorUSA : ITemperatureSensor
    {

        private readonly SensorUSA sensorUSA;

        public double ReadTemperature()
        {
            return ((double)sensorUSA.GetTemperature() - 32.0) * (5.0 / 9.0);
        }

        public AdapterSensorUSA(SensorUSA sensorUSA)
        {
            this.sensorUSA = sensorUSA;
        }
    }
}
