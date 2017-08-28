using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOrientation : MonoBehaviour {
	UILabel label;
	DeviceOrientation lastOrientation;

	// Use this for initialization
	void Start () {
		label = GetComponent<UILabel> ();
		//lastOrientation = Input.deviceOrientation;
		//label.text = lastOrientation.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		label.text = Input.acceleration.ToString ();
		/*DeviceOrientation currentOrientation = Input.deviceOrientation;
		if(currentOrientation != lastOrientation){
			lastOrientation = currentOrientation;
			label.text = lastOrientation.ToString ();
		}*/
	}
}
