using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMinijuego : MonoBehaviour {


	public GameObject personaje;
	public GameObject personaje2D;
	public Camera camara;
	public Camera camara2D;

	bool juegoAcabado = true;

	void Start(){
		//Indicamos la camara activa
		camara.enabled = true;
		camara2D.enabled = false;
	}

	void OnTriggerEnter(Collider collision) {
		if (collision.CompareTag ("esqueleto") && juegoAcabado) { 

			camara2D.enabled = true;
			camara.enabled = false;

			personaje2D.SetActive (true);
			personaje.SetActive (false);
			juegoAcabado = false;

		}
	}
}
