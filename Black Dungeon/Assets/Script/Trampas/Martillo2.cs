using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martillo2 : MonoBehaviour {

	public GameObject martillo;

	// condiciones de movimiento
	bool mover = false;
	bool moverRegreso = false;

	// rotacion del martillo
	Vector3 rot;
	Vector3 rotar = new Vector3 (45,0,0);
	Vector3 rotarRegreso = new Vector3 (0,0,0);

	void Update(){
		// ejecuta constantemente la funcion
		moverMartillo ();
	}

	// Si colisionan los colaider se activa la funcion para mover el martillo
	void OnCollisionEnter( Collision coll ) {
		activarMover ();
	}

	// activacion del martillo
	void activarMover(){
		mover = true;

	}

	void moverMartillo(){

		// inicia el martillo cuando se activa
		if (mover) {
			rot = Vector3.right;
			martillo.transform.Rotate (rot*Time.deltaTime * 80);
			if (martillo.transform.rotation.x *100 > rotar.x) {
				// Termina el movimiento y cambia moverRegreso a true para inicial el movimiento de regreso
				//a la posicion inicial
				mover = false;
				moverRegreso = true;
			}
		}

		// al llegar abajo vuelve hacia arriba
		if (moverRegreso) {	
			rot = Vector3.left;
			martillo.transform.Rotate (rot*Time.deltaTime * 30);
			// Finaliza el movimiento hasta la proxima colision
			if (martillo.transform.rotation.x *100 < rotarRegreso.x) {
				moverRegreso = false;
			}
		}
	}
}
