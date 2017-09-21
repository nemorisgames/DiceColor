using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
	TextMesh text;
	public enum StateCell {Normal, Passed, EndCell};
	public StateCell stateCell = StateCell.Normal;

	public ColorReference.CellColor cellColor;

	public int index = 3;
	Color32 defaultColor;
	public bool operation = false;
	ColorReference colorReference;
	// Use this for initialization
	public bool operated = false;
	public int raiseGroup = 0;
	void Start () {
		colorReference = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ColorReference>();
		text = transform.Find ("Text").GetComponent<TextMesh> ();
		//text.text = "" + number;
		changeState (stateCell);
		defaultColor = GetComponent<Renderer> ().material.GetColor ("_EmissionColor");
		GetComponent<Renderer>().material.SetColor("_EmissionColor",colorReference.GetColorByEnum(cellColor));
	}

	public void changeState(StateCell s){
		switch (s) {
			case StateCell.Passed: 
			//text.text = "-";
			//GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<Renderer>().material.SetColor("_EmissionColor",Color.gray);
			break;
			case StateCell.Normal:
			GetComponent<Renderer>().material.SetColor("_EmissionColor",colorReference.GetColorByEnum(cellColor));
			break;
		}
		stateCell = s;
	}

	public IEnumerator shine(int num){
		Material m = GetComponent<Renderer> ().material;
		Color32 colorDefault = m.GetColor ("_EmissionColor");
		for (int j = 0; j < num; j++) {
			for (int i = 0; i < 15; i++) {
				yield return new WaitForSeconds (0.01f);
				m.SetColor ("_EmissionColor", Color.yellow * i * 0.1f);
			}
			for (int i = 15; i > 0; i--) {
				yield return new WaitForSeconds (0.01f);
				m.SetColor ("_EmissionColor", Color.yellow * i * 0.1f);
			}
		}
		m.SetColor ("_EmissionColor", colorDefault);
	}

	public void unshine(){
		GetComponent<Renderer> ().material.SetColor ("_EmissionColor", defaultColor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
