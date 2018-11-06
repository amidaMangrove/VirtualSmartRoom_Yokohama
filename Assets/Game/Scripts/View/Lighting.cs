
using UnityEngine;

public class Lighting : MonoBehaviour {

    [SerializeField] float min = 0.0f;
    [SerializeField] float max = 1.6f;

    Light _light;
    float intencity;
	// Use this for initialization
	void Start () {
        _light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {

        _light.intensity = Mathf.Lerp(_light.intensity, intencity, Time.deltaTime);
	}

    public void UpdateLight(string flg)
    {
        intencity = (flg == "on") ? max : min;
    }
}
