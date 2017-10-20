using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScript : MonoBehaviour {
	public GameObject title; // Assign the text to this in the inspector
	public GameObject instructions;

	// Use this for initialization
	void Start () {
		StartCoroutine(Example());
	}

	IEnumerator Example()
	{
		title.SetActive( true ); // Enable the text so it shows
		instructions.SetActive( true );
		yield return new WaitForSeconds(5);
		title.SetActive( false ); // Disable the text so it is hidden
		instructions.SetActive( false );
	}
}
