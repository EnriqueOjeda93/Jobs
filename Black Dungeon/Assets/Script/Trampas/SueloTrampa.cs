using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloTrampa : MonoBehaviour {

	// Suelo trampa que cuando colisiona se destruye a los 2 segundos
	public GameObject suelo;
	public GameObject pared;

	public static int contador;

	Vector3 rot = new Vector3 (0.0f,-80f,0f);


	void Start (){
		contador = 0;
	}

	void Update(){

		if (contador == 3) {
			Destroy( pared );
			Instantiate (suelo);
			transform.Rotate (rot);
			contador = 0;
		}

	}

}
