using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapInput : MonoBehaviour {
	string dir;
	Dice dice;
	InGame inGame;
	// Use this for initialization
	void Start () {
		dir = transform.name;
		dice = GameObject.Find ("Dice").GetComponent<Dice> ();
		inGame = Camera.main.GetComponent<InGame> ();
	}


	void OnMouseDown(){
		if (!dice.onMovement && !inGame.rotating && dice.enabled && Time.timeSinceLevelLoad > 2f && !inGame.pause) {
			if (transform.name == "U") {
				StartCoroutine (dice.turn (Dice.Direction.Up));
			} else if (transform.name == "D") {
				StartCoroutine (dice.turn (Dice.Direction.Down));
			} else if (transform.name == "L") {
				StartCoroutine (dice.turn (Dice.Direction.Left));
			} else if (transform.name == "R") {
				StartCoroutine (dice.turn (Dice.Direction.Right));
			}
		}
	}
}
