using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activadores : MonoBehaviour {

	public static int activador = 0;
	Vector3 rot = new Vector3 (0.0f,-80f,0f);


	void Update () {
		Debug.Log (activador);
		if(activador == 3){
			transform.Rotate (rot);
			activador = 0;
		}
	}

}
