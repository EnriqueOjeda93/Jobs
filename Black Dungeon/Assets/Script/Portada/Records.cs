using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Records : MonoBehaviour {

	Text txt;
	float recordMAx;

	// Use this for initialization
	void Start () {
		Final.contadorRecord = Time.time;
		recordMAx = PlayerPrefs.GetFloat ("recordMax");
		if (recordMAx == 9999999999) {
			txt = gameObject.GetComponent<Text> ();
			txt.text = "Tiempo Record Actual : - Puntos";
		} else {
			txt = gameObject.GetComponent<Text> ();
			txt.text = "Tiempo Record Actual : " + PlayerPrefs.GetFloat ("recordMax") + " Puntos";
		}
	}

}
