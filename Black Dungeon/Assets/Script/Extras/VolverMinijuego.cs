using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolverMinijuego : MonoBehaviour {

	public GameObject personaje;
	public GameObject personaje2D;
	public Camera camara;
	public Camera camara2D;
	public GameObject clip;
	public AudioClip cancion;

	void Start(){
		//Indicamos la camara activa
		camara.enabled = true;
		camara2D.enabled = false;
	}

	void OnTriggerEnter(Collider collision) {
		if (collision.CompareTag ("esqueleto")) { 

			camara2D.enabled = false;
			camara.enabled = true;

			personaje2D.SetActive (false);
			personaje.SetActive (true);
			volveCuadro.regreso = true;

			clip = GameObject.FindGameObjectWithTag ("esqueleto");
			clip.GetComponent<AudioSource> ().PlayOneShot(cancion);
			
		}
	}
}
