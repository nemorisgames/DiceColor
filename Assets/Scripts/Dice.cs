using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Dice : MonoBehaviour {
	[HideInInspector]
	public bool onMovement = false;
	[HideInInspector]
	public bool calculated = false;
	public enum Operation {Sum, Rest, Mult, Div};
	public Operation currentOperation = Operation.Sum;
	public enum Direction {Up, Down, Left, Right};
	Direction lastDirection;
	public Vector3 currentPos;
	ArrayList numbers = new ArrayList();
	ArrayList currentNumbers = new ArrayList();
	Operation nextOperation;
	InGame inGame;
	AudioSource audio;
	public AudioClip audioRotation;
	public AudioClip audioCubeChange;
	Transform plane;
	public int steps = 0;
	public Material backgroundMaterial;
	public Texture backgroundSum;
	public Texture backgroundSubstraction;
	public Texture backgroundMultiplication;
	public Texture backgroundDivision;
	float timeLastMove;
	float hintTime = 10f;
	LineRenderer line;
	public Material[] materialsLine;
	public UITexture backgroundTexture;
	public ParticleSystem goodMove;
    bool dropped = false;
    // Use this for initialization
    bool swipe;

	public ColorReference.CellColor diceColor;
	public ColorReference.CellColor [] targetColor;
	public ColorReference.CellColor nextColor;

	int targetIndex;

	List<Direction> directions;

	GameObject adjacentCellsGO;
	AdjacentCellFinder [] adjacentCells;

	bool firstMove = true;
	int score = 0;
	float multiplier = 1;
	void Start () {
		plane = GameObject.Find ("Plane").GetComponent<Transform> ();
		line = GetComponent<LineRenderer> ();
		currentPos = transform.position;
		/*numbers.Add(transform.Find("TextUp").GetComponent<TextMesh>());
		numbers.Add(transform.Find("TextDown").GetComponent<TextMesh>());
		numbers.Add(transform.Find("TextLeft").GetComponent<TextMesh>());
		numbers.Add(transform.Find("TextRight").GetComponent<TextMesh>());
		numbers.Add(transform.Find("TextForward").GetComponent<TextMesh>());
		numbers.Add(transform.Find("TextBackward").GetComponent<TextMesh>());*/

		//currentNumbers = numbers;

		diceColor = ColorReference.CellColor.None;

		directions = new List<Direction>();
		cells = new List<Cell>();

		inGame = Camera.main.GetComponent<InGame> ();
		audio = GetComponent<AudioSource> ();

		nextOperation = currentOperation;

		Camera.main.backgroundColor = new Color32 (253, 130, 138, 0);
		backgroundMaterial.mainTexture = backgroundSum;

		StartCoroutine(applyRootMotion ());

		timeLastMove = Time.timeSinceLevelLoad;
		if (PlayerPrefs.GetInt ("Control",0) == 0) {
			ToggleSwipe (true);
		} else {
			ToggleSwipe (false);
		}
		
		targetIndex = 0;
		onMovement = true;

		//UpdateNextColor();
		
		//adjacentCells = adjacentCellsGO.GetComponentsInChildren<AdjacentCellFinder>();
	}

	void UpdateNextColor(){
		//nextColor = inGame.colorReference.GetRandomColor();
		nextColor = inGame.nextColor.Next();
		//inGame.targetColor.text = "NEXT COLOR: "+nextColor;
		//inGame.targetColor.color = inGame.colorReference.GetColorByEnum(nextColor);
		//inGame.targetColor.alpha = 1;
		//inGame.targetColor.color.a = 1;
	}

	void UpdateNextColor(ColorReference.CellColor color){
		//nextColor = color;
		nextColor = inGame.nextColor.Next();
		//inGame.targetColor.text = "NEXT COLOR: "+nextColor;
		//inGame.targetColor.color = inGame.colorReference.GetColorByEnum(nextColor);
		//inGame.targetColor.alpha = 1;
	}

	IEnumerator applyRootMotion(){
		yield return new WaitForSeconds (1.6f);
		transform.rotation = Quaternion.identity;
		GetComponent<Animator> ().applyRootMotion = true;
		onFloor = true;
		onMovement = false;
	}

	public IEnumerator turn(Direction d){
		onMovement = true;
		calculated = false;
		int nStemps = 10;
		currentPos = transform.position;
		//define el numero en la cara escondida
		switch(d){
		case Direction.Up:
			
			break;
		case Direction.Down:
			RaycastHit r;
			if(Physics.Raycast(transform.position - Vector3.forward + Vector3.up, new Vector3(0f, -1f, 0f), out r, 5f,LayerMask.GetMask(new string[1]{"Cell"}))){
				if (r.collider.GetComponent<Cell> ().stateCell == Cell.StateCell.Normal) {
					//print (r.collider.name);
					//((TextMesh)currentNumbers [5]).text = "" + inGame.checkOperationResult (int.Parse (((TextMesh)currentNumbers [4]).text), int.Parse (((TextMesh)currentNumbers [0]).text));
				}
			}
			break;
		case Direction.Left:
			if (Physics.Raycast (transform.position - Vector3.right + Vector3.up, new Vector3 (0f, -1f, 0f), out r, 5f,LayerMask.GetMask(new string[1]{"Cell"}))) {
				if (r.collider.GetComponent<Cell> ().stateCell == Cell.StateCell.Normal) {
					//print (r.collider.name);
					//((TextMesh)currentNumbers [3]).text = "" + inGame.checkOperationResult (int.Parse (((TextMesh)currentNumbers [2]).text), int.Parse (((TextMesh)currentNumbers [0]).text));
				}
			}
			break;
		case Direction.Right:
			
			break;
		}
		//gira en dado
		for (int i = 1; i <= nStemps; i++) {
			yield return new WaitForSeconds (0.01f);
			switch(d){
			case Direction.Up:
				transform.RotateAround (currentPos + new Vector3 (0f, -0.5f, 0.5f), Vector3.right, 90f / nStemps);
				if(plane != null)
					plane.position = new Vector3 (plane.position.x, plane.position.y, plane.position.z + 0.1f);
				break;
			case Direction.Down:
				transform.RotateAround (currentPos + new Vector3 (0f, -0.5f, -0.5f), Vector3.right, -90f / nStemps);
				if(plane != null)
				plane.position = new Vector3 (plane.position.x, plane.position.y, plane.position.z - 0.1f);
				break;
			case Direction.Left:
				transform.RotateAround (currentPos + new Vector3 (-0.5f, -0.5f, 0f), Vector3.forward, 90f / nStemps);
				if(plane != null)
				plane.position = new Vector3 (plane.position.x - 0.1f, plane.position.y, plane.position.z);
				break;
			case Direction.Right:
				transform.RotateAround (currentPos + new Vector3 (0.5f, -0.5f, 0f), Vector3.forward, -90f / nStemps);
				if(plane != null)
				plane.position = new Vector3 (plane.position.x + 0.1f, plane.position.y, plane.position.z);
				break;
			}
		}

		//ordena las caras y las almacena
		/*switch(d){
		case Direction.Up:
			TextMesh t = ((TextMesh)currentNumbers [5]);
			currentNumbers [5] = currentNumbers [0];
			currentNumbers [0] = currentNumbers [4];
			currentNumbers [4] = currentNumbers [1];
			currentNumbers [1] = t;
			break;
		case Direction.Down:
			t = ((TextMesh)currentNumbers [1]);
			currentNumbers [1] = currentNumbers [4];
			currentNumbers [4] = currentNumbers [0];
			currentNumbers [0] = currentNumbers [5];
			currentNumbers [5] = t;
			break;
		case Direction.Left:
			t = ((TextMesh)currentNumbers [1]);
			currentNumbers [1] = currentNumbers [2];
			currentNumbers [2] = currentNumbers [0];
			currentNumbers [0] = currentNumbers [3];
			currentNumbers [3] = t;
			break;
		case Direction.Right:
			t = ((TextMesh)currentNumbers [3]);
			currentNumbers [3] = currentNumbers [0];
			currentNumbers [0] = currentNumbers [2];
			currentNumbers [2] = currentNumbers [1];
			currentNumbers [1] = t;
			break;
		}*/
		//gira las caras
		//Transform pos;
		/*switch(d){
		case Direction.Up:
			pos = ((TextMesh)currentNumbers [1]).transform;
			((TextMesh)currentNumbers [1]).transform.RotateAround (pos.position, pos.forward, -90);
			pos = ((TextMesh)currentNumbers [2]).transform;
			((TextMesh)currentNumbers [2]).transform.RotateAround (pos.position, pos.forward, -90);
			pos = ((TextMesh)currentNumbers [3]).transform;
			((TextMesh)currentNumbers [3]).transform.RotateAround (pos.position, pos.forward, 90);
			pos = ((TextMesh)currentNumbers [4]).transform;
			((TextMesh)currentNumbers [4]).transform.RotateAround (pos.position, pos.forward, 90);
			break;
		case Direction.Down:
			pos = ((TextMesh)currentNumbers [1]).transform;
			((TextMesh)currentNumbers [1]).transform.RotateAround (pos.position, pos.forward, -90);
			pos = ((TextMesh)currentNumbers [2]).transform;
			((TextMesh)currentNumbers [2]).transform.RotateAround (pos.position, pos.forward, 90);
			pos = ((TextMesh)currentNumbers [3]).transform;
			((TextMesh)currentNumbers [3]).transform.RotateAround (pos.position, pos.forward, -90);
			pos = ((TextMesh)currentNumbers [5]).transform;
			((TextMesh)currentNumbers [5]).transform.RotateAround (pos.position, pos.forward, 90);
			break;
		case Direction.Left:
			for (int i = 0; i < currentNumbers.Count; i++) {
				if (i != 3 && i != 5 && i != 1) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, -90);
				}
				if (i == 1) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, 180);
				}
				if (i == 5) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, 90);
				}
			}
			break;
		case Direction.Right:
			for (int i = 0; i < currentNumbers.Count; i++) {
				if (i != 1 && i != 5 && i != 2) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, 90);
				}
				if (i == 2) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, 180);
				}
				if (i == 5) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, -90);
				}
			}
			break;
		}*/
		lastDirection = d;
		onMovement = false;
		currentPos = transform.position;
		audio.pitch = Random.Range (0.95f, 1.05f);
		audio.PlayOneShot(audioRotation);
		steps++;
		timeLastMove = Time.timeSinceLevelLoad;
		hintTime = 10f;
	}

	Cell lastCell;

	bool ReverseDirection(Direction d1, Direction d2){
		if(d1 == d2)
			return false;
		else{
			switch(d1){
				case Direction.Left:
				if(d2 == Direction.Right)
					return true;
				else
					return false;
				case Direction.Right:
				if(d2 == Direction.Left)
					return true;
				else
					return false;
				case Direction.Up:
				if(d2 == Direction.Down)
					return true;
				else
					return false;
				case Direction.Down:
				if(d2 == Direction.Up)
					return true;
				else
					return false;
				default:
					return true;
			}
		}
	}
	
	List <Cell> cells;

	IEnumerator grayOutCell(Cell c_, bool b){
		float rnd = Random.Range (0.1f, 0.3f);
		yield return new WaitForSeconds(rnd);
		c_.changeState(Cell.StateCell.Passed);
		inGame.passedCells.Add(c_);
		if(b)
			calculatingPassed = false;
	}

	bool calculatingPassed = false;

	public void UpdateScore(int points){
		score += (int)(points * multiplier);
		inGame.score.text = score.ToString();
	}

	public void UpdateMultiplier(float m){
		if(m >= 0)
			multiplier += m;
		else
			multiplier = 0.5f;
		multiplier = (Mathf.Round(multiplier * 100f))/100f;
		multiplier = Mathf.Clamp(multiplier,0,4);
		inGame.multiplier.text = "x "+multiplier.ToString();
		if(m == -1)
			inGame.multiplier.text = "x 1";
	}

	void UpdateScoreMultiplier(int points){
		
	}

	int cellValue = 10;

	void OnTriggerStay(Collider c){
		if(c.CompareTag("Untagged")){
			if(onMovement || calculated)
				return;

			//obtener celda actual
			Cell cell = c.GetComponent<Cell>();

			if(cell != null && cell.stateCell == Cell.StateCell.Normal && diceColor != ColorReference.CellColor.None && cell.cellColor != diceColor && !calculatingPassed){
				inGame.badMove();
				return;
			}

			/*if(firstMove && cell.stateCell == Cell.StateCell.Passed){
				firstMove = false;
				SetDiceColor(cell.cellColor,false);
			}*/

			if(cell != null && cell.stateCell == Cell.StateCell.Normal && !inGame.selectCell){
				diceColor = cell.cellColor;
				adjCellCount = 0;
				cellsSearched = new List<int>();
				cells = new List<Cell>();
				//Get adjacent cells of same color
				cellsSearched.Add(cell.index);
				cells.Add(cell);
				searchCell(cell,diceColor);
				adjCellCount = cells.Count;
				Debug.Log(adjCellCount);
				
				if(adjCellCount > 0){
					calculatingPassed = true;
					foreach(Cell c_ in cells){
						if(c_ == cells.Last())
							StartCoroutine(grayOutCell(c_,true));
						else
							StartCoroutine(grayOutCell(c_,false));
					}
					if(firstMove){
						SetDiceColor(nextColor,true);
						firstMove = false;
					}
					else{
						SetDiceColor(nextColor,true);
						if(adjCellCount >= 3)
							UpdateMultiplier(0.5f);
						else if(adjCellCount > 1)
							UpdateMultiplier(0.25f);
						else
							UpdateMultiplier(0);
					}
					UpdateScore((int)((adjCellCount * cellValue)*multiplier));
				}

				calculated = true;
			}
		}
		else {
			switch (c.tag) {
			case "Rotate90CW":
				Destroy (c.gameObject);
				StartCoroutine (inGame.rotateCells (true));
				break;
			case "Rotate90CCW":
				Destroy (c.gameObject);
				StartCoroutine (inGame.rotateCells (false));
				break;
			case "Death":
				if (!dropped)
				{
					dropped = true;
					StartCoroutine(Drop());
				}
				break;
			}
		}

		if(diceColor == ColorReference.CellColor.Wrong){
			inGame.badMove();
		}

		if(c.GetComponent<Cell>() != null)
			onFloor = true;
	}

	public void SetDiceColor(ColorReference.CellColor color, bool b){
		diceColor = color;
		GetComponent<Renderer>().material.SetColor("_Color",inGame.colorReference.GetColorByEnum(diceColor));
		GetComponent<Renderer>().material.SetColor("_emissionColor",inGame.colorReference.GetColorByEnum(diceColor));
		if(b)
			UpdateNextColor();
	}



	int adjCellCount = 0;
	List <int> cellsSearched;



	public int getAdjacentCellCount(Cell c){
		adjCellCount = 0;
		cells = new List<Cell>();
		cellsSearched = new List<int>();
		cells.Add(c);
		cellsSearched.Add(c.index);
		searchCell(c,c.cellColor);
		adjCellCount = cells.Count;
		Debug.Log(c.index+","+adjCellCount+" - "+c.cellColor);
		return adjCellCount;
	}

	void searchCell(Cell c, ColorReference.CellColor color){
		for(int i=0;i<c.adjacentCells.Length;i++){
			if(c.adjacentCells[i] != null && c.adjacentCells[i].cellColor == color && !cellsSearched.Contains(c.adjacentCells[i].index)){
				//adjCellCount++;
				cellsSearched.Add(c.adjacentCells[i].index);
				cells.Add(c.adjacentCells[i]);
				searchCell(c.adjacentCells[i],color);
			}
		}
	}

	void OnTriggerExit(Collider c)
	{	
		if(c.GetComponent<Cell>() == null){
			onFloor = false;
			StartCoroutine(delayOnFloor(0.15f));
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.name);
		if(other.GetComponent<Cell>() != null)
			onFloor = true;
	}

	IEnumerator delayOnFloor(float f){
		yield return new WaitForSeconds(f);
		if(!onFloor && !onMovement && !inGame.finished)
			StartCoroutine(Drop());
	}


	void changeOperation(Operation op){
		nextOperation = op;
	}

	IEnumerator Drop(){
        dropped = true;
		inGame.GetComponent<CameraControl> ().follow = false;
		for (int i = 0; i < 50; i++) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - ((i*i)/20f / (50f)), transform.position.z);
			yield return new WaitForSeconds (0.001f);
			if (i == 25) {
				inGame.badMove ();
			}
		}
    }
		

	public void ToggleSwipe(bool b){
		if (b) {
			swipe = true;
			plane.gameObject.SetActive (false);
			PlayerPrefs.SetInt ("Control", 0);
		} else {
			swipe = false;
			plane.gameObject.SetActive (true);
			PlayerPrefs.SetInt ("Control", 1);
		}
	}

	Vector3 initialPosition;
	float timeSwipe;
	public bool onFloor = true;

	/*public void EnableAdjCells(){
		foreach (Transform t in inGame.adjacentCells) {
			t.GetComponent<AdjacentCellFinder> ().EnableCell (true);
		}
	}*/

	// Update is called once per frame
	void Update () {
		
		
		//inGame.targetColor.text = targetColor[targetIndex].ToString();
		if (onMovement || inGame.rotating || Time.timeSinceLevelLoad < 2f || inGame.pause)
			return;
		/*if(timeLastMove <= Time.timeSinceLevelLoad - inGame.pauseTime - hintTime){
			StartCoroutine (inGame.lightPath (0));
			hintTime += 5f;
		}*/
		if(!onMovement){
			if (Input.GetKeyDown (KeyCode.W)) { StartCoroutine(turn (Direction.Up)); }
			if (Input.GetKeyDown (KeyCode.S)) { StartCoroutine(turn (Direction.Down)); }
			if (Input.GetKeyDown (KeyCode.A)) { StartCoroutine(turn (Direction.Left)); }
			if (Input.GetKeyDown (KeyCode.D)) { StartCoroutine(turn (Direction.Right));}
		}

		if (swipe) {
			if (Input.GetMouseButtonDown (0)) {
				initialPosition = Input.mousePosition;
				timeSwipe = Time.time;
			}
			if (Input.GetMouseButtonUp (0)) {
				if (timeSwipe + 1f > Time.time && Vector3.Distance (initialPosition, Input.mousePosition) >= 50f) {
					Vector3 dir = (Input.mousePosition - initialPosition).normalized;
					print ("swipe!" + Vector3.Angle (new Vector3 (1f, 0f, 0f), dir));
					float angle = Vector3.Angle (new Vector3 (1f, 0f, 0f), dir);
					if (angle >= 0f && angle < 90f) {
						if (dir.y > 0f) {
							StartCoroutine (turn (Direction.Right));
						} else {
							StartCoroutine (turn (Direction.Down));
						}
					} else {
						if (dir.y > 0f) {
							StartCoroutine (turn (Direction.Up));
						} else {
							StartCoroutine (turn (Direction.Left));
						}
					}
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
			transform.RotateAround (transform.position, Vector3.right, 90f);
		if(Input.GetKeyDown(KeyCode.DownArrow))
			transform.RotateAround (transform.position, Vector3.right, -90f);
		if(Input.GetKeyDown(KeyCode.LeftArrow))
			transform.RotateAround (transform.position, Vector3.forward, 90f);
		if(Input.GetKeyDown(KeyCode.RightArrow))
			transform.RotateAround (transform.position, Vector3.forward, -90f);
		
	}
	void OnMouseDown()
	{
		if(!inGame.selectCell){
			inGame.selectCell = true;
			transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
			onMovement = true;
			StartCoroutine(inGame.dropCells(inGame.passedCells));
			UpdateMultiplier(-1);
		}
	}

}
