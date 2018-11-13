using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float _targetAngle;
    Vector3 _angle;

    AudioSource _audio;
    // Use this for initialization
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _angle = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        _angle.z = Mathf.Lerp(_angle.z, _targetAngle, 0.1f);
        transform.rotation = Quaternion.Euler(_angle);
    }

    public void UpdatePlayer(string flg)
    {
        _targetAngle = (flg == "on") ? 180.0f : 0.0f;
        _audio.Play();
    }
}
