using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellClick : MonoBehaviour {
	Cell cell;
	// Use this for initialization
	void Awake () {
		cell = GetComponentInParent<Cell>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		Debug.Log("click");
		cell.GoToCell();
	}
}
