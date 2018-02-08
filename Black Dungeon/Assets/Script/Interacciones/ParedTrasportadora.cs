using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedTrasportadora : MonoBehaviour {

	// Cuando el colaider del esqueleto choca con el colaider de la pared
	// el esqueleto se teletransporta a la posicion del portal escondido

	public GameObject esqueleto;
	public GameObject teleport;

	void OnCollisionEnter( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.tag == "esqueleto" ) {
			esqueleto.transform.position = teleport.transform.position;
		}
	}
}
