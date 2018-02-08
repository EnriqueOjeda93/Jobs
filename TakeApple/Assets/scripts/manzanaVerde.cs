using UnityEngine;
using System.Collections;

public class manzanaVerde : MonoBehaviour {

	// Script de la manzana verde o policia
	public static float bottomY = -15f;

	void Update () {
		if ( transform.position.y < bottomY ) {
			Destroy( this.gameObject );

		}
	}
}
