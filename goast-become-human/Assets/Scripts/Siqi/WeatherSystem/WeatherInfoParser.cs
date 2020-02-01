using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leguar.TotalJSON;

public class WeatherInfoParser
{
    public static WeatherInfo Parse(string openWeatherJSON) {
		JSON rawObject= JSON.ParseString(openWeatherJSON);

        var weathers = rawObject.GetJArray("weather");
        var weather = weathers.GetJSON(0);

        var main = rawObject.GetJSON("main");

        var weatherInfo = new WeatherInfo();
        weatherInfo.weatherType = weather.GetString("main");
        weatherInfo.temperature = main.GetFloat("temp");

        return weatherInfo;
	}
}
