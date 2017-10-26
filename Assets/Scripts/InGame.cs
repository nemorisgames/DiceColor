using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Analytics;
using UnityEngine.Advertisements;

using VoxelBusters.NativePlugins;
using System.Linq;

public class InGame : MonoBehaviour {
	Dice dice;
	Transform cells;
	GameObject [,] cellArray;
	public TextMesh [] cellsText;
	ArrayList texts = new ArrayList();
	ArrayList path = new ArrayList();
	public bool rotating = false;
	public GameObject finishedSign;
	public UILabel clockShow;
	public UILabel record;
	public UILabel levelNum;
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

	public AudioSource bgm_go;
	public static AudioSource bgm;

	//public TutorialVideo tutorialVideo;

	//[HideInInspector]
	public bool pause = false;

	int timesDied = 0;
	public GameObject hintScreen;
	public UILabel hintIndicator;
	int hintsAvailable = 3;

	//public TutorialVideo [] tutorialClips;

	public bool testing = false;
	float diceSize;
	public Transform adjacentCells;
	public Material[] cellMaterials;
	public Material[] cellTextMaterials;

	int tutorialIndex;
    public TweenAlpha hintMessage;
    int hintPressedNumber = 0;

	public ColorReference colorReference;
    
	public UILabel score;
	public UILabel multiplier;

	public NextColor nextColor;

	int cellIndex = 0;

	// Use this for initialization

