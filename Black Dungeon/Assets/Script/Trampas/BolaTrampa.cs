using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaTrampa : MonoBehaviour {

	// Prefab de las paredes a destruir
	public GameObject pared1;
	public GameObject pared2;

	void OnCollisionEnter( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.tag == "esqueleto" ) {
			// cuando colisiona con el colaider se destruyen las paredes y la bola cae por fisica
			Destroy( pared1 );
			Destroy( pared2 );
		}
	}

}
