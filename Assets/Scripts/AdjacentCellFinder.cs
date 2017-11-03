using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentCellFinder : MonoBehaviour {
	InGame ingame;
	public Cell parentCell;
	public Cell cell;

	// Use this for initialization
	void Awake () {
		if(parentCell == null)
			parentCell = GetComponentInParent<Cell>();
	}

	void OnTriggerStay(Collider c){
		if(c.GetComponent<Cell>() != null && c.GetComponent<Cell>() != cell){
			cell = c.GetComponent<Cell>();
			SetParentCell(name);
		}
		else if(c.tag != "Direction" && c.GetComponent<Cell>() == null)
			cell = null;

	}

	void SetParentCell(string n){
		switch(n){
			case "L":
				parentCell.adjacentCells[0] = cell;
				break;
			case "U":
				parentCell.adjacentCells[1] = cell;
				break;
			case "R":
				parentCell.adjacentCells[2] = cell;
				break;
			case "D":
				parentCell.adjacentCells[3] = cell;
				break;
		}
	}

}
