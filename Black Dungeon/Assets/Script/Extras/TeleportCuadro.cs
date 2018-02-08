using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCuadro : MonoBehaviour {

	bool entra = false;
	bool teletransporta = true;
	public GameObject canvas;
	public GameObject destino;
	public GameObject personaje;

	void Update(){
		if(entra){
			float z = Input.GetAxis ("activar");
			if(z > 0){

				personaje.transform.position = destino.transform.position;

				// Desactivamos las funciones
				entra = false;
				teletransporta = false;

			}
		}
	}
	
	void OnTriggerEnter(Collider collision) {
		if (collision.CompareTag ("esqueleto")) { 
			if(teletransporta){
				Instantiate (canvas);
				entra = true;
			}
		}
	}

	void OnTriggerExit( Collider collision ) {
		if (collision.CompareTag ("esqueleto")) { 
			GameObject prefab2 = GameObject.FindGameObjectWithTag ("UI");
			if(teletransporta){
				Destroy (prefab2);
				entra = false;
			}
		}
		
	}
}
