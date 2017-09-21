using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentCellFinder : MonoBehaviour {
	InGame ingame;
	public bool active = false;
	public Cell previousCell;
	public Cell cell;
	int previousID;
	int timesDied;

	// Use this for initialization
	void Start () {
		ingame = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<InGame>();
		timesDied = PlayerPrefs.GetInt ("timesDied");
		if (timesDied < 5){
			StartCoroutine (Delay (1f));
			StartCoroutine (DoubleCheck ());
		}
	}

	void OnTriggerEnter(Collider c){
		cell = c.GetComponent<Cell> ();
		if(!ingame.finished)
			EnableCell (c, true);
	}

	void OnTriggerExit(Collider c){
		EnableCell (c, false);
	}

	void EnableCell(Collider c, bool b){
		if (c.name.Substring (0, 4) == "Cell" && active) {
			previousID = cell.GetInstanceID ();
			if (cell.stateCell == Cell.StateCell.Normal && !cell.operation) {
				//SwitchMaterial (cell, b);
			}
			if (b) {
				if(previousCell != null && previousCell != cell)
					//SwitchMaterial (previousCell, !b);
				previousCell = cell;
			}
		}
	}

	void SwitchMaterial(Cell cell, bool b){
        if (cell == null) return;
		if (ingame.cellMaterials != null && ingame.cellTextMaterials != null && cell.stateCell == Cell.StateCell.Normal && !cell.operation) {
			cell.GetComponent<MeshRenderer> ().material = (b ? ingame.cellMaterials [1] : ingame.cellMaterials [0]);
			cell.transform.Find ("Text").GetComponent<MeshRenderer> ().material = (b ? ingame.cellTextMaterials [1] : ingame.cellTextMaterials [0]);
		}
	}

	IEnumerator Delay(float f){
		yield return new WaitForSeconds (f);
		active = true;
	}

	IEnumerator DoubleCheck(){
		yield return new WaitForSeconds (2f);
		if (previousCell == null) {
			active = true;
			SwitchMaterial (cell, true);
			previousCell = cell;
		}
	}

	public void EnableCell(bool b){
		SwitchMaterial (previousCell, b);
		//StartCoroutine(Delay (0.1f));
	}

	public int getId(){
		return previousID;
	}
}
