using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPrueba : MonoBehaviour {

	public float speed = 10.0F; //Velocidad de movimiento
	public float rotationSpeed = 100.0F; //Velocidad de rotación
	GameObject clip;

	void Update() {
		transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime , 0);
	}
	/*
	void OnTriggerEnter(Collider collision) {
		Debug.Log ("entra");
		if (collision.CompareTag ("piezza")) { 
			Debug.Log ("entra");
			clip = GameObject.FindGameObjectWithTag ("piezza");
			clip.GetComponent<AudioSource> ().Play ();

		}
	}*/
}
