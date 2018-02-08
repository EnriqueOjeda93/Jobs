using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class interfaz : MonoBehaviour {

	// Cargamos la escena del juego cuando se pulsa en "Jugar"
	public void OnClick(){
		SceneManager.LoadScene( "juegoManzanas" );
	}

}
