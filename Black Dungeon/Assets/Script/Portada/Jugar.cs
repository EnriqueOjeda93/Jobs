using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Jugar : MonoBehaviour {

	// Accion cuando pulsamos jugar
	public void OnClick(){
		// Si ha habido final, tenemos que volver ha habilitar al personaje
		AnimacionEsqueleto.final = false;
		// Cada vez que empezamos, cargamos nuestra barra de vida a 100
		PlayerPrefs.SetFloat ("vida", 100);
		Invoke ("jugar", 2);

	}

	void jugar(){
		SceneManager.LoadScene( "Mazmorra" );
	}

}
