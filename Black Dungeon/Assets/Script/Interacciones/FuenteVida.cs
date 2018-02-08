using UnityEngine;
using System.Collections;

public class FuenteVida : MonoBehaviour
{
	// Condiciones de contacto con el collaider
	bool activado = true;
	bool entra = false;
	// Prefab del canvas
	public GameObject prefab;
	
	// Update is called once per frame
	void Update (){
		if(entra){
			float z = Input.GetAxis ("activar");
			if(z > 0){
				// Sube al maximo la vida del personaje solo una vez
				// variable del personaje
				AnimacionEsqueleto.variableVida = 100;
				activado = false;
			}
		}
	}

	// Collision de los collaiders
	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("esqueleto")) {
			// Instanciamos el canvas y la funcion del Update
			if(activado){
				Instantiate (prefab);
				entra = true;
			}
		}
	}

	void OnTriggerExit( Collider collision ) {
		if ( collision.CompareTag("esqueleto")) {
			GameObject prefab2 = GameObject.FindGameObjectWithTag ("UI");
			// Eliminamos el canvas y cancelamos la funcion del Update
			Destroy (prefab2);
			entra = false;
		}
	}
}

