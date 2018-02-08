using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empuje : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;
	Vector3 vector = new Vector3(0, 0, -500);
	public GameObject pared;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
 

	void OnTriggerEnter(Collider collision) {
		if (collision.CompareTag ("acelerador")) {
			rb.AddForce (vector, ForceMode.Impulse);  

		}

		if (collision.CompareTag ("paredsecreta")) {
			Destroy (pared);

		}
	}
}