using UnityEngine;
using System.Collections;

public class Arbol : MonoBehaviour {

	// Prefab de la manzana
	public GameObject applePrefab;
	// Prefab de la manzana verde
	public GameObject ManzanaVerde;
	// Velocidad arbol
	public float speed = 1f;
	// Cada cuanto cambia de direccion el arbol
	public float chanceToChangeDirections = 0.008f;
	// Variable para el cambio de velocidad
	public float velocidadCreacion = 2f;
	// Tiepo de creacion entre manzanas
	float speedManzanas = 2f;
	// Calcula el tamaño de la pantalla para el limite del arbol
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
			// Variable que calcula cuando sale una manzana verde
			float manzanaAleatorio = Random.Range (1, 7);

			// Creacion de la manzana y manzana verde
			if (manzanaAleatorio == 4f) {
				GameObject manzanaVerde = (GameObject)Instantiate (ManzanaVerde) as GameObject;
				manzanaVerde.transform.position = transform.position;
			} else {
				GameObject manzana = (GameObject)Instantiate (applePrefab) as GameObject;
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