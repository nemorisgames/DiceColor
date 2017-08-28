using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Advertisements;
using UnityEngine.Analytics;

public class InGame_RC : MonoBehaviour {
/*	Dice dice;
	Transform cells;
	GameObject [,] cellArray;
	public TextMesh [] cellsText;
	ArrayList texts = new ArrayList();
	ArrayList path = new ArrayList();
	public bool rotating = false;
	public GameObject finishedSign;
	public GameObject TimesUpSign;
	public UILabel clockMinutes;
	public UILabel clockSeconds;
	public UILabel clockDecimals;
	public UILabel record;
	float recordSeconds;
	[HideInInspector]
	public float pauseTime = 0;
	float pauseAux = 0;
	public int secondsAvailable = 65;
	public UITexture tutorial;
	public Texture2D[] imgTutorial;
	AudioSource audio;
	public AudioClip audioBadMove;
	public AudioClip audioGoodMove;
	public AudioClip audioFinish;

	public GameObject cellNormal;
	public GameObject cellBegin;
	public GameObject cellEnd;

	public GameObject cellSum;
	public GameObject cellSubstraction;
	public GameObject cellMultiplication;
	public GameObject cellDivision;
	public GameObject cellCW;
	public GameObject cellCCW;
	public GameObject cellDeath;

	//[HideInInspector]
	public bool pause = false;

	int timesDied = 0;
	public UILabel hintLabel;
	int hintsAvailable = 0;

	public bool testing = false;

	public string zoneId;
	public TweenAlpha hintScreen;

	// Use this for initialization
	void Start () {
		hintsAvailable = PlayerPrefs.GetInt ("hints", 0);
		hintLabel.text = "" + hintsAvailable;
		timesDied = PlayerPrefs.GetInt ("timesDied", 0);
		dice = GameObject.FindGameObjectWithTag ("Dice").GetComponent<Dice> ();
		componerEscena ();

		cells = GameObject.Find ("Cells").transform;
		cellsText = cells.GetComponentsInChildren<TextMesh> ();
		foreach (TextMesh t in cellsText) {
			texts.Add(t.GetComponent<Transform>());
		}
		recordSeconds = PlayerPrefs.GetFloat ("record"+PlayerPrefs.GetString ("scene", "Scene1"), -1f);
		if (recordSeconds > 0) {
			int minutes = (int)((recordSeconds) / 60);
			int seconds = (int)((recordSeconds) % 60);
			int dec = (int)(((recordSeconds) % 60 * 10f) - ((int)((recordSeconds) % 60) * 10));
			record.text = "" + (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds + "." + dec;	
		}
		audio = GetComponent<AudioSource> ();
		print ("timesDied " + timesDied);
		if (timesDied >= 5)
			StartCoroutine(lightPath (2));
		//StartCoroutine (cellArray[1,2].GetComponent<Cell>().shine ());
		//StartCoroutine (lightPath (2));
	}

	public void showInterstitial ()
	{
		if(Advertisement.IsReady())
			Advertisement.Show ();
	}

	public void showVideo ()
	{
		if (!Advertisement.IsReady())
			return;
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;
		Advertisement.Show (zoneId, options);
	}

	private void HandleShowResult (ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("Video completed. User rewarded credits.");
			PlayerPrefs.SetInt ("hints", PlayerPrefs.GetInt ("hints", 0) + 2);
			hintLabel.text = "" + hintsAvailable;
			print ("hints " + PlayerPrefs.GetInt ("hints", 0));
			hintsAvailable += 2;
			closeHintScreen ();
			//hint ();
			break;
		case ShowResult.Skipped:
			Debug.LogWarning ("Video was skipped.");
			break;
		case ShowResult.Failed:
			Debug.LogError ("Video failed to show.");
			break;
		}
	}

	public void hint(){
		if (PlayerPrefs.GetInt ("hints", 0) <= 0) {
			Pause ();
			hintScreen.PlayForward ();
		} else {
			StartCoroutine (lightPath (2));
			hintsAvailable--;
			//if (hintsAvailable <= 0) {
			//	hintButton.SetActive (false);
			//}
			PlayerPrefs.SetInt ("hints", PlayerPrefs.GetInt ("hints", 0) - 1);
			hintLabel.text = "" + hintsAvailable;

			print ("hints " + PlayerPrefs.GetInt ("hints", 0));
		}
	}

	public void closeHintScreen(){
		hintScreen.PlayReverse ();
		UnPause ();
	}

	public void componerEscena(){
		string completo = "";
		switch (PlayerPrefs.GetString ("scene", "Scene1")) {
		case "Scene1":completo = GlobalVariables.Scene1;break;
		case "Scene2":completo = GlobalVariables.Scene2;break;
		case "Scene3":completo = GlobalVariables.Scene3;break;
		case "Scene4":completo = GlobalVariables.Scene4;break;
		case "Scene5":completo = GlobalVariables.Scene5;break;
		case "Scene6":completo = GlobalVariables.Scene6;break;
		case "Scene7":completo = GlobalVariables.Scene7;break;
		case "Scene8":completo = GlobalVariables.Scene8;break;
		case "Scene9":completo = GlobalVariables.Scene9;break;
		case "Scene10":completo = GlobalVariables.Scene10;break;
		case "Scene11":completo = GlobalVariables.Scene11;break;
		case "Scene12":completo = GlobalVariables.Scene12;break;
		case "Scene13":completo = GlobalVariables.Scene13;break;
		case "Scene14":completo = GlobalVariables.Scene14;break;
		case "Scene15":completo = GlobalVariables.Scene15;break;
		case "Scene16":completo = GlobalVariables.Scene16;break;
		case "Scene17":completo = GlobalVariables.Scene17;break;
		case "Scene18":completo = GlobalVariables.Scene18;break;
		case "Scene19":completo = GlobalVariables.Scene19;break;
		case "Scene20":completo = GlobalVariables.Scene20;break;
		}
		string[] aux = completo.Split(new char[1]{'$'});
		string[] info = aux[0].Split(new char[1]{'|'});
		string[] arreglo = aux[1].Split(new char[1]{'|'});
		Vector3 posIni = new Vector3 (int.Parse (info [2]), 0f, -int.Parse (info [3]));
		if (int.Parse (info [4]) > 0) { 
			tutorial.mainTexture = imgTutorial [int.Parse (info [4]) - 1];
			tutorial.transform.FindChild ("Sprite").GetComponent<UISprite> ().alpha = 1f;
			tutorial.transform.SendMessage ("PlayForward");
			tutorial.transform.FindChild ("Sprite").SendMessage ("PlayForward");
			Pause ();
		}
		string completoNumbers = "";
		switch (PlayerPrefs.GetString ("scene", "Scene1")) {
		case "Scene1":completoNumbers = GlobalVariables.Scene1Numbers;break;
		case "Scene2":completoNumbers = GlobalVariables.Scene2Numbers;break;
		case "Scene3":completoNumbers = GlobalVariables.Scene3Numbers;break;
		case "Scene4":completoNumbers = GlobalVariables.Scene4Numbers;break;
		case "Scene5":completoNumbers = GlobalVariables.Scene5Numbers;break;
		case "Scene6":completoNumbers = GlobalVariables.Scene6Numbers;break;
		case "Scene7":completoNumbers = GlobalVariables.Scene7Numbers;break;
		case "Scene8":completoNumbers = GlobalVariables.Scene8Numbers;break;
		case "Scene9":completoNumbers = GlobalVariables.Scene9Numbers;break;
		case "Scene10":completoNumbers = GlobalVariables.Scene10Numbers;break;
		case "Scene11":completoNumbers = GlobalVariables.Scene11Numbers;break;
		case "Scene12":completoNumbers = GlobalVariables.Scene12Numbers;break;
		case "Scene13":completoNumbers = GlobalVariables.Scene13Numbers;break;
		case "Scene14":completoNumbers = GlobalVariables.Scene14Numbers;break;
		case "Scene15":completoNumbers = GlobalVariables.Scene15Numbers;break;
		case "Scene16":completoNumbers = GlobalVariables.Scene16Numbers;break;
		case "Scene17":completoNumbers = GlobalVariables.Scene17Numbers;break;
		case "Scene18":completoNumbers = GlobalVariables.Scene18Numbers;break;
		case "Scene19":completoNumbers = GlobalVariables.Scene19Numbers;break;
		case "Scene20":completoNumbers = GlobalVariables.Scene20Numbers;break;
		}
		string completoPath = "";
		switch (PlayerPrefs.GetString ("scene", "Scene1")) {
		case "Scene1":completoPath = GlobalVariables.Scene1Path;break;
		case "Scene2":completoPath = GlobalVariables.Scene2Path;break;
		case "Scene3":completoPath = GlobalVariables.Scene3Path;break;
		case "Scene4":completoPath = GlobalVariables.Scene4Path;break;
		case "Scene5":completoPath = GlobalVariables.Scene5Path;break;
		case "Scene6":completoPath = GlobalVariables.Scene6Path;break;
		case "Scene7":completoPath = GlobalVariables.Scene7Path;break;
		case "Scene8":completoPath = GlobalVariables.Scene8Path;break;
		case "Scene9":completoPath = GlobalVariables.Scene9Path;break;
		case "Scene10":completoPath = GlobalVariables.Scene10Path;break;
		case "Scene11":completoPath = GlobalVariables.Scene11Path;break;
		case "Scene12":completoPath = GlobalVariables.Scene12Path;break;
		case "Scene13":completoPath = GlobalVariables.Scene13Path;break;
		case "Scene14":completoPath = GlobalVariables.Scene14Path;break;
		case "Scene15":completoPath = GlobalVariables.Scene15Path;break;
		case "Scene16":completoPath = GlobalVariables.Scene16Path;break;
		case "Scene17":completoPath = GlobalVariables.Scene17Path;break;
		case "Scene18":completoPath = GlobalVariables.Scene18Path;break;
		case "Scene19":completoPath = GlobalVariables.Scene19Path;break;
		case "Scene20":completoPath = GlobalVariables.Scene20Path;break;
		}
		string [] auxPath = completoPath.Split (new char[1]{ '|' });
		string[] auxCoord = new string[2];
		for (int i = 0; i < auxPath.Length; i++) {
			auxCoord = auxPath [i].Split (new char[1]{ ',' });
			Vector2 coord = new Vector2 (float.Parse (auxCoord [0]), float.Parse (auxCoord [1]));
			path.Add (coord);
		};

		string[] auxNumbers = completoNumbers.Split(new char[1]{'$'});
		string[] infoNumbers = auxNumbers[0].Split(new char[1]{'|'});
		string[] arregloNumbers = auxNumbers[1].Split(new char[1]{'|'});
		dice.transform.FindChild ("TextUp").GetComponent<TextMesh> ().text = "" + int.Parse (infoNumbers[0]);
		dice.transform.FindChild ("TextLeft").GetComponent<TextMesh> ().text = "" + int.Parse (infoNumbers[1]);
		dice.transform.FindChild ("TextForward").GetComponent<TextMesh> ().text = "" + int.Parse (infoNumbers[2]);
		int indice = 0;
		Transform rootCells = GameObject.Find ("Cells").transform;
		cellArray = new GameObject[int.Parse(info[0]),int.Parse(info[1])];
		for(int i = 0; i < int.Parse(info[0]); i++){
			for (int j = 0; j < int.Parse (info [1]); j++) {
				GameObject g = null;
				switch (int.Parse (arreglo [indice])) {
				case -2:
					g = (GameObject)Instantiate (cellEnd, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case -1:
					g = (GameObject)Instantiate (cellBegin, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case 1:
				case 2:
					g = (GameObject)Instantiate (cellNormal, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case 3:
					g = (GameObject)Instantiate (cellSum, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case 4:
					g = (GameObject)Instantiate (cellSubstraction, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case 5:
					g = (GameObject)Instantiate (cellMultiplication, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case 6:
					g = (GameObject)Instantiate (cellDivision, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case 7:
					g = (GameObject)Instantiate (cellCW, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case 8:
					g = (GameObject)Instantiate (cellCCW, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case 9:
					g = (GameObject)Instantiate (cellDeath, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				}
				if (g != null) {
					g.GetComponent<Cell> ().number = int.Parse (arregloNumbers [indice]);
					g.transform.parent = rootCells;
					cellArray [i,j] = g;
				}
				indice++;
			}
		}
	}

	public void Pause(){
		pauseAux = Time.timeSinceLevelLoad;
		pause = true;
	}

	public void UnPause(){
		pause = false;
		pauseTime += Time.timeSinceLevelLoad - pauseAux;
		pauseAux = 0;
	}

	public void calculateResult(int diceValueA, int diceValueB, int cellValue){
		print ("calculating");
		if (checkOperationResult (diceValueA, diceValueB) != cellValue) {
			badMove ();
		} else {
			audio.pitch = Random.Range (0.95f, 1.05f);
			audio.PlayOneShot(audioGoodMove);
			path.RemoveAt (0);
		}
	}

	public void badMove(){
		#if !UNITY_EDITOR
		Analytics.CustomEvent ("badMove", new Dictionary<string, object> {
		{ "scene", PlayerPrefs.GetString("scene", "Scene1") },
		{ "steps", dice.steps },
		{ "place", dice.gameObject.transform.position},
		{ "time", secondsAvailable - Time.timeSinceLevelLoad }
		});
		#endif
		dice.enabled = false;
		StartCoroutine (reloadScene ());
		audio.pitch = 1f;
		audio.PlayOneShot(audioBadMove);
		dice.GetComponent<Animator> ().SetTrigger ("BadMove");
	}

	IEnumerator reloadScene(){
		yield return new WaitForSeconds (1f);
		timesDied++;
		PlayerPrefs.SetInt ("timesDied", timesDied);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	//0: adyacente, 1: tres adyacentes, 2: todos
	public IEnumerator lightPath(int mode){
		if (!pause) {
			Pause ();
			mode = Mathf.Clamp (mode, 0, 2);
			switch (mode) {
			case 0:
				if (path.Count > 0)
					StartCoroutine (cellArray [(int)((Vector2)path [0]).x, (int)((Vector2)path [0]).y].GetComponent<Cell> ().shine (2));
				yield return new WaitForSeconds (1f);
				break;
			case 1:
				int aux = Mathf.Min (3, path.Count);
				for (int i = 0; i < aux; i++) {
					StartCoroutine (cellArray [(int)((Vector2)path [i]).x, (int)((Vector2)path [i]).y].GetComponent<Cell> ().shine (1));
					yield return new WaitForSeconds (1f/2);
				}
				break;
			case 2:
				foreach (Vector2 v in path) {
					StartCoroutine (cellArray [(int)v.x, (int)v.y].GetComponent<Cell> ().shine (1));
					yield return new WaitForSeconds (1f/2);
				}
				break;
			}
			UnPause ();
		}
	}

	public void finishGame(){
		print("Finished");
		Pause ();
		StartCoroutine (dropCells ());
		dice.enabled = false;
		//finishedSign.SetActive (true);
		//finishedSign.SendMessage ("PlayForward");
		dice.enabled = false;
		dice.transform.rotation = Quaternion.identity;
		dice.GetComponent<Animator> ().SetTrigger ("Finished");
		audio.pitch = 1f;
		audio.PlayOneShot(audioFinish);
		if(Time.timeSinceLevelLoad - pauseTime < PlayerPrefs.GetFloat ("record"+PlayerPrefs.GetString ("scene", "Scene1"), float.MaxValue))
			PlayerPrefs.SetFloat ("record"+PlayerPrefs.GetString ("scene", "Scene1"), Time.timeSinceLevelLoad - pauseTime);
		
		#if !UNITY_EDITOR
		Analytics.CustomEvent ("finish", new Dictionary<string, object> {
		{ "scene", PlayerPrefs.GetString("scene", "Scene1") },
			{ "steps", dice.steps },
			{ "time", secondsAvailable - Time.timeSinceLevelLoad }
		});
			#endif
		showInterstitial ();
	}

	public int checkOperationResult(int diceValueB, int diceValueA){
		int res = 0;
		print(dice.currentOperation);
		switch (dice.currentOperation) {
		case Dice.Operation.Sum:
			res = ((diceValueA + diceValueB));
			break;
		case Dice.Operation.Rest:
			res = ((diceValueA - diceValueB));
			break;
		case Dice.Operation.Mult:
			res = ((diceValueA * diceValueB));
			break;
		case Dice.Operation.Div:
			res = ((diceValueA / diceValueB));
			break;
		}
		return res;
	}

	public IEnumerator rotateCells(bool CW){
		rotating = true;
		yield return new WaitForSeconds (0.5f);
		int nSteps = 30;
		for (int i = 1; i <= nSteps; i++) {
			yield return new WaitForSeconds (0.01f);
			cells.RotateAround (dice.transform.position, Vector3.up, (CW ? 90f : -90f) / nSteps);
			foreach (Transform t in texts) {
				t.RotateAround(t.position, Vector3.up, (CW ? -90f : 90f)/ nSteps);
			}
		}
		rotating = false;
	}

	IEnumerator dropCells(){
		Cell[] cellsAux = GameObject.Find ("Cells").transform.GetComponentsInChildren<Cell> ();
		for (int i = 0; i < cellsAux.Length; i++) {
			if (cellsAux [i].stateCell != Cell.StateCell.Passed) {
				float rnd = Random.Range (0.01f, 0.08f);
				yield return new WaitForSeconds (rnd);
				Rigidbody rb = cellsAux[i].GetComponent<Rigidbody> ();
				rb.isKinematic = false;
				rb.useGravity = true;
				StartCoroutine (disableCell (cellsAux[i]));
				if (i == cellsAux.Length - 1) {
					yield return new WaitForSeconds (1.4f);
					finishedSign.SetActive (true);
					finishedSign.SendMessage ("PlayForward");
				}
			}
		}
	}

	IEnumerator disableCell(Cell c){
		yield return new WaitForSeconds (2f);
		c.gameObject.SetActive (false);
	}

	void timesUp(){
		clockMinutes.text = "00";
		clockSeconds.text = "00";
		clockDecimals.text = "00";
		TimesUpSign.SetActive (true);
		dice.enabled = false;
		StartCoroutine (reloadScene ());
		audio.pitch = 1f;
		audio.PlayOneShot(audioBadMove);
		dice.GetComponent<Animator> ().SetTrigger ("BadMove");
		#if !UNITY_EDITOR
		Analytics.CustomEvent ("timesUp", new Dictionary<string, object> {
		{ "scene", PlayerPrefs.GetString("scene", "Scene1") },
			{ "steps", dice.steps },
			{ "time", secondsAvailable - Time.timeSinceLevelLoad }
		});
		#endif
	}

	public void playAgain(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void exit(){
		SceneManager.LoadScene ("LevelSelection");
	}


	public void next(){
		string texto = PlayerPrefs.GetString ("scene", "Scene1");
		string num = texto.Split (new char[1]{ 'e' }) [2];
		#if !UNITY_EDITOR
		Analytics.CustomEvent ("enteringLevel" + num);
		#endif
		int level = (int.Parse (num) + 1);
		if (level > GlobalVariables.nLevels)
			exit ();
		else {
			PlayerPrefs.SetInt ("timesDied", 0);
			PlayerPrefs.SetString ("scene", "Scene" + level);
			SceneManager.LoadScene ("InGame");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene ("LevelSelection");
		if (finishedSign.activeSelf || TimesUpSign.activeSelf) {
			return;
		}
		if (!pause) {
			int minutes = (int)((Time.timeSinceLevelLoad - pauseTime) / 60);
			int seconds = (int)((Time.timeSinceLevelLoad - pauseTime) % 60);
			int dec = (int)(((Time.timeSinceLevelLoad - pauseTime) % 60 * 100f) - ((int)((Time.timeSinceLevelLoad - pauseTime) % 60) * 100));
			clockMinutes.text = (minutes < 10 ? "0" : "") + minutes;
			clockSeconds.text = (seconds < 10 ? "0" : "") + seconds;
			clockDecimals.text = (dec < 10 ? "0" : "") + dec;
		}

		//test
		if (testing) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				StartCoroutine (lightPath (1));
			}

			if (Input.GetKeyDown (KeyCode.E)) {
				StartCoroutine (lightPath (0));
			}

			if (Input.GetKeyDown (KeyCode.R)) {
				StartCoroutine (lightPath (2));
			}

			if (Input.GetKeyDown (KeyCode.P)) {
				PlayerPrefs.DeleteAll ();
			}
		}
	}*/
}
