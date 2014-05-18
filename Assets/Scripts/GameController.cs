using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	bool gameOver = false;

	public GameObject EquationPrefab;
	//public GameObject EqualSignPrefab;
	public GameObject SymbolPrefab;
	public GameObject MissingPiecePrefab;

	public List<List<string>> eq = new List<List<string>>();

//	List<string> a0 = new List<string>(){"2"};
//	List<string> a1 = new List<string>(){"+", "*"};
//	List<string> a2 = new List<string>(){"4", "6"};
//	List<string> a3 = new List<string>(){"8"};

	void Start()
	{
		createEquation();
	}

	//Hard coded test equation. This will be replaced with some algorithm which generates equations
	List<List<string>> A = new List<List<string>>()
	{
		new List<string>(){"2"}, //first operand
		new List<string>(){"+", "*"}, //potential operators
		new List<string>(){"4", "6"}, //potential second operand
		new List<string>(){"="},
		new List<string>(){"8"} //answer
	};

	// Update is called once per frame
	void Update ()
	{
		if(gameOver)
		{
			Application.LoadLevel("GameOverScene");
		}
	}

	void createEquation()
	{
		GameObject equationPrefab = (GameObject)Instantiate(EquationPrefab, GameObject.Find("EquationPanel").transform.position, Quaternion.identity);

		equationPrefab.transform.parent = GameObject.Find("EquationPanel").transform;
		equationPrefab.transform.localPosition = new Vector3(0, -207, 0);
		equationPrefab.transform.localScale = new Vector3(1, 1, 1);

		for(int i = 0; i < A.Count; i++)
		{
			List<string> eqPart = new List<string>();
			for(int j = 0; j < A[i].Count; j++)
			{
				eqPart.Add(A[i][j]);
			}

			eq.Add(eqPart);
		}
		//CreateEquation(equation);

		float offset = 15f;
		float startPosX = 0;

		float elementWidth = 0;

		for(int i = 0; i < eq.Count; i++)
		{
			if (eq[i].Count == 1)
			{
				GameObject symbolPrefab = (GameObject)Instantiate(SymbolPrefab, equationPrefab.transform.position, Quaternion.identity);
				symbolPrefab.name = symbolPrefab.name + i;
				symbolPrefab.transform.parent = equationPrefab.transform;

				UILabel symbolValue = GameObject.Find(symbolPrefab.name).GetComponent<UILabel>();

				symbolPrefab.transform.localPosition = new Vector3(startPosX, 0, 0);

				symbolValue.text = eq[i][0];

				elementWidth = symbolValue.width;
			}
			else
			{
				GameObject emptyBoxPrefab = (GameObject)Instantiate(MissingPiecePrefab, equationPrefab.transform.position, Quaternion.identity);
				emptyBoxPrefab.name = emptyBoxPrefab.name + i;
				emptyBoxPrefab.transform.parent = equationPrefab.transform;

				UISprite boxSprite = GameObject.Find(emptyBoxPrefab.name).GetComponent<UISprite>();
				emptyBoxPrefab.transform.localPosition = new Vector3(startPosX + 20f, 0, 0);

				elementWidth = boxSprite.width - 20f;
			}

			startPosX += elementWidth + offset;
		}

		//GameObject equalPrefab = (GameObject)Instantiate(EqualSignPrefab, equationPrefab.transform.position, Quaternion.identity);
		//equalPrefab.transform.parent = equationPrefab.transform;
		//equalPrefab.transform.localPosition = new Vector3(startPosX - (offset * i), 0, 0)
	}

}

