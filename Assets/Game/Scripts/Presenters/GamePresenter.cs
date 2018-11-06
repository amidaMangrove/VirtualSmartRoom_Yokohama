using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour {

    [Header("Views")]
    [SerializeField] Lighting _lighting;
    FirebaseRestAPI _dbReceiver = FirebaseRestAPI.Instance;

    void Start () {

        _dbReceiver.CreateNewConnect("https://virtualsmartroom-307ba.firebaseio.com/");

        _dbReceiver.AddObserbser("light", (sender, data) =>
        {
            _lighting.UpdateLight(data.RawValue.ToString());
        });
    }
	
}
