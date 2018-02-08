using UnityEngine;
using System.Collections;

public class Record : MonoBehaviour {

	// Puntuacion Record
	static public int score ;

	// Script inician cuando cargas si existe un recor anterior
	void Start () {
		
		GUIText gt = this.GetComponent<GUIText>();
		score = PlayerPrefs.GetInt ("puntos");

		// Si hay record anterior lo carga, sino lo instancia a 0
		if (score != 0) {
			gt.text = "Record: " + score;
		} else {
			gt.text = "Record: " + 0;
		}
	}



}
