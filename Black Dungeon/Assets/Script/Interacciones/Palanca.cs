using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour {

	// Condicionales
	bool activado = false;
	bool entra = true;
	// Prefab de la reja cerrada, canvas y puerta a abrir
	public GameObject prefab;
	public GameObject Rejas;
	public GameObject Puerta1;

	//movimiento de las rejas y palanca
	Vector3 posR;
	Vector3 pos;

	void Update () {
		if(activado){
			float z = Input.GetAxis ("activar");
			if(z > 0){
				pos = transform.position;
				pos.x += 1;
				pos.y += -1;
				transform.position = pos;

				posR = Rejas.transform.position;
				posR.y += 4;
				Rejas.transform.position = posR;

				// Movimiento de la puerta
				Puerta1.transform.Rotate(Vector3.up *80);

				entra = false;
				activado = false;
			}
		}


	}

	// Collisiones
	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("esqueleto")) {
			if(entra){
				// Instancia del prefab y activamos las funciones
				Instantiate (prefab);
				activado = true;
			}
		}
	}

	void OnTriggerExit( Collider collision ) {
		if ( collision.CompareTag("esqueleto")) {
			// Eliminamos el prefab y desactivamos las funciones
			GameObject prefab2 = GameObject.FindGameObjectWithTag ("UI");
			Destroy (prefab2);

			activado = false;
		}

	}
}
