using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ancla : MonoBehaviour {

	public GameObject ancla;

	// rotaciones del ancla y limites
	Vector3 rotmax = new Vector3 (0,0,48);
	Vector3 rotmin = new Vector3 (0,0,-48);
	Vector3 rotar = new Vector3 (0,0,1);

	void Start(){
		// Iniciamos la retacion
		transform.Rotate ( Vector3.back * Time.deltaTime * 100);
	}

	// Update is called once per frame
	void Update () {

		// Limites de movilidad del ancla
		if (ancla.transform.rotation.z *100 > rotmax.z) {
			rotar = Vector3.back;		} 

		if (ancla.transform.rotation.z *100 < rotmin.z) {
			rotar = Vector3.forward;
		}

		transform.Rotate ( rotar * Time.deltaTime* 30);
	}
		
}
