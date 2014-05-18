using UnityEngine;
using System.Collections;
using System;

public class VerifyEquation : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	void OnTriggerEnter(Collider other)
	{
		GameController gc = GameObject.Find ("GameController").GetComponent<GameController>();

		int startInx = gameObject.name.LastIndexOf(")")+1;

		int inx = Convert.ToInt32(gameObject.name.Substring(startInx));

		string value = other.GetComponent<UILabel>().text;

		if (gc.eq[inx].Contains(value))
		{
			other.gameObject.GetComponent<ScavengerHuntElement>().isCorrectElement = true;
			other.transform.parent = gameObject.transform;
		}
	}
}
