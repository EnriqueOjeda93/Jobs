using UnityEngine;
using System.Collections;

public class manzana : MonoBehaviour {

	// Script de la manzana y la hierva
	public static float bottomY = -15f;

	void Update () {
		if ( transform.position.y < bottomY ) {
			Destroy( this.gameObject );
			GameController apScript = Camera.main.GetComponent<GameController>();

			// LLamamos al metodo de destruccion de la manzana o la hierva si pasa de 
			// una cierta posicion
			apScript.AppleDestroyed();

		}
	}
}
