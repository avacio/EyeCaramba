using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	public float speed;
	public Text countText;
	public int ball1count;
	public bool SpotOn1;
	AllBallsController parent;

	private Rigidbody rb;

	// Initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		ball1count = 0;
		countText.text = "";
		SpotOn1 = false;
		parent = transform.GetComponentInParent<AllBallsController> ();
	}

	// FixedUpdate is called before performing any physics calculations
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			ball1count++;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("SPOT")) {
			SpotOn1 = true;
			parent.checkSpot ();
		}
	}

	void OnCollisionExit (Collision other) 
	{
		if (other.gameObject.CompareTag ("SPOT")) {
			SpotOn1 = false;
		}
	}

	void SetCountText() {
//		countText.text = "Count: " + count.ToString ();
		countText.text += "| ";
		parent.checkWin ();
	}
}
