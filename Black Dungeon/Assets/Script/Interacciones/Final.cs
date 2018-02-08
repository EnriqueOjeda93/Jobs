using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {


	// Prefabs de las camaras
	public Camera camaraP;
	public Camera camaraFinal;

	// Prefabs del canvas y esqueleto
	public GameObject prefab;
	public GameObject esqueleto;

	// Movimientos del barco y camara
	Vector3 movBarco = new Vector3 (0.02f,0f,-0.1f);
	Vector3 movCam = new Vector3 (0.0f,0.05f,-0.15f);

	// Variable que activa el final
	bool final = false;
	bool entra = false; 

	float record;
	public static float contadorRecord;

	void Start(){
		//Indicamos la camara activa
		camaraP.enabled = true;
		camaraFinal.enabled = false;
	}

	void Update () {
		if (entra) {
			// Cuando accedemos al barco y pulsamos se ejecuta el final
			float z = Input.GetAxis ("activar");
			if (z > 0) {
				final = true;
				record = PlayerPrefs.GetFloat ("recordMax");
				if ((Time.time - contadorRecord) < record){
					PlayerPrefs.SetFloat ("recordMax", Mathf.RoundToInt(Time.time - contadorRecord));
				}
			}
		}

		// Utilizamos la misma funcion de las plataformas, añadiendo
		// el movimiento del barco al del esqueleto
		if(final){
			Invoke ("VolverInicio", 15);
			Invoke ("DeleteCanvas", 0);
			// variable que anula el movimiento del personaje
			AnimacionEsqueleto.final = true;
			// Cambiamos de camara a la final
			camaraP.enabled = false;
			camaraFinal.enabled = true;


			Vector3 pos = transform.position;
			Vector3 posCamara = camaraFinal.transform.position;

			pos += movBarco;
			posCamara += movCam;

			transform.position = pos;
			esqueleto.transform.position = pos;
			camaraFinal.transform.position = posCamara;
		}
	}

	// Collision del barco y el personaje
	void OnCollisionEnter( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.CompareTag("esqueleto")) {
			Instantiate (prefab);
			entra = true;
		}
	}

	void OnCollisionExit( Collision coll ) {
		GameObject prefab2 = GameObject.FindGameObjectWithTag ("UI");
		Destroy (prefab2);
		entra = false;

	}

	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("esqueleto")) {
			esqueleto.transform.position = transform.position;

		}
	}


	// Volver a inicio
	void DeleteCanvas(){
		GameObject prefab2 = GameObject.FindGameObjectWithTag ("UI");
		Destroy (prefab2);
	}

	// Volver a inicio
	void VolverInicio(){
		SceneManager.LoadScene( "Inicio" );
	}
}