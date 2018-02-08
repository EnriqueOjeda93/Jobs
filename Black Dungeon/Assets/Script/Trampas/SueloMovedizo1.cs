using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloMovedizo1 : MonoBehaviour {

	// Prefab del personanje
	public GameObject esqueleto;
	// Interaccion del suelo y personaje, por defecto false
	bool moverEsqueleto = false;

	// Movimiento de la plataforma
	public float speed = 1f;
	public float leftAndRightEdge = 156f;
	public float left = 148f;

	// Prefab del suelo
	public GameObject suelo1;


	// Update is called once per frame
	void Update () {
		// movimiento de la primera plataforma
		Vector3 pos = suelo1.transform.position;
		pos.z += speed * Time.deltaTime;
		suelo1.transform.position = pos;

		// Limites de movimiento
		if (pos.z > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);
		} 

		if (pos.z < left) {
			speed = Mathf.Abs (speed); 
		}

		// Cuando el personaje entra en contacto con la plataforma, el movimiento
		// de ella se añade al del esqueleto
		if (moverEsqueleto) {
			Vector3 posEsk = esqueleto.transform.position;
			posEsk.z = pos.z;
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
