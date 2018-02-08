using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloMovedizo2 : MonoBehaviour {

	// Prefab del personanje
	public GameObject esqueleto;
	// Interaccion del suelo y personaje, por defecto false
	bool moverEsqueleto = false;

	// Movimiento de la plataforma
	public float speed = 1f;
	public float leftAndRightEdge = 44f;
	public float left = 36f;

	// Prefab del suelo
	public GameObject suelo2;


	// Update is called once per frame
	void Update () {
		// movimiento de la segunda plataforma
		Vector3 pos = suelo2.transform.position;
		pos.x += speed * Time.deltaTime;
		suelo2.transform.position = pos;

		// Limites de movimiento
		if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);
		} 

		if (pos.x < left) {
			speed = Mathf.Abs (speed); 
		}

		// Cuando el personaje entra en contacto con la plataforma, el movimiento
		// de ella se añade al del esqueleto
		if (moverEsqueleto) {
			Vector3 posEsk = esqueleto.transform.position;
			posEsk.x = pos.x;
			esqueleto.transform.position = posEsk;
		}
	}

	// Collisiones con el esqueleto que activa la condicion
	void OnCollisionEnter( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.CompareTag("esqueleto")) {
			moverEsqueleto = true;
		}
	}

	void OnCollisionExit( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.CompareTag("esqueleto")) {
			moverEsqueleto = false;
		}
	}
}
