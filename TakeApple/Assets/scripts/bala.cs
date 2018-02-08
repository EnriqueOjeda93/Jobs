using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour {

	// Velocidad de la bala
	public float velocidad = 10;

	// Limite de la bala supere cierto punto
	public static float bottomY = 20f;

	void Update () {
		// Velocidad de la bala
		transform.Translate (Vector3.up * velocidad * Time.deltaTime);

		if ( transform.position.y > bottomY ) {
			Destroy( this.gameObject );
		}
	}

	// Metodo de colision entre la bala y la manzana verde o policia
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "ManzanaVerde")
		{
			Destroy (this.gameObject);
			Destroy (other.gameObject);
		}
	}
}