	void Awake(){
		colorReference = GetComponent<ColorReference>();
	}
	void Start () {
        //print(GlobalVariables.getColor(GlobalVariables.CellColors.Green, GlobalVariables.CellColors.Blue));
		raiseCells = new List<Cell>();
		if (bgm == null) {
			bgm = bgm_go;
			DontDestroyOnLoad (bgm);
			bgm.Play ();
		}/* else {
			DestroyImmediate (bgm_go);
		}*/
		
        if (PlayerPrefs.GetInt("Mute") == 1)
            bgm.mute = true;
        else
            bgm.mute = false;
        string texto = PlayerPrefs.GetString("scene", "Scene1");
        string num = texto.Split(new char[1] { 'e' })[2];
        int level = (int.Parse(num));
        levelNum.text = "LEVEL " + level.ToString();

        timesDied = PlayerPrefs.GetInt("timesDied", 0);
        dice = GameObject.FindGameObjectWithTag("Dice").GetComponent<Dice>();
        componerEscena();

        cells = GameObject.Find("Cells").transform;
        cellsText = cells.GetComponentsInChildren<TextMesh>();
        foreach (TextMesh t in cellsText) {
            texts.Add(t.GetComponent<Transform>());
        }
        recordSeconds = PlayerPrefs.GetFloat("record" + PlayerPrefs.GetString("scene", "Scene1"), -1f);
        if (recordSeconds > 0) {
            int minutes = (int)((recordSeconds) / 60);
            int seconds = (int)((recordSeconds) % 60);
            int dec = (int)(((recordSeconds) % 60 * 10f) - ((int)((recordSeconds) % 60) * 10));
            record.text = "" + (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds + "." + dec;
        }
        audio = GetComponent<AudioSource>();
        print("timesDied " + timesDied);
        //if (timesDied >= 5)
        //    StartCoroutine(lightPath(2));
        //StartCoroutine (cellArray[1,2].GetComponent<Cell>().shine ());
        //StartCoroutine (lightPath (2));
        diceSize = dice.GetComponent<MeshRenderer>().bounds.size.y / 2;
        hintsAvailable = PlayerPrefs.GetInt("hints", 2);
        hintIndicator.text = "" + hintsAvailable;
		showTutorial = nguiCam.cullingMask;
		passedCells = new List<Cell>();
    }

    public void hintPressed()
    {
        if (hintPressedNumber <= 0)
        {
            hintMessage.PlayForward();
            hintPressedNumber++;
        }
        else
        {
            hint();
        }
    }

    private void OnGUI()
    {
        
    }

    public void hint(){
		if (!pause && path.Count > 0)
        {
            if (hintsAvailable <= 0) {
                showVideo();
                
                //hintScreen.SendMessage ("PlayForward");
				Pause ();
                
			} else {
				StartCoroutine (lightPath (2));
				hintsAvailable--;
				hintIndicator.text = "" + hintsAvailable;
				PlayerPrefs.SetInt ("hints", hintsAvailable);
			}
			#if !UNITY_EDITOR
			Analytics.CustomEvent ("hints");
			#endif
		}
	}

	public void showInterstitial()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	public void showVideo(){
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
		#if !UNITY_EDITOR
		Analytics.CustomEvent ("showVideo");
		#endif
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			hintsAvailable += 2;
			PlayerPrefs.SetInt ("hints", hintsAvailable);
			hintIndicator.text = "" + hintsAvailable;
			closeHintScreen ();
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}

	public void closeHintScreen(){
		hintScreen.SendMessage ("PlayReverse");
		UnPause ();
	}

	List <Cell> raiseCells;
	public Vector2 center;

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
			tutorialIndex = int.Parse (info [4]);
			//tutorialVideo.PlayClip (int.Parse (info [4]) - 1);
			//tutorial.mainTexture = imgTutorial [int.Parse (info [4]) - 1];
			//tutorial.transform.Find ("Sprite").GetComponent<UISprite> ().alpha = 1f;
			//tutorial.transform.SendMessage ("PlayForward");
			//tutorial.transform.Find ("Sprite").SendMessage ("PlayForward");
			//tutorialClips[(int.Parse (info [4]) - 1)].gameObject.SetActive(true);
			//tutorialVideo.gameObject.SetActive(true);
			//StartCoroutine(tutorialVideo.PlayClip(int.Parse (info [4]) - 1));
			//Pause ();
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
		//dice.transform.Find ("TextUp").GetComponent<TextMesh> ().text = "" + int.Parse (infoNumbers[0]);
		//dice.transform.Find ("TextLeft").GetComponent<TextMesh> ().text = "" + int.Parse (infoNumbers[1]);
		//dice.transform.Find ("TextForward").GetComponent<TextMesh> ().text = "" + int.Parse (infoNumbers[2]);
		int indice = 0;
		center = new Vector2((int)(int.Parse(info[0])/2 - 3), (int)(int.Parse(info[1])/2 - 3));
		Transform rootCells = GameObject.Find ("Cells").transform;
		cellArray = new GameObject[int.Parse(info[0]),int.Parse(info[1])];
		for(int i = 0; i < int.Parse(info[0]); i++){
			for (int j = 0; j < int.Parse (info [1]); j++) {
				GameObject g = null;
				switch (int.Parse (arreglo [indice])) {
				case -3:
				case -4:
					g = (GameObject)Instantiate (cellNormal, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y - 10f, g.transform.position.z);
					g.GetComponent<Cell>().raiseGroup = int.Parse (arreglo [indice]);
					raiseCells.Add(g.GetComponent<Cell>());
					break;
				case -2:
					g = (GameObject)Instantiate (cellEnd, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case -1:
					g = (GameObject)Instantiate (cellBegin, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					break;
				case 1:
				case 2:
					g = (GameObject)Instantiate (cellNormal, new Vector3 (j, -0.1f, -i) - posIni, Quaternion.identity);
					cellIndex++;
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
					//g.GetComponent<Cell> ().number = int.Parse (arregloNumbers [indice]);
					g.GetComponent<Cell>().cellColor = colorReference.GetCellColorById(int.Parse (arregloNumbers [indice]));
					g.GetComponent<Cell>().index = indice;
					g.transform.parent = rootCells;
					cellArray [i,j] = g;
				}
				indice++;
			}
		}
	}

	public void Pause(){
		if (!pause) {
			pauseAux = Time.timeSinceLevelLoad;
			pause = true;
		}
	}

	public void UnPause(){
		if (pause) {
			pause = false;
			pauseTime += Time.timeSinceLevelLoad - pauseAux;
			pauseAux = 0;
		}
	}

	public void calculateResult(int diceValueA, int diceValueB, int cellValue){
		print ("calculating");
		if (checkOperationResult (diceValueA, diceValueB) != cellValue) {
			badMove ();
		} else {
			audio.pitch = Random.Range (0.95f, 1.05f);
			audio.PlayOneShot(audioGoodMove);
			path.RemoveAt (0);
			Instantiate (dice.goodMove, new Vector3(dice.transform.position.x,dice.transform.position.y + diceSize, dice.transform.position.z), Quaternion.LookRotation(Vector3.up));
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
        print("badMove");
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
					yield return new WaitForSeconds (1f / 2);
				}
				break;
			case 2:
				foreach (Vector2 v in path) {
					StartCoroutine (cellArray [(int)v.x, (int)v.y].GetComponent<Cell> ().shine (1));
					yield return new WaitForSeconds (1f / 2);
				}
				foreach (Transform t in adjacentCells)
					//t.GetComponent<AdjacentCellFinder> ().active = true;
                StartCoroutine (cellArray [(int)((Vector2)path [0]).x, (int)((Vector2)path [0]).y].GetComponent<Cell> ().shine (2));
				yield return new WaitForSeconds (1f);
				break;
			}
			UnPause ();
			/*yield return new WaitForSeconds (0.03f);
			foreach (Transform t in adjacentCells)
				t.GetComponent<AdjacentCellFinder> ().EnableCell (true);*/
		}
	}

