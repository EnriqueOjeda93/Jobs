using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAportda : MonoBehaviour {

	Animator anim;

	// variables del esqueleto
	Vector3 movimiento;
	Vector3 giro;
	private float mover;
	public float giros;
	public float tiempoGiro;
	public bool grito;
	private float skill = 0;
	private float tiempo;

	// Use this for initialization
	void Start () {
		// Animacion de los esqueletos
		anim = GetComponent<Animator> ();
		tiempo = Time.time;
	}

	// Update is called once per frame
	void Update () {
		
		movimiento = Vector3.forward * Time.deltaTime * mover;	
		transform.Translate (movimiento);

		// Los esqueletos siguen un patron de giro que cada x segundos hacen el giro
		// La formula para hacer que siempre hagan el mismo efecto es:
		// Time.time nos da x segundo que es donde parte "tiempo"
		// sumandole los segundos es como si Time.time partiera de 0 hasta
		// los segundo que se les ha sumado, haciendo que este efecto se produzca siempre
		if (Time.time > tiempoGiro+tiempo && Time.time < tiempoGiro+1+tiempo) {
			giro = new Vector3 (0, 1.2f * Time.deltaTime * giros, 0);
			transform.Rotate (giro);
		}

		mover = 1;

		// Sigue el mismo patron de antes
		// Animacion de grito
		if (grito == true) {
			if (Time.time > 9+tiempo && Time.time < 10+tiempo) {
				skill = 1;
				mover = 0;
			} else {
				skill = 0;
			}
		}

		//animacion
		anim.SetFloat ("velocidad", mover);
		anim.SetFloat ("skill", skill);
		// a los 25 segundos de la animacion paramos a los esqueletos
		// fuera de la pantalla
		Invoke("parar", 25);
	}
		
	void parar(){
		mover = 0;
	}
}
