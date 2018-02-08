using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparencias : MonoBehaviour {

	// Prefabs
	public GameObject ojos;
	public GameObject puerta;

	// Movimiento de los ojos y puerta
	Vector3 posP = new Vector3 (0.0f, 0f, 0.025f);
	Vector3 posR = new Vector3 (0.0f,-1f,0f);
	private float tiempo;


	// Use this for initialization
	void Start () {
		// Calculamos el tiempo que pasa desde que se inicia el game
		tiempo = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		// Los esqueletos siguen un patron movimiento del ojo que cada x segundos hacen el giro
		// La formula para hacer que siempre hagan el mismo efecto es:
		// Time.time nos da x segundo que es donde parte "tiempo"
		// sumandole los segundos es como si Time.time partiera de 0 hasta
		// los segundo que se les ha sumado, haciendo que este efecto se produzca siempre
		if(Time.time > tiempo+18 && Time.time < tiempo+20){
			
			ojos.transform.position += posP;
			puerta.transform.Rotate (posR);
		}

	}
}
