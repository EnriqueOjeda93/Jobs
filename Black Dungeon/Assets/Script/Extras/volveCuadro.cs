using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volveCuadro : MonoBehaviour {

	public GameObject destino;
	public GameObject personaje;

	public static bool regreso = false;

	void OnTriggerEnter(Collider collision) {
		if (collision.CompareTag ("esqueleto")) { 
			if(regreso){
				personaje.transform.position = destino.transform.position;
			}
		}
	}
}
