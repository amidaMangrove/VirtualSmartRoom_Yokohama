using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour {

    FirebaseRestAPI _dbReceiver = FirebaseRestAPI.Instance;

    void Start () {

        _dbReceiver.CreateNewConnect("https://virtualsmartroom-307ba.firebaseio.com/");

        _dbReceiver.AddObserbser("light", (sender, data) =>
        {
            Debug.Log(data.RawValue);
        });
    }
	
}
