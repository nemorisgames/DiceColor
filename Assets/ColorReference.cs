using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorReference : MonoBehaviour {
	public enum CellColor {Red,Yellow,Blue,Orange,Green,Purple,RedOra,YelOra,BluOra,RedGre,YelGre,BluGre,RedPur,YelPur,BluPur,Wrong,None};
	public CellColor cellColor;
	CellColor currentColor;
	public Color color;
	[HideInInspector]	
	public string[] idToColor;
	CellColor [] idToEnum;
	Material material;
	public CellColor addColor1;
	public CellColor addColor2;

	// Use this for initialization
	void Awake () {
		currentColor = cellColor;
		//material = GetComponent<Renderer>().material;
		idToColor = new string[30];
		idToEnum = new CellColor[30];
		BuildIdToColorTable();
		//PrintColor(Color.blue,Color.yellow);
		//material.color = GetColor(GetColorId(cellColor));
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
	public Color GetColorByEnum(CellColor c){
		return GetColor(GetColorId(c));
	}

	Color GetColor(int id){
		Color c;
		if(ColorUtility.TryParseHtmlString(idToColor[id], out c)){
			return c;
		}
		else
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
			case CellColor.Wrong:
			return 29;
			case CellColor.None:
			return 0;
			default:
			return 0;
		}
	}

	void BuildIdToColorTable(){
		for(int i = 0;i<idToColor.Length;i++){
			idToColor[i] = "#00000000";
			idToEnum[i] = CellColor.Wrong;
		}
		idToColor[0] = "#FFFFFFFF"; //blanco
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

		idToEnum[0] = CellColor.None;
		idToEnum[2] = CellColor.Red;
		idToEnum[3] = CellColor.Yellow;
		idToEnum[4] = CellColor.Blue;
		idToEnum[5] = CellColor.Orange;
		idToEnum[7] = CellColor.Green;
		idToEnum[6] = CellColor.Purple;
		idToEnum[10] = CellColor.RedOra;
		idToEnum[15] = CellColor.YelOra;
		idToEnum[20] = CellColor.BluOra;
		idToEnum[14] = CellColor.RedGre;
		idToEnum[21] = CellColor.YelGre;
		idToEnum[28] = CellColor.BluGre;
		idToEnum[12] = CellColor.RedPur;
		idToEnum[18] = CellColor.YelPur;
		idToEnum[24] = CellColor.BluPur;
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

	int SubtractColors(int c1, int c2){
		int r = 0;
		if(c1 == c2)
			return c1;
		else{
			if(c1 >= 10 && c2 >= 10)
				r = Mathf.Min(c1,c2);
			else if((c1 >= 5 && c2 >= 5) || (c1 >= 10 || c2 >= 10))
				r = c1 / c2;
			else
				r = c1 - c2;
			return r;
		}
	}

	public CellColor GetSumColorByEnum(CellColor c1, CellColor c2){
		return GetCellColorById(AddColors(GetColorId(c1),GetColorId(c2)));
	}

	public CellColor GetSubstColorByEnum(CellColor c1, CellColor c2){
		return GetCellColorById(SubtractColors(GetColorId(c1),GetColorId(c2)));
	}

	public CellColor GetCellColorById(int id){
		if(id < idToEnum.Length && id >= 0)
			return idToEnum[id];
		else
			return CellColor.Wrong;
	}
}
