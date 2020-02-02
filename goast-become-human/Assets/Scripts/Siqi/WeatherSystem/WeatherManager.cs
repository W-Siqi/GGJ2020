using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocationGetter))]
public class WeatherManager : MonoBehaviour
{
    const float SNOW_TEMP = 280;
    const string API_KEY = "9951994425c9141f94b240d61ba45152";

    public string initCityName = "Pittsburgh";
    public GameObject snowEffect = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitWeather());
    }

    IEnumerator InitWeather() {
        var wr = RequestWeather(initCityName);
        wr.SendWebRequest();
        while (true) {
            yield return null;
            if (wr.isDone) {
				var weatherInfo = WeatherInfoParser.Parse(wr.downloadHandler.text);
                ChangeSceneWeather(weatherInfo);
                break;
            }
        }
    }

    UnityWebRequest RequestWeather(string cityName) {
        WWW myWww = new WWW("https://samples.openweathermap.org/data/2.5/weather?id=2177535&appid=9951994425c9141f94b240d61ba45152");
        // ... is analogous to ...
        var url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}",cityName,API_KEY);
        UnityWebRequest myWr = UnityWebRequest.Get(url);
        return myWr;
    }

    void ChangeSceneWeather(WeatherInfo weatherInfo) {
        Debug.Log("weather: " + weatherInfo.weatherType);
        Debug.Log("temp: " + weatherInfo.temperature);
        if (weatherInfo.temperature < SNOW_TEMP)
        {
            snowEffect.SetActive(true);
        }
        else {
            snowEffect.SetActive(false);
        }
    }
}
