using WeatherDisplayDI;
using WeatherStationDI;
using WeatherStationDI1;


ITemperatureSensor temperatureSensor = new WeatherSensors1();

//ITemperatureSensor temperatureSensor = new WeatherSensors2();

//AdapterSensorUSA temperatureSensor = new AdapterSensorUSA(new SensorUSA());


TemperatureDisplay display = new(temperatureSensor);

display.DisplayTemperature();