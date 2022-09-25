using WeatherDisplay;
using WeatherStation;

TemperatureDisplay display = new(new WeatherSensors());

display.DisplayTemperature();