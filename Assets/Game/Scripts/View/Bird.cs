using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    [SerializeField] GameObject _birdController;

    GameObject _instance;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateBird(string flg)
    {
        if(flg == "on") {
            _instance = Instantiate(_birdController);
        }
        else {
            if(_instance != null) {
                Destroy(_instance);
            }
        }
    }
}
