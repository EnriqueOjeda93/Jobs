using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IA : MonoBehaviour {

	public Transform player;
	static Animator anim;
	public static bool atacar = false;
	bool viviendo = true;
	bool espera = true;
	bool dormido = false;

	public Slider vida;
	float vidaIA;

	public GameObject Rejas;

	public AudioClip roar;
	public AudioClip died;
	//public AudioClip hit;

	//movimiento de las rejas y palanca
	Vector3 posR;

	// Use this for initialization
	void Start () {
		vidaIA = 100;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		vida.value = vidaIA;
		// cuando muere viviendo es false para que no sigua moviendose
		if (viviendo == true) {
			// calculamos la posicion del jugador y el angulo de vision
			Vector3 direction = player.position - this.transform.position;
			float angle = Vector3.Angle (direction, this.transform.forward);

			// cuando hace contacto con el jugador
			if (Vector3.Distance (player.position, this.transform.position) < 25 && angle < 360) {
				
				direction.y = 0;
				anim.SetBool ("idle", false);


				if (Vector3.Distance (player.position, this.transform.position) < 3 && angle < 360) {
					this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
					anim.SetBool ("atacar", false);
					anim.SetBool ("atacar2", false);
					anim.SetBool ("atacar3", false);
					anim.SetBool ("walk", false);
					anim.SetBool ("idle", true);
					if (espera) {
						if (Random.Range (1, 150) == 13) {/*
						int ataque = Random.Range (1,3);
						if (ataque == 1) {
							this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
							anim.SetBool ("idle", false);
							anim.SetBool ("atacar", true);
							dormido = true;
							atacar = true;
						} else if (ataque == 2) {
							this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
							anim.SetBool ("idle", false);
							anim.SetBool ("atacar3", true);
							dormido = true;
							atacar = true;
						} else if (ataque == 3){
							this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
							anim.SetBool ("idle", false);
							anim.SetBool ("atacar2", true);
							dormido = true;
							atacar = true;
						}*/
							this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0f);
							anim.SetBool ("idle", false);
							anim.SetBool ("atacar", true);
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
						this.transform.Translate (0, 0, 0.05f);
						anim.SetBool ("walk", true);
						anim.SetBool ("atacar", false);
						anim.SetBool ("atacar2", false);
						anim.SetBool ("atacar3", false);
					}
				}
			} else {
				
				anim.SetBool ("idle", true);
				anim.SetBool ("atacar", false);
				anim.SetBool ("atacar2", false);
				anim.SetBool ("atacar3", false);
				anim.SetBool ("walk", false);
				anim.SetBool ("roar", false);
				if (Random.Range (1, 500) == 13) {
					anim.SetBool ("roar", true);
					transform.GetComponent<AudioSource>().PlayOneShot(roar);

				}
			}

			if (vidaIA <= 0) {
				if(viviendo){
					posR = Rejas.transform.position;
					posR.y += 4.5f;
					Rejas.transform.position = posR;
				}
				anim.SetBool ("die", true);
				transform.GetComponent<AudioSource>().PlayOneShot(died);
				viviendo = false;
			}
		}
	}

	void Espera(){
		espera = true;
		CancelInvoke ();
	}

	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("espada")) {
			if (AnimacionEsqueleto.atacar == 1) {
				vidaIA -= 2f;

			}
		}
	}

}
