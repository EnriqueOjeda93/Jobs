using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaEscenaFinal : MonoBehaviour {

	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("esqueleto")) {
			SceneManager.LoadScene( "Final" );

		}
	}
		

}
