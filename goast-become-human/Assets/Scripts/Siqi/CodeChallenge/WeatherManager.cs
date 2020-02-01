using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocationGetter))]
public class WeatherManager : MonoBehaviour
{
    const string API_KEY = "9951994425c9141f94b240d61ba45152";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitWeather());
    }

    IEnumerator InitWeather() {
        var wr = RequestWeather();
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

    UnityWebRequest RequestWeather() {
        WWW myWww = new WWW("https://samples.openweathermap.org/data/2.5/weather?id=2177535&appid=9951994425c9141f94b240d61ba45152");
        // ... is analogous to ...
        UnityWebRequest myWr = UnityWebRequest.Get("https://samples.openweathermap.org/data/2.5/weather?id=2177535&appid=9951994425c9141f94b240d61ba45152");
        return myWr;
    }

    void ChangeSceneWeather(WeatherInfo weatherInfo) {
        Debug.Log("weather: " + weatherInfo.weatherType);
        Debug.Log("temp: " + weatherInfo.temperature);
    }
}
