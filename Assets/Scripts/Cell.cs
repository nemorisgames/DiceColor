using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
	TextMesh text;
	InGame inGame;
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
	public GameObject adjacentCellsGO;
	AdjacentCellFinder [] adjacentCellFinders;
	public Cell [] adjacentCells;
	public bool active = false;
	void Awake () {
		inGame = Camera.main.GetComponent<InGame>();
		colorReference = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ColorReference>();
		text = transform.Find ("Text").GetComponent<TextMesh> ();
		//text.text = "" + number;
		
		adjacentCellFinders = adjacentCellsGO.GetComponentsInChildren<AdjacentCellFinder>();
		adjacentCells = new Cell[4];
		//GetAdjacentCells();
	}

	void Start(){
		changeState (stateCell);
		defaultColor = GetComponent<Renderer> ().material.GetColor ("_EmissionColor");
		Recolor(cellColor);
		EnableCell(true);
	}

	public void Recolor(ColorReference.CellColor color){
		GetComponent<Renderer>().material.SetColor("_EmissionColor",colorReference.GetColorByEnum(color));
		//Debug.Log(color);
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

	public void GetAdjacentCells(){
		for(int i=0;i<adjacentCells.Length;i++){
			if(adjacentCellFinders[i].cell != null)
				adjacentCells[i] = adjacentCellFinders[i].cell;
			else
				adjacentCells[i] = null;
		}
	}

	IEnumerator delayGetAdjacent(){
		yield return new WaitForSeconds(0.1f);
		GetAdjacentCells();
	}

	public void GoToCell(){
		inGame.MoveDiceTo(transform.position, GetComponent<Cell>());
	}

	void OnMouseDown()
	{
		if(active)
			GoToCell();
	}

	public void EnableCell(bool b){
		active = b;
	}
}
