using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour {

    [Header("Views")]
    [SerializeField] Lighting _lighting;
    [SerializeField] Weather _weather;
    [SerializeField] Flag _flag;
    [SerializeField] Player _player;
    [SerializeField] Bird _bird;
    FirebaseRestAPI _dbReceiver = FirebaseRestAPI.Instance;

    void Start () {

        _dbReceiver.CreateNewConnect("URL");

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

        _dbReceiver.AddObserbser("reverse", (sender, data) =>
        {
            _player.UpdatePlayer(data.RawValue.ToString());
        });

        _dbReceiver.AddObserbser("bird", (sender, data) =>
        {
            _bird.UpdateBird(data.RawValue.ToString());
        });
    }
	
}
