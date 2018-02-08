using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IA2 : MonoBehaviour {

	public Transform player;
	static Animator anim;
	public static bool atacar = false;
	bool viviendo = true;
	bool espera = true;
	bool dormido = false;

	float vidaIA;


	void Start () {
		vidaIA = 100;
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		// cuando muere viviendo es false para que no sigua moviendose
		if (viviendo == true) {
			// calculamos la posicion del jugador y el angulo de vision
			Vector3 direction = player.position - this.transform.position;
			float angle = Vector3.Angle (direction, this.transform.forward);

			// cuando hace contacto con el jugador
			if (Vector3.Distance (player.position, this.transform.position) < 30 && angle < 360) {

				direction.y = 0;
				anim.SetBool ("isIdle", false);


				if (Vector3.Distance (player.position, this.transform.position) < 3 && angle < 360) {
					this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
					anim.SetBool ("isAttacking", false);
					anim.SetBool ("isWalking", false);
					anim.SetBool ("isIdle", true);
					if (espera) {
						if (Random.Range (1, 150) == 13) {
							this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0f);
							anim.SetBool ("isIdle", false);
							anim.SetBool ("isAttacking", true);
							dormido = true;
							espera = false;
							atacar = true;
							Invoke ("Espera", 2);
						}
					}

				} else {
					this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
					if (dormido) {
						if (Random.Range (1, 220) == 13) {
							dormido = false;
						}
					} else {
						this.transform.Translate (0, 0, 0.015f);
						anim.SetBool ("isWalking", true);
						anim.SetBool ("isAttacking", false);
					}
				}
			} else {

				anim.SetBool ("isIdle", true);
				anim.SetBool ("isAttacking", false);
				anim.SetBool ("isWalking", false);
			}

		}

		if (vidaIA <= 0) {
			anim.SetBool ("morir", true);
			viviendo = false;
		}
	}

	void Espera(){
		espera = true;
		CancelInvoke ();
	}

	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("espada")) {
			if (AnimacionEsqueleto.atacar == 1) {
				vidaIA -= 8;

			}
		}
	}

}
