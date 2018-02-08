using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teletranportador : MonoBehaviour {

	// Final de la primera mazmorra
	void OnCollisionEnter( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.tag == "esqueleto" ) {
			Application.LoadLevel( "Mazmorra2" );

		}
	}
}
