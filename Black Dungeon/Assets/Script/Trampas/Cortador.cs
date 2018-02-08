using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cortador : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// rotacion del cortador con velocidad uniforme
		transform.Rotate ( Vector3.down * Time.deltaTime * 60); 
	}


}
