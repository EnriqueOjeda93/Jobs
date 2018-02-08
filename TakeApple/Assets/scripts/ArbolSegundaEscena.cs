using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolSegundaEscena : MonoBehaviour {

	// Prefabs de los diferentes policias
	public GameObject police1;
	public GameObject police2;
	public GameObject police3;
	public GameObject police4;
	// Prefab de la hierva
	public GameObject Hierva;
	public float speed = 1f;
	// Cada cuanto cambia de direccion el avion
	public float chanceToChangeDirections = 0.008f;
	// Variable para el cambio de velocidad
	public float velocidadCreacion = 2f;
	// Tiepo de creacion entre hiervas
	float speedManzanas = 2f;
	// Calcula el tamaño de la pantalla para el limite del avion
	float limite;

	void Start(){
		// Calculamos el limite y ajustamos el tamaño
		limite = CalculaLimite ();
		limite = limite + 1f;
	}


	void Update () {

		// Restrincion del arbol a la pantalla
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		if ( pos.x < (limite)) {
			speed = Mathf.Abs(speed);
		} else if ( pos.x > -(limite) ) {
			speed = -Mathf.Abs(speed); 
		}


		if (Time.timeSinceLevelLoad > velocidadCreacion) {
			// Variable que calcula cuando sale un policia
			float manzanaAleatorio = Random.Range (1, 7);
			// Intanciar distintos policias cada vez que se crea y de la hierva
			float policeAleatorio = Random.Range (1, 4);
			if (manzanaAleatorio == 4f) {
				if (policeAleatorio == 1f) {
					GameObject manzanaVerde = (GameObject)Instantiate (police1) as GameObject;
					manzanaVerde.transform.position = transform.position;
				} else
				if (policeAleatorio == 2f) {
					GameObject manzanaVerde = (GameObject)Instantiate (police2) as GameObject;
					manzanaVerde.transform.position = transform.position;
				} else
				if (policeAleatorio == 3f) {
					GameObject manzanaVerde = (GameObject)Instantiate (police3) as GameObject;
					manzanaVerde.transform.position = transform.position;
				} else {
					GameObject manzanaVerde = (GameObject)Instantiate (police4) as GameObject;
					manzanaVerde.transform.position = transform.position;
				}
			} else {
				GameObject manzana = (GameObject)Instantiate (Hierva) as GameObject;
				manzana.transform.position = transform.position;

			}

			// Cambio de velocidad cada cierto tiempo
			if(velocidadCreacion == 20f){
				speedManzanas = 1f;
				speed *= 2;
			}

			if(velocidadCreacion == 40f){
				speedManzanas = 0.5f;
				speed *= 2;
			}

			if(velocidadCreacion == 55f){
				speedManzanas = 0.2f;
				speed *= 2;
			}

			velocidadCreacion += speedManzanas;
		}



	}

	// Metodo que cambia de direccion
	void FixedUpdate() {
		if ( Random.value < chanceToChangeDirections) {
			speed *= -1;
		}
	}


	float CalculaLimite(){
		Vector3 limite = Camera.main.ScreenToWorldPoint (new Vector3(0,0,0));
		return limite.x;
	}

}