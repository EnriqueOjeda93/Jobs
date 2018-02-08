using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour {


	// prefab del boton
	public GameObject boton;
	bool activado = true;
	bool entra = false;
	public GameObject prefab;
	// prefab de la puerta
	public GameObject puerta;

	// movimiento y rotacion
	Vector3 fin = new Vector3 (0.1f,0f,0f);
	Vector3 rot = new Vector3 (0.0f,-80f,0f);



	void Update () {
		// Si hay condicion, se ejecutan los movimientos del interruptor y puerta
		if(entra){
			float z = Input.GetAxis ("activar");
			if(z > 0){
				Vector3 pos = boton.transform.position;
				pos.x -= fin.x;
				boton.transform.position = pos;
				puerta.transform.Rotate (rot);

				// Desactivamos las funciones
				entra = false;
				activado = false;

			}
		}
	}

	// Activamos el canvas y las interacciones con el interruptor
	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("esqueleto")) {
			if(activado){
				Instantiate (prefab);
				entra = true;
			}
		}
	}

	// Buscamos el canvas y lo eliminamos
	void OnTriggerExit( Collider collision ) {
		GameObject prefab2 = GameObject.FindGameObjectWithTag ("UI");
		if(activado){
			Destroy (prefab2);
			entra = false;
		}
	}
}
