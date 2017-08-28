using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class LevelSelection : MonoBehaviour {
	
	public UIButton[] recordButtons;
	public UIPanel panel;
	public GameObject loading;
	public UISprite muteButton;
	public UISprite controlButton;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("continueBGM", 0);
		if (PlayerPrefs.GetInt ("unlockedScene1") != 1) {
			PlayerPrefs.SetInt ("unlockedScene1", 1);
		}
		//PlayerPrefs.DeleteAll ();

		if (PlayerPrefs.GetInt ("Mute") == 1)
			Mute ();

		if (PlayerPrefs.GetInt ("Control") == 1) {
			controlButton.spriteName = "tap";
			controlButton.GetComponent<UIButton> ().normalSprite = "tap";
		}

		if (PlayerPrefs.GetString ("scene") != "") {
			string texto = PlayerPrefs.GetString ("scene", "Scene1");
			string num = texto.Split (new char[1]{ 'e' }) [2];
			int level = (int.Parse (num) - 1);
			panel.transform.localPosition = new Vector3 (-400 * level, panel.transform.position.y, panel.transform.position.z);
			panel.clipOffset = new Vector2 (400 * level, panel.clipOffset.y);
		}

		PlayerPrefs.SetInt ("timesDied", 0);
		for (int i = 0; i < recordButtons.Length; i++) {
			if (PlayerPrefs.GetInt ("unlockedScene" + (i+1),0) != 1) {
				recordButtons[i].isEnabled = false;
			}
		}
		//	

		for (int i = 0; i < recordButtons.Length; i++) {
			float recordSeconds = PlayerPrefs.GetFloat ("recordScene" + (i + 1), -1f);
			recordButtons[i].transform.Find("record").gameObject.SetActive(recordSeconds > 0);
			if (recordSeconds > 0) {
				int minutes = (int)((recordSeconds) / 60);
				int seconds = (int)((recordSeconds) % 60);
				int dec = (int)(((recordSeconds) % 60 * 10f) - ((int)((recordSeconds) % 60) * 10));
				recordButtons[i].transform.Find("record").GetComponent<UILabel>().text = "" + (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds + "." + dec;	
			}
		}
	}

	public void launchLevel(string texto){
		string num = texto.Split (new char[1]{ 'L' }) [2];
		#if !UNITY_EDITOR
		Analytics.CustomEvent ("enteringLevel" + num);
		#endif
		PlayerPrefs.SetString ("scene", "Scene" + num);
		if(loading != null)
			loading.SetActive (true);
		SceneManager.LoadScene ("InGame");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			PlayerPrefs.DeleteAll ();
			Debug.Log ("delet this");
			SceneManager.LoadScene ("LevelSelection");
		}

		if (Input.GetKeyDown (KeyCode.U)) {
			for (int i = 0; i < recordButtons.Length; i++) {
				PlayerPrefs.SetInt ("unlockedScene" + (i+1), 1);
			}
			SceneManager.LoadScene ("LevelSelection");
		}
	}

	void Mute(){
		PlayerPrefs.SetInt ("Mute", 1);
		muteButton.spriteName = "mute2";
		muteButton.GetComponent<UIButton> ().normalSprite = "mute2";
		Camera.main.GetComponent<AudioSource> ().mute = true;
	}

	void UnMute(){
		PlayerPrefs.SetInt ("Mute", 0);
		muteButton.spriteName = "mute";
		muteButton.GetComponent<UIButton> ().normalSprite = "mute";
		Camera.main.GetComponent<AudioSource> ().mute = false;
	}

	public void MuteButton(){
		if (PlayerPrefs.GetInt ("Mute") == 0)
			Mute ();
		else
			UnMute ();
	}

	public void ControlButton(){
		if (PlayerPrefs.GetInt ("Control") == 0) {
			controlButton.spriteName = "tap";
			controlButton.GetComponent<UIButton> ().normalSprite = "tap";
			PlayerPrefs.SetInt ("Control", 1);
		} else {
			controlButton.spriteName = "swipe";
			controlButton.GetComponent<UIButton> ().normalSprite = "swipe";
			PlayerPrefs.SetInt ("Control", 0);
		}
	}
}
