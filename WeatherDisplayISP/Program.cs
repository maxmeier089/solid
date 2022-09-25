using WeatherDisplayISP;
using WeatherStationISP;

TemperatureDisplay display = new(new WeatherSensors());

display.DisplayTemperature();