    public Dice.Direction getDirection(Vector3 currentPos, Vector2 endPos)
    {
        Vector2 pos = new Vector2(currentPos.x * 1, currentPos.z * 1);
        endPos = new Vector2(endPos.y, endPos.x);
        print(currentPos + ", (" + (pos.x) + ", " + (pos.y) + "), " + endPos);
        if (pos.x == (int)endPos.x)
        {
            if (pos.y < (int)endPos.y)
                return Dice.Direction.Down;
            else
                return Dice.Direction.Up;
        }
        else
        {
            if(pos.y == (int)endPos.y)
            {
                if (pos.x < (int)endPos.x)
                    return Dice.Direction.Left;
                else
                    return Dice.Direction.Right;
            }
        }
        return Dice.Direction.Down;
    }


    public Camera nguiCam;
	public LayerMask hideTutorial;
	LayerMask showTutorial;

	public void HideTutorial(){
		if (nguiCam.cullingMask != hideTutorial)
			nguiCam.cullingMask = hideTutorial;
		else
			nguiCam.cullingMask = showTutorial;
	}

	public bool finished = false;

	public void finishGame(){
        PlayerPrefs.SetInt("timesDied", 0);

        finished = true;
		print("Finished");
		HideTutorial();
		Pause ();
		foreach (Transform t in adjacentCells)
			//t.GetComponent<AdjacentCellFinder> ().EnableCell (false);
		//for (int i = 0; i < tutorialClips.Length; i++)

		StartCoroutine (dropCells ());
		dice.enabled = false;
		finishedSign.SetActive (true);
		finishedSign.SendMessage ("PlayForward");
		dice.enabled = false;
		dice.transform.rotation = Quaternion.identity;
		dice.GetComponent<Animator> ().SetTrigger ("Finished");
		//tutorialVideo.ToggleOff ();
		audio.pitch = 1f;
		audio.PlayOneShot(audioFinish);
        if (Time.timeSinceLevelLoad - pauseTime < PlayerPrefs.GetFloat("record" + PlayerPrefs.GetString("scene", "Scene1"), float.MaxValue))
        {
            PlayerPrefs.SetFloat("record" + PlayerPrefs.GetString("scene", "Scene1"), Time.timeSinceLevelLoad - pauseTime);
            if (NPBinding.GameServices.LocalUser.IsAuthenticated)
            {
                NPBinding.GameServices.ReportScoreWithGlobalID(PlayerPrefs.GetString("scene", "Scene1"), (int)((Time.timeSinceLevelLoad - pauseTime) * 100), (bool _success, string _error) => {

                    if (_success)
                    {
                        Debug.Log(string.Format("Request to report score to leaderboard with GID= {0} finished successfully.", PlayerPrefs.GetString("scene", "Scene1")));
                        Debug.Log(string.Format("New score= {0}.", Time.timeSinceLevelLoad - pauseTime));
                    }
                    else
                    {
                        Debug.Log(string.Format("Request to report score to leaderboard with GID= {0} failed.", PlayerPrefs.GetString("scene", "Scene1")));
                        Debug.Log(string.Format("Error= {0}.", _error.ToString()));
                    }
                });
            }
        }
		#if !UNITY_EDITOR
		Analytics.CustomEvent ("finish", new Dictionary<string, object> {
		{ "scene", PlayerPrefs.GetString("scene", "Scene1") },
			{ "steps", dice.steps },
			{ "time", secondsAvailable - Time.timeSinceLevelLoad }
		});
		#endif
	}

