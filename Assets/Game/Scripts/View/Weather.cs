
using UnityEngine;

public class Weather : MonoBehaviour {

    [Header("Audios")]
    [SerializeField] AudioClip _sunAudio;
    [SerializeField] AudioClip _rainAudio;
    [SerializeField] AudioClip _cloudAudio;
    [SerializeField] AudioClip _snowAudio;

    [Header("Skyboxs")]
    [SerializeField] Material _sunSkybox;
    [SerializeField] Material _rainSkybox;
    [SerializeField] Material _cloudSkybox;
    [SerializeField] Material _snowSkybox;

    [Header("Particles")]
    [SerializeField] GameObject _rainParticle;
    [SerializeField] GameObject _snowParticle;
    AudioSource _audio;

	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

	}

    public void UpdateWeather(string weather)
    {
        _rainParticle.SetActive(false);
        _snowParticle.SetActive(false);
        if (weather == "sun") {
            _audio.clip = _sunAudio;
            _audio.Play();
            RenderSettings.skybox = _sunSkybox;
        }

        if (weather == "rain") {
            _audio.clip = _rainAudio;
            _audio.Play();
            _rainParticle.SetActive(true);
            RenderSettings.skybox = _rainSkybox;
        }


        if (weather == "cloud") {
            _audio.clip = _cloudAudio;
            _audio.Play();

            RenderSettings.skybox = _cloudSkybox;
        }

        if (weather == "snow") {
            _audio.clip = _snowAudio;
            _audio.Play();

            RenderSettings.skybox = _snowSkybox;
            _snowParticle.SetActive(true);
        }
    }
}
