using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchilla : MonoBehaviour {

	public float speed = 1f;
	public float leftAndRightEdge = -18f;
	public float left = -11f;

	// Update is called once per frame
	void Update () {
		// Rotacion de la cuchilla y movimiento
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		transform.Rotate ( Vector3.right * Time.deltaTime * 200); 

		// Limites de movimientos de las cuchillas
		if (pos.x < leftAndRightEdge) {
			speed = Mathf.Abs (speed);
		} else if (pos.x > left) {
			speed = -Mathf.Abs (speed); 
		}
	}

}
