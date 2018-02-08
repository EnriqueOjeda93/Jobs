using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scrip de la reja que se cierra

public class Emboscada1 : MonoBehaviour {
	
	// Prefabs de las rejas que se abren
	public GameObject RejasM1;
	public GameObject RejasM2;
	Vector3 posR;
	// Esto sirve para cuando se vuelva a pisar el collaider no haga efecto la trampa
	// ni se reactiven el movimiento de las rejas saliendose del mapa
	bool activada = false;

	void OnCollisionEnter( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.tag == "esqueleto" && activada == false) {

			// Movimiento de la reja que se cierra
			posR = transform.position;
			posR.y = 0;
			transform.position = posR;

			// Movimientos de la rejas que se abren
			posR = RejasM1.transform.position;
			posR.y = 4;
			RejasM1.transform.position = posR;

			posR = RejasM2.transform.position;
			posR.y = 4;
			RejasM2.transform.position = posR;

			// Cambiamos la condicion para que no se vuelva a activar
			activada = true;
		}
	}
}
