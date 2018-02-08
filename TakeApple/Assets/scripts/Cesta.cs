using UnityEngine;
using System.Collections;


public class Cesta : MonoBehaviour {
	// Este script pertenece a la cesta de la primera escena

	// Puntuacion
	GUIText scoreGT;
	// Posicion de la cesta
	Vector3 pos;
	// Calcula el tamaño de la pantalla para el limite de la cesta
	float limite;

	void Start () {
		GameObject scoreGO = GameObject.Find("Puntuacion");
		scoreGT = scoreGO.GetComponent<GUIText>();
		scoreGT.text = "0";

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

			// Cuando la puntuacion llega a 2000 carga la 2 escena
			if (score == 2000) {
				PlayerPrefs.SetInt ("segundoNivel", score);
				Application.LoadLevel( "juegoManzanasFase2" );
			}

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