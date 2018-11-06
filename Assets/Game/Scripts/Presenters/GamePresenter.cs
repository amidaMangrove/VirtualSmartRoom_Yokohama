using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour {

    [Header("Views")]
    [SerializeField] Lighting _lighting;
    [SerializeField] Weather _weather;
    [SerializeField] Flag _flag;
    FirebaseRestAPI _dbReceiver = FirebaseRestAPI.Instance;

    void Start () {

        _dbReceiver.CreateNewConnect("https://virtualsmartroom-307ba.firebaseio.com/");

        _dbReceiver.AddObserbser("light", (sender, data) =>
        {
            _lighting.UpdateLight(data.RawValue.ToString());
        });

        _dbReceiver.AddObserbser("weather", (sender, data) =>
        {
            _weather.UpdateWeather(data.RawValue.ToString());
        });

        _dbReceiver.AddObserbser("flag", (sender, data) =>
        {
            _flag.UpdateFlag(data.RawValue.ToString());
        });
    }
	
}
