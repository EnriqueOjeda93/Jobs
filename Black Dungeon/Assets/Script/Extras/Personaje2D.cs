using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Personaje2D : MonoBehaviour {

	Animator anim;


	// variables del movimientos del esqueleto
	public float velocidadAndar=8;
	public float velocidadCorrer=20;
	private float velocidad = 0;
	Vector3 movimiento;
	Vector3 giro = new Vector3 (0, 180, 0);

	public GameObject Camara;

	// vidas esqueleto y ia
	public static float variableMuerte2D;   // Utilizada en animacion morir y restrinfir movimientos
	public static float vidaIA;
	public bool derecha = true;
	public bool izquierda = false;

	public GameObject pared1;
	public GameObject pared2;
	public GameObject pared3;
	public GameObject personaje;
	public GameObject personaje2D;
	public Camera camara;
	public Camera camara2D;

	// Use this for initialization
	void Start () {
		// inicializamos aqui para cuando se carge la escena se vuelvan a cargar
		variableMuerte2D = 0;
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
		
		// animaciones y moviemiento del esqueleto, variableMuerte = si la vida llega a 0
		// final = cuando accedemos al barco para el final
		if (variableMuerte2D == 0) {
			float v = Input.GetAxis ("Horizontal");
			float c = Input.GetAxis ("Correr");
				velocidad = v;

			if (v < 0) {
				izquierda = true;
				if (derecha) {
					//Camara.transform.Rotate (giro);
					transform.Rotate (giro);
					derecha = false;
				}


				if (c > 0 && v < 0) {
					velocidad -= c;
					movimiento = Vector3.forward * (c) * Time.deltaTime * velocidadCorrer;
				} else {
					movimiento = Vector3.back * v * Time.deltaTime * velocidadAndar;

				}

			} else if (v > 0) {
				derecha = true;
				if (izquierda) {
					//Camara.transform.Rotate (giro);
					transform.Rotate (giro);
					izquierda = false;
				}

				if (c > 0 && v > 0) {
					velocidad += c;
					movimiento = Vector3.forward * (c) * Time.deltaTime * velocidadCorrer;
				} else {
					movimiento = Vector3.forward * v * Time.deltaTime * velocidadAndar;

				}

			} else {
					movimiento = Vector3.zero;
			}

			transform.Translate (movimiento);


			//animacion
			anim.SetFloat ("velocidad", velocidad);

		} 
	}

	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("piezza")) {
			Destroy (pared2);

		}

		if ( collision.CompareTag("paredsecreta")) {
			Destroy (pared1);

		}

		if ( collision.CompareTag("caidaAgua")) {
			Destroy (pared3);

		}
	}


	void OnCollisionEnter( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if(collidedWith.tag == "TrDie"){
			anim.SetBool ("die", true);
			Invoke ("cambiar", 4);
		}
	}

	void cambiar(){
		camara2D.enabled = false;
		camara.enabled = true;

		personaje2D.SetActive (false);
		personaje.SetActive (true);
		volveCuadro.regreso = true;
		// Vuelve a la partida
	}
}
