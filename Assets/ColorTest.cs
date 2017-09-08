using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour {
	public enum CellColor {Red,Yellow,Blue,Orange,Green,Purple,RedOra,YelOra,BluOra,RedGre,YelGre,BluGre,RedPur,YelPur,BluPur};
	public CellColor cellColor;
	CellColor currentColor;
	public Color color;
	[HideInInspector]	
	public string[] idToColor;
	Material material;
	public CellColor addColor1;
	public CellColor addColor2;

	// Use this for initialization
	void Start () {
		currentColor = cellColor;
		material = GetComponent<MeshRenderer>().material;
		idToColor = new string[30];
		BuildIdToColorTable();
		//PrintColor(Color.blue,Color.yellow);
		material.color = GetColor(GetColorId(cellColor));
	}
	
	// Update is called once per frame
	void Update () {
		if(currentColor != cellColor){
			currentColor = cellColor;
			material.color = GetColor(GetColorId(cellColor));
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			material.color = GetColor(AddColors(GetColorId(addColor1),GetColorId(addColor2)));
		}
	}

	Color GetColor(int id){
		Color c;
		if(ColorUtility.TryParseHtmlString(idToColor[id], out c)){
			return c;
		}
		return Color.black;
	}

	int GetColorId(CellColor c){
		switch(c){
			case CellColor.Red:
			return 2;
			case CellColor.Yellow:
			return 3;
			case CellColor.Blue:
			return 4;
			case CellColor.Orange:
			return 5;
			case CellColor.Green:
			return 7;
			case CellColor.Purple:
			return 6;
			case CellColor.RedOra:
			return 10;
			case CellColor.YelOra:
			return 15;
			case CellColor.BluOra:
			return 20;
			case CellColor.RedGre:
			return 14;
			case CellColor.YelGre:
			return 21;
			case CellColor.BluGre:
			return 28;
			case CellColor.RedPur:
			return 12;
			case CellColor.YelPur:
			return 18;
			case CellColor.BluPur:
			return 24;
			default:
			return 0;
		}
	}

	void BuildIdToColorTable(){
		for(int i = 0;i<idToColor.Length;i++){
			idToColor[i] = "#00000000";
		}
		idToColor[2] = "#FF000000"; //red
		idToColor[3] = "#FBFF0000"; //yellow
		idToColor[4] = "#0000FF00"; //blue
		idToColor[5] = "#FF840000"; //orange
		idToColor[7] = "#00FF0000"; //green
		idToColor[6] = "#A700FF00"; //purple
		idToColor[10] = "#FF450000"; //red+orange
		idToColor[15] = "#FFAB0000"; //yellow+orange
		idToColor[20] = "#74004F00"; //blue+orange
		idToColor[14] = "#74270000"; //red+green
		idToColor[21] = "#D2FF0200"; //yellow+green
		idToColor[28] = "#02FFC400"; //blue+green
		idToColor[12] = "#FF00AC00"; //red+purple
		idToColor[18] = "#A793A500"; //yellow+purple
		idToColor[24] = "#7000F600"; //blue+purple
	}

	int AddColors(int c1, int c2){
		int r = 0;
		if(c1 == c2)
			return c1;
		else{
			if(c1 >= 10 || c2 >= 10)
				r = Mathf.Max(c1,c2);
			else if(c1 >= 5 || c2 >= 5)
				r = c1 * c2;
			else
				r = c1 + c2;
			return r;
		}
	}
}
