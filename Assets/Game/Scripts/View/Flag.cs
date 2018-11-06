using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {

    [SerializeField] float _minY = 0.0f;
    [SerializeField] float _maxY = 4.0f;

    float _y;
    float _tgtY;
    Vector3 _defaultPosition;
    // Use this for initialization
    void Start()
    {
        _defaultPosition = transform.position;
        _tgtY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        _tgtY = Mathf.Lerp(_tgtY, _y, Time.deltaTime);
        transform.position = new Vector3(_defaultPosition.x, _tgtY, _defaultPosition.z);
    }

    public void UpdateFlag(string flg)
    {
        _y = (flg == "up") ? _maxY : _minY;
    }
}