    public void checkLeaderboard()
    {
        NPBinding.GameServices.ShowLeaderboardUIWithGlobalID(PlayerPrefs.GetString("scene", "Scene1"), eLeaderboardTimeScope.ALL_TIME, leaderboardCallback());
    }
    GameServices.GameServiceViewClosed leaderboardCallback()
    {
        return null;
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
			//if (res == 0)
			//	res = -1;
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
                    showInterstitial();
				}
			}
		}
	}

	public IEnumerator dropCells(List<Cell> cells){
		//obtener "altura" bloque de celdas pasadas
		int height = 0;
		cells = cells.OrderBy(o=>o.transform.position.x).ToList();
		List <float> aux = new List<float>();
		foreach(Cell c in cells){
			//Debug.Log(c.index);
			if(!aux.Contains(c.transform.position.z)){
				aux.Add(c.transform.position.z);
			}
			else
				continue;
		}
		height = aux.Count;
		//Obtener celda mas a la izquierda para cada altura => filas
		List <Cell> cellAux = new List<Cell>();
		for(int i=0;i<height;i++){
			foreach(Cell c in cells){
				if(c.transform.position.z == aux.ElementAt(i)){
					cellAux.Add(c);
					break;
				}
			}	
		}
		//Check si el numero de celdas obtenido es correcto
		Debug.Log(height == cellAux.Count);
		
		//por cada fila
		foreach(Cell c in cellAux){
			float rnd = Random.Range (0.01f, 0.08f);
			yield return new WaitForSeconds (rnd);
			
			List<Cell> row = new List<Cell>();
			MoveCellsAtRight(row,c,0,0);
		}

		//Droppear celdas grises
		foreach(Cell c in cells){
			if(c.stateCell == Cell.StateCell.Passed){
				Rigidbody rb = c.GetComponent<Rigidbody> ();
				rb.isKinematic = false;
				rb.useGravity = true;
				StartCoroutine(disableCell(c));
			}
		}

		passedCells.Clear();
	}

	void MoveCellsAtRight(List<Cell> row, Cell c, int dist, int replace){
		dist++;
		//si la celda está pasada, marcar un reemplazo
		if(c.stateCell == Cell.StateCell.Passed){
			replace++;
		}

		if(c.stateCell == Cell.StateCell.Normal){
			//Debug.Log(c.index+" moved: "+dist);
			StartCoroutine(moveCell(c.transform,replace));
		}

		row.Add(c);

		//si la siguiente celda no es nula
		if(c.adjacentCells[2] != null){
			MoveCellsAtRight(row,c.adjacentCells[2],dist,replace);
		}
		else{
			//Debug.Log("Replaced cells: "+replace);
			for(int i=1;i<=replace;i++){
				GameObject aux = (GameObject)Instantiate(cellNormal, new Vector3(c.transform.position.x + 0.5f + i, c.transform.position.y, c.transform.position.z) ,Quaternion.identity,c.transform.parent);
				Cell cc = aux.GetComponent<Cell>();
				cc.cellColor = colorReference.GetCellColorById(colorReference.randomColor());
				cc.Recolor(cc.cellColor);
				cellIndex++;
				cc.index = cellIndex;
				StartCoroutine(moveCell(cc.transform,replace + 0.5f + i - i));
			}
			return;
		}
	}

	IEnumerator moveCell(Transform cell, float distance){
		cell.GetComponent<Cell>().EnableCell(false);
		Vector3 pos = cell.position;
		float moveDist = 0.04f;
		Vector3 target = new Vector3(pos.x - distance, pos.y, pos.z);
		while(target.x < pos.x){
			pos -= new Vector3(moveDist,0f,0f);
			cell.position = pos;
			yield return new WaitForSeconds(0.0001f);
		}
		cell.position = target;
		cell.position = new Vector3(Mathf.Round(cell.position.x),cell.position.y, Mathf.Round(cell.position.z));
		cell.GetComponent<Cell>().EnableCell(true);
	}

	IEnumerator disableCell(Cell c){
		yield return new WaitForSeconds (2f);
		c.gameObject.SetActive (false);
	}

	void timesUp(){
		clockShow.text = "00";
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
		string texto = PlayerPrefs.GetString ("scene", "Scene1");
		string num = texto.Split (new char[1]{ 'e' }) [2];
		int level = (int.Parse (num) + 1);
		if(level < GlobalVariables.nLevels)
			PlayerPrefs.SetInt ("unlockedScene" + level, 1);
		Destroy (bgm.gameObject);
		SceneManager.LoadScene ("LevelSelection");
	}

    public void exitGame()
    {
        Application.Quit();
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
			PlayerPrefs.SetInt ("unlockedScene" + level, 1);
			PlayerPrefs.SetString ("scene", "Scene" + level);
			SceneManager.LoadScene ("InGame");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Destroy (bgm.gameObject);
			SceneManager.LoadScene ("LevelSelection");
		}
		if (finishedSign.activeSelf) {
			return;
		}
		/*if (secondsAvailable - Time.timeSinceLevelLoad <= 0) {
			timesUp ();
		}
		else {
			int minutes = (int)((secondsAvailable - Time.timeSinceLevelLoad) / 60);
			int seconds = (int)((secondsAvailable - Time.timeSinceLevelLoad) % 60);
			int dec = (int)(((secondsAvailable - Time.timeSinceLevelLoad) % 60 * 10f) - ((int)((secondsAvailable - Time.timeSinceLevelLoad) % 60) * 10));
			clock.text = (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds + "." + dec;
		}*/
		if (!pause) {
			int minutes = (int)((Time.timeSinceLevelLoad - pauseTime) / 60);
			int seconds = (int)((Time.timeSinceLevelLoad - pauseTime) % 60);
			int dec = (int)(((Time.timeSinceLevelLoad - pauseTime) % 60 * 10f) - ((int)((Time.timeSinceLevelLoad - pauseTime) % 60) * 10));
			clockShow.text = (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds + "." + dec;
		}


		if(Input.GetKeyDown(KeyCode.V)){
			StartCoroutine(raiseCellGroup(-3));
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
		if (rotating || pause || dice.onMovement) {
			//if (rotating)
				//foreach (Transform t in adjacentCells)
					//t.GetComponent<AdjacentCellFinder> ().EnableCell (false);
			//adjacentCells.gameObject.SetActive (false);
		}
		//else if (!adjacentCells.gameObject.activeSelf && !finished)
			//adjacentCells.gameObject.SetActive (true);
				

		//adjacentCells.position = dice.transform.position;
	}

	IEnumerator raiseCellGroup(int i){
		foreach(Cell c in raiseCells){
			if(c.raiseGroup == i){
				StartCoroutine(raiseCell(c));
				yield return new WaitForSeconds(0.2f);
			}
		}
	}

	IEnumerator raiseCell(Cell c){
		while(c.transform.position.y <= -0.3){
			c.transform.position = new Vector3(c.transform.position.x, c.transform.position.y + 0.2f, c.transform.position.z);
			yield return new WaitForSeconds(0.01f);
		}
	}

	int cellRaiseIndex = -3;
	public void NextRaiseGroup(){
		StartCoroutine(raiseCellGroup(cellRaiseIndex));
		cellRaiseIndex--;
	}

	public void MoveDiceTo(Vector3 pos, Cell c){
		if(selectCell){
			//menos de 3 adyacentes o celda gris -> no baja el dado
			if(dice.getAdjacentCellCount(c) < 3 || c.stateCell == Cell.StateCell.Passed){
				return;
			}
			//baja el dado
			else{
				dice.calculated = false;
				rotateDice(pos);
				//StartCoroutine(dice.moveToward(c.cellColor,new Vector3(pos.x,0.5f,pos.z)));
				dice.transform.position = new Vector3(pos.x,0.5f,pos.z);
				dice.SetDiceColor(c.cellColor,false);
				dice.onMovement = false;
				selectCell = false;
				dice.GetComponent<Renderer>().enabled = true;
			}
		}
	}

	public bool selectCell = false;
	public List <Cell> passedCells;

	void rotateDice(Vector3 pos){
		int difX = (int)(pos.x - dice.transform.position.x);
		int difZ = (int)(pos.z - dice.transform.position.z);
		for(int i = 0;i<Mathf.Abs(difX);i++){
			dice.transform.RotateAround (dice.transform.position, Vector3.forward, 90f*Mathf.Sign(difX));
		}
		for(int i = 0;i<Mathf.Abs(difZ);i++){
			dice.transform.RotateAround (dice.transform.position, Vector3.right, 90f*Mathf.Sign(difZ));
		}
		
	}
}
