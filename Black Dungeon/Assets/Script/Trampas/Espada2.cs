using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada2 : MonoBehaviour {

	public float speed = 1f;
	public float leftAndRightEdge = 50f;
	public float left = 45f;

	public GameObject espada;

	// Update is called once per frame
	void Update () {

		// movimientos de las espadas
		Vector3 pos = espada.transform.position;
		pos.x += speed * Time.deltaTime;
		espada.transform.position = pos;

		// Limites del movimiento de las espadas
		if (pos.x < leftAndRightEdge) {
			speed = Mathf.Abs (speed);
		} else if (pos.x > left) {
			speed = -Mathf.Abs (speed); 
		}
	}
}
