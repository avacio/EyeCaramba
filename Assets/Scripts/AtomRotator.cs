using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomRotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 10, 5) * Time.deltaTime);
	}
}
