using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abuelete : MonoBehaviour {

	Animator anim;
	Text txt;
	GameObject texto;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		texto = GameObject.FindGameObjectWithTag ("textoAbuelo");
		txt = texto.GetComponent<Text> ();
		InvokeRepeating ("cambiarTexto" , 0f, 25f);
	}



	// Update is called once per frame
	void Update () {

		int estados = Random.Range (1, 900);

		if (estados == 13) {
			anim.SetBool ("bucle", false);
			anim.SetBool ("saludar", true);
			anim.SetBool ("movBig", false);
		} else if (estados == 34) {
			anim.SetBool ("bucle", false);
			anim.SetBool ("saludar", false);
			anim.SetBool ("movBig", true);
		} else{
			anim.SetBool ("bucle", true);
			anim.SetBool ("saludar", false);
			anim.SetBool ("movBig", false);
		}

	}

	void cambiarTexto(){

		int cambiar = Random.Range (1, 8);

		switch (cambiar)
		{
		case 1:
			txt.text = "¿ No hay algo raro en los pilares ?";
			break;
		case 2:
			txt.text = "Hola joven, me llamo Eulalio Soplarocas";
			break;
		case 3:
			txt.text = "Ten cuidado con ese gorila, parece enfadado";
			break;
		case 4:
			txt.text = "- Soy un tipo saludable\n- Ah. ¿Comes sano y todo eso?\n- No, la gente me saluda...";
			break;
		case 5:
			txt.text = "Cariño, creo que estás obsesionado con el fútbol y me haces falta.\n- ¡¿Qué falta?! ¡¡Si no te he tocado!!";
			break;
		case 6:
			txt.text = "Prueba a darle un botón delante de esos pilares";
			break;
		case 7:
			txt.text = "La mili? Pa mili la que hice yo en Cáceres";
			break;
		default:
			txt.text = "Mucha suerte colega";
			break;
		}
	}
}
