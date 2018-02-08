using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pajaro : MonoBehaviour {

	public static float bottomY = 20f;
	// Fuerzza con la que el pajaro empuja la manzana
	Vector3 fuerza = new Vector3( 4, 0, 0);


	void Update () {
		if ( transform.position.x > bottomY ) {
			Destroy( this.gameObject );

		}
	}

	// Metodo de colision entre la manzana y el pajaro
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Manzanas")
		{
			other.GetComponent<Rigidbody> ().AddForce(fuerza*Time.deltaTime*3000);
		}
	}
}
