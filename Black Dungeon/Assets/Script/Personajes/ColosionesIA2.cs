using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColosionesIA2 : MonoBehaviour {
	
	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("esqueleto")) {
			AnimacionEsqueleto.variableVida -= 2;
			AnimacionEsqueleto.daño = 1;
		}
	}

	
}
