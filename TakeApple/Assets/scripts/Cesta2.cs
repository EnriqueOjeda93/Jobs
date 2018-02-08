using UnityEngine;
using System.Collections;


public class Cesta2 : MonoBehaviour {
	// Este script pertenece al coche de la segunda escena

	// Puntuacion
	GUIText scoreGT;
	// Posicion de la cesta
	Vector3 pos;
	// Calcula el tamaño de la pantalla para el limite de la cesta
	float limite;

	void Start () {
		GameObject scoreGO = GameObject.Find("Puntuacion");
		scoreGT = scoreGO.GetComponent<GUIText>();
		scoreGT.text = PlayerPrefs.GetInt ("segundoNivel").ToString();

		// Calculamos el limite y ajustamos el tamaño
		limite = CalculaLimite ();
		limite = limite + 1f;
	}

	void Update () {
		Vector3 mousePos2D = Input.mousePosition;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
		pos = this.transform.position;
		pos.x = Mathf.Clamp(mousePos3D.x, limite, -limite);

		this.transform.position = pos;


	}
	void OnCollisionEnter( Collision coll ) {

		// Si una manzana colisiona con la cesta
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Manzanas") {
			Destroy (collidedWith);
			int score = int.Parse (scoreGT.text);
			score += 100;
			scoreGT.text = score.ToString ();

			//Si el score es mayor que el record lo actualiza y guarda
			Record.score = score;
			int maxScore = PlayerPrefs.GetInt ("puntos");
			if (score > maxScore) {
				PlayerPrefs.SetInt ("puntos", score);
			}
		
		// Cuando se destruyen todas las cestas vuelve a la interfaz
		} else {
			Destroy (collidedWith);
			Application.LoadLevel( "interfazManzanas" );
		}
	}

	// Metodo que calcula el limite
	float CalculaLimite(){
		Vector3 limite = Camera.main.ScreenToWorldPoint (new Vector3(0,0,0));
		return limite.x;
	}
}