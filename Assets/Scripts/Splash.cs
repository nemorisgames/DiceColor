using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {
	public string nextScene = "Title";
	public float timeLimit = 7f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > timeLimit) {
			SceneManager.LoadScene (nextScene);
		}
	}
}
