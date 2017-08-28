using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VoxelBusters.NativePlugins;

public class Title : MonoBehaviour {
	bool credits = false;
	public UIPanel creditsPanel;
    public GameObject loading;

    bool _isAvailable = false;
    bool _isAuthenticated = false;
    string message = "";
    // Use this for initialization
    void Start () {
        _isAvailable = NPBinding.GameServices.IsAvailable();
        if (_isAvailable)
        {
            _isAuthenticated = NPBinding.GameServices.LocalUser.IsAuthenticated;
            if (!_isAuthenticated)
            {
                NPBinding.GameServices.LocalUser.Authenticate((bool _success, string _error) => {

                    if (_success)
                    {
                         
                    }
                    else
                    {

                    }
                });
            }
        }
    }

	public void play(){
		if (PlayerPrefs.GetInt ("PlayedGame", 0) == 0) {
            loading.SetActive(true);
            PlayerPrefs.SetInt ("PlayedGame", 1);
			PlayerPrefs.SetString ("scene", "Scene" + 1);
			SceneManager.LoadScene ("InGame");
		} else {
			SceneManager.LoadScene ("LevelSelection");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			PlayerPrefs.SetInt ("PlayedGame", 0);
			Debug.Log ("not played");
		}
	}

	public void Credits(){
		if (!credits) {
			creditsPanel.GetComponent<TweenAlpha> ().PlayForward ();
			credits = true;
		} else {
			creditsPanel.GetComponent<TweenAlpha> ().PlayReverse ();
			credits = false;
		}
	}
}
