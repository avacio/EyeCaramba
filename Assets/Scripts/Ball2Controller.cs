using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball2Controller : MonoBehaviour {
	public float speed;
	public Text otherCountText;
	public int ball2count;
	public bool SpotOn2;
	AllBallsController parent;
	GameObject bg0, bg1, bg2, bg3, bg4, bg5, bg6;

	private Rigidbody rb;

	// Initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		parent = transform.GetComponentInParent<AllBallsController> ();
		ball2count = 0;
		otherCountText.text = "";
		SpotOn2 = false;

		bg0 = GameObject.Find ("Ground");
		bg1 = GameObject.Find ("limeGround");
		bg2 = GameObject.Find ("dramaGround");
		bg3 = GameObject.Find ("legoGround");
		bg4 = GameObject.Find ("brainGround");
		bg5 = GameObject.Find ("moonGround");
		bg6 = GameObject.Find ("meatGround");

		bg1.SetActive (false);
		bg2.SetActive (false);
		bg3.SetActive (false);
		bg4.SetActive (false);
		bg5.SetActive (false);
		bg6.SetActive (false);
	}

	// FixedUpdate is called before performing any physics calculations
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

		if (Input.GetKeyDown ("space")) {
			if (bg0.activeSelf) {
				bg0.SetActive (false);
				bg1.SetActive (true);
			}
			else if (bg1.activeSelf) {
				bg1.SetActive (false);
				bg2.SetActive (true);
			}
			else if (bg2.activeSelf) {
				bg2.SetActive (false);
				bg3.SetActive (true);
			}
			else if (bg3.activeSelf) {
				bg3.SetActive (false);
				bg4.SetActive (true);
			}
			else if (bg4.activeSelf) {
				bg4.SetActive (false);
				bg5.SetActive (true);
			}
			else if (bg5.activeSelf) {
				bg5.SetActive (false);
				bg6.SetActive (true);
			}
			else if (bg6.activeSelf) {
				bg6.SetActive (false);
				bg0.SetActive (true);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			ball2count++;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("SPOT")) {
			SpotOn2 = true;
			parent.checkSpot ();
		}
	}

	void OnCollisionExit (Collision other) 
	{
		if (other.gameObject.CompareTag ("SPOT")) {
			SpotOn2 = false;
		}
	}

	void SetCountText() {
		//otherCountText.text = "Count: " + count.ToString ();
		otherCountText.text += "| ";
		parent.checkWin ();
	}
}
