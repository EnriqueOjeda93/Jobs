using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour {



	bool entra = false;
	// Prefab de los canvas y la pieza
	public GameObject prefab;
	public GameObject prefabText;
	public GameObject piezaP;
	// prefab de la puerta
	public GameObject puerta;
	// Condicion si encontramos la pieza
	public static bool piezaEncontrada = false;

	// movimiento y rotacion de la puerta
	Vector3 rot = new Vector3 (0.0f,-80f,0f);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(entra){
			float z = Input.GetAxis ("activar");
			if(z > 0){
				// Al pulsar si posemos la piezza la instancia y abrimos la puerta
				if (piezaEncontrada) {
					Instantiate (piezaP);
					puerta.transform.Rotate (rot);
				} else {
					// Sino instanciamos otro canvas que nos indica que falta la pieza
					GameObject prefab2 = GameObject.FindGameObjectWithTag ("UI");
					Destroy (prefab2);
					Instantiate (prefabText);
				}
				entra = false;
			}
		}
	}

	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("esqueleto")) {
			// Instancia del prefab y activamos las funciones
			Instantiate (prefab);
			entra = true;

		}
	}

	void OnTriggerExit( Collider collision ) {
		if ( collision.CompareTag("esqueleto")) {
			//Eliminamos los canvas al salr de la collision
			GameObject prefab2 = GameObject.FindGameObjectWithTag ("UI");
			GameObject prefabText = GameObject.FindGameObjectWithTag ("CanvPie");
			Destroy (prefab2);
			Destroy (prefabText);
		}
	}
}
