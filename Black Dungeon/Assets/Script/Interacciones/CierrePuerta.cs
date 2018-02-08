using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CierrePuerta : MonoBehaviour {

	public GameObject canvasVidaJefe;
	Vector3 rot = new Vector3 (0.0f,-80f,0f);
	bool cierre = false;

	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("esqueleto") && cierre == false) {
			transform.Rotate (rot);
			canvasVidaJefe.SetActive (true);
			cierre = true;
		}
	}
}
