using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialVideo : MonoBehaviour {
	VideoPlayer vp;
	Animator anim;
	DeviceOrientation lastOrientation;
	//public VideoClip [] clips; //0 = suma, 1 = resta, 2 = multi, 3 = div

	// Use this for initialization
	void Start () {
		vp = GetComponent<VideoPlayer> ();
		anim = GetComponentInChildren<Animator> ();

		#if !UNITY_EDITOR
		lastOrientation = DeviceOrientation.Unknown;
		#else
		lastOrientation = DeviceOrientation.LandscapeLeft;
		anim.SetTrigger("Landscape");
		#endif

		vp.skipOnDrop = false;
		vp.Prepare ();
		//Debug.Log (vp.frameRate);
	}

	void Update(){
		DeviceOrientation currentOrientation = Input.deviceOrientation;

		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.M))
			currentOrientation = DeviceOrientation.LandscapeLeft;
		if(Input.GetKeyDown(KeyCode.N))
			currentOrientation = DeviceOrientation.Portrait;
		#endif

		if (currentOrientation != lastOrientation) {
			lastOrientation = currentOrientation;
			switch (lastOrientation) {
			case DeviceOrientation.Unknown:
				break;
			case DeviceOrientation.FaceUp:
			case DeviceOrientation.FaceDown:
				if (Screen.width > Screen.height && !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
					anim.SetTrigger ("Landscape");
				else if(Screen.height > Screen.width && !anim.GetCurrentAnimatorStateInfo(0).IsName("IdlePortrait"))
					anim.SetTrigger ("Portrait");
				break;
			case DeviceOrientation.PortraitUpsideDown:
			case DeviceOrientation.Portrait:
				if(!anim.GetCurrentAnimatorStateInfo(0).IsName("IdlePortrait"))
					anim.SetTrigger ("Portrait");
				break;
			case DeviceOrientation.LandscapeLeft:
			case DeviceOrientation.LandscapeRight:
				if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
					anim.SetTrigger ("Landscape");
				break;
			}
			/*if (lastOrientation == DeviceOrientation.Portrait) {
				anim.SetTrigger ("Portrait");
			} else if(lastOrientation == DeviceOrientation.LandscapeLeft || lastOrientation == DeviceOrientation.LandscapeRight){
				anim.SetTrigger ("Landscape");
			}*/
		}
	}

	/*public IEnumerator PlayClip(int i){
		Debug.Log (i);
		//vp.Stop ();
		vp.clip = clips [i];
		vp.skipOnDrop = false;
		vp.Prepare ();
		WaitForSeconds waitTime = new WaitForSeconds (2f);
		while (!vp.isPrepared) {
			yield return waitTime;
			break;
		}
		vp.Play ();
		anim.SetTrigger ("Start");
	}*/

	public void ToggleOff(){
		anim.SetTrigger ("FadeOut");
	}
}
