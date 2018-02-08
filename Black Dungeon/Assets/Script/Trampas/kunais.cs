using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunais : MonoBehaviour {

	// prefab de los kunais
	public GameObject kunai;
	public GameObject kunai2;
	bool mover = false;
	public float speed = 30f;
	Vector3 fin = new Vector3 (0,0,22);

	void Update(){
		moverKunai ();
	}

	//Cuando el personaje pisa el collaider se cumple la condicion para
	// que los kunais se muevan
	void OnCollisionEnter( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.tag == "esqueleto" ) {
			mover = true;
		}
	}

	void moverKunai(){

		// mueven los kuhnais de un lado a otro si hay condicion
		if (mover) {
			Vector3 pos = kunai.transform.position;
			pos.z -= speed * Time.deltaTime;
			kunai.transform.position = pos;

			Vector3 pos2 = kunai2.transform.position;
			pos2.z -= speed * Time.deltaTime;
			kunai2.transform.position = pos2;

			// Posicion de los cunais final, finalizamos su movimiento
			if (kunai.transform.position.z < fin.z) {
				mover = false;
			}
		}
	}
}
