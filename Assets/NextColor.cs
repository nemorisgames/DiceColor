using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NextColor : MonoBehaviour {

	public GameObject colorPrefab;
	public float distance = 64f;
	List <Transform> colors;
	ColorReference.CellColor [] colorRef;
	InGame inGame;
	Dice dice;

	// Use this for initialization
	void Start () {
		colors = new List<Transform>();
		inGame = Camera.main.GetComponent<InGame>();
		dice = GameObject.FindGameObjectWithTag("Dice").GetComponent<Dice>();
		colorRef = new ColorReference.CellColor[3];
		for(int i=0;i<3;i++){
			ColorReference.CellColor rnd = inGame.colorReference.GetRandomNextColor(ColorReference.CellColor.None);
			colorRef[i] = rnd;
			InstanceColor(rnd,(transform.position.y - distance * i),false);
		}
		dice.nextColor = colorRef[0];
	}

	void InstanceColor(ColorReference.CellColor color, float height, bool b){
		float xPos = 0;
		if(b)
			xPos = 0.5f;
		GameObject aux = (GameObject)Instantiate(colorPrefab,new Vector3(transform.position.x + xPos,height,transform.position.z),Quaternion.identity,this.transform);
		Color col = inGame.colorReference.GetColorByEnum(color);
		col.a = 1;
		aux.GetComponent<Renderer>().material.SetColor("_Color",col);
		aux.GetComponent<Renderer>().material.SetColor("_emissionColor",col);
		colors.Add(aux.GetComponent<Transform>());
		if(b){
			StartCoroutine(moveColorX(aux.transform,xPos));
		}
	}

	public ColorReference.CellColor Next(){
		Vector3 aux = colors.Last().position;
		Destroy(colors.First().gameObject);
		colors.Remove(colors.First());
		foreach(Transform t in colors){
			StartCoroutine(moveColorY(t,distance));
		}
		ColorReference.CellColor rnd = inGame.colorReference.GetRandomNextColor(inGame.dice.diceColor);
		colorRef[0] = colorRef[1];
		colorRef[1] = colorRef[2];
		colorRef[2] = rnd;
		InstanceColor(rnd,aux.y,true);
		return colorRef[0];
	}

	IEnumerator moveColorY(Transform t, float dist){
		Vector3 pos = t.position;
		Vector3 target = new Vector3(pos.x, pos.y + dist, pos.z);
		float moveDist = distance/10f;
		while(pos.y < target.y){
			pos += new Vector3(0f,Time.deltaTime,0f);
			t.position = pos;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		t.position = target;
	}

	IEnumerator moveColorX(Transform t, float dist){
		Vector3 pos = t.position;
		Vector3 target = new Vector3(pos.x - dist, pos.y, pos.z);
		float moveDist = distance/10f;
		while(pos.x > target.x){
			pos -= new Vector3(moveDist,0f,0f);
			t.position = pos;
			yield return new WaitForSeconds(0.0001f);
		}
		t.position = target;
	}
}
