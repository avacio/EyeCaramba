using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllBallsController : MonoBehaviour {
	public Text winText;

	Camera m_MainCamera;
	BallController Script1;
	Ball2Controller Script2;
	GameObject brokenHeart;
	GameObject ending;

	// Use this for initialization
	void Start () {
		ending = GameObject.Find ("Ending");
		ending.SetActive (false);
		Script1 = GetComponentInChildren<BallController>();
		Script2 = GetComponentInChildren<Ball2Controller>();
		winText.text = "";
		brokenHeart = GameObject.Find ("Broken Heart");
		m_MainCamera = Camera.main;
	}
	
	public void checkWin() {
		if (Script1.ball1count >= 10 && Script2.ball2count >=10) {
			winText.text = "WINNER, WINNER, CHICKEN DINNER";

			brokenHeart.SetActive (false);
			ending.SetActive (true);
		}
	}

	public void checkSpot() {
		if (Script1.SpotOn1 && Script2.SpotOn2) {
			m_MainCamera.clearFlags = CameraClearFlags.Depth;
			winText.text = "! ! !";
		}
	}
}
