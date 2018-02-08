using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	// LOS SCRIPTS NO ESPECIFICADOS PERTENECEN A LAS DOS ESCENAS
	// ES DECIR, UTILIZAMOS COMO GLOBALES EN TODO EL JUEGO

	// Prefab de la cesta y sus caracteristicas
	public GameObject basketPrefab;

	// Numero de cestas
	public int numBaskets = 3;
	// Dimensiones
	public float basketBottomY = -4f;
	public float basketSpacingY = 0.5f;
	public List<GameObject> basketList;
	GameObject tBasketGO;


	Vector3 manzana;

	// Prefab del pajaro
	public GameObject prefabPajaro;
	// Cuando se instancia el pajaro
	float inicio = 1f;
	// Cada cuanto sale un pajaro
	float repeticion = 4f;
	// Velocidad del pajaro
	Vector3 velocidadPajaro = new Vector3 (6, 0, 0);

	// Prefab de la bala
	public GameObject prefBala;


	void Start () {
		basketList = new List<GameObject>();
		for (int i=0; i<numBaskets; i++) {
			 tBasketGO = Instantiate( basketPrefab ) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + ( basketSpacingY * i );
			tBasketGO.transform.position = pos;
			basketList.Add( tBasketGO );
			manzana.y = -15;
		}

		// Metodo para invocar pajaros en cierto tiempo
		InvokeRepeating ("crearPajaro", inicio, repeticion);
	}

	// Metodo que destruye una manzana o hierva cuando no cae en la cesta
	public void AppleDestroyed() {
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag ("Manzanas");
		foreach (GameObject tGO in tAppleArray) {	
			Destroy (tGO);

		}

		// Eliminamos una cesta cuando fallamos
		int basketIndex = basketList.Count-1;
		GameObject tBasketGO = basketList[basketIndex];
		basketList.RemoveAt( basketIndex );
		Destroy( tBasketGO );

		// Si no hay mas cestas se acaba el juego
		if ( basketList.Count == 0 ) {
			Application.LoadLevel( "interfazManzanas" );
		}
			
	}


	// Metodo para crear pajaros
	void crearPajaro(){
		// Posicion aleatoria en Y
		int lugarInicioY = Random.Range (-2,3);
		// Posicion fija en X
		int lugarInicioX = -14;

		// Creacion del pajaro
		Vector3 intanciandoPajaro = new Vector3 (lugarInicioX, lugarInicioY, 0);
		GameObject pajaro = Instantiate(prefabPajaro, intanciandoPajaro, Quaternion.identity);
		pajaro.GetComponent<Rigidbody> ().velocity = velocidadPajaro;

	}


	void Update	(){
		Fire ();
	}

	// Metodo de disparo cuando se pulsa el raton
	void Fire(){
		if (Input.GetMouseButtonDown (0)) {
			GameObject gusano = Instantiate (prefBala, basketList [0].transform.position, Quaternion.identity);
		}

	}


}
