using System;
using UniRx;
using SimpleFirebaseUnity;

/// <summary>
/// FirebaseDBへのアクセッサモデル
/// </summary>
public class FirebaseRestAPI {

    Firebase _firebase;
    ReactiveDictionary<string, FirebaseObserver> _observers = new ReactiveDictionary<string, FirebaseObserver>();

    static FirebaseRestAPI instance = new FirebaseRestAPI();

    private FirebaseRestAPI()
    {
    }

    public static FirebaseRestAPI Instance
    {
        get { return instance;}
    }

    public void CreateNewConnect(string url)
    {
        _firebase = Firebase.CreateNew(url);
    }

    public void ConnectStart()
    {
        foreach (FirebaseObserver observer in _observers.Values) {
            observer.Start();
        }
    }
    

    /// <summary>
    /// DBの値が変更されたコールされるコールバック
    /// </summary>
    /// <param name="name"></param>
    /// <param name="OnChangeValue"></param>
    public void AddObserbser(string name, Action<Firebase, DataSnapshot> OnChangeValue)
    {

        Firebase child = _firebase.Child(name);
        child.OnGetSuccess += OnChangeValue;
        child.GetValue("print=pretty");

        _observers.Add(name, new FirebaseObserver(child, 1f));
        _observers[name].OnChange += OnChangeValue;
        _observers[name].Start();
    }

    /// <summary>
    /// 値を取得
    /// </summary>
    /// <param name="root"></param>
    /// <param name="value"></param>
    public void SetValue(string root, string value)
    {
        _firebase.Child(root).SetValue(value, true);
    }

    /// <summary>
    /// 値を取得
    /// </summary>
    /// <param name="value"></param>
    public void SetValue(string value)
    {
        _firebase.SetValue(value, true);
    }

}
