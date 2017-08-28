using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTutorial : MonoBehaviour {
	InGame ingame;
	Animator anim;

	// Use this for initialization
	void Start () {
		ingame = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<InGame> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		anim.SetTrigger ("Zoom");
	}

	public void UnPause(){
		ingame.UnPause ();
	}

	public void Pause(){
		ingame.Pause ();
	}
}
