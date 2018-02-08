using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

	public Transform personaje;
	public Vector3 desplazamiento;

	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (personaje.position.x + desplazamiento.x, personaje.position.y + desplazamiento.y, desplazamiento.z + personaje.position.z);
	}
}
