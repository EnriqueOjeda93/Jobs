using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimacionEsqueleto : MonoBehaviour {

	Animator anim;

	// truco de pared 
	public GameObject paredSecreta;
	bool pared = true;

	// Final
	public static bool final = false;
	public static Vector3 caidaAgua;

	// vidas
	public GameObject texto;

	// variables del movimientos del esqueleto
	public float velocidadAndar=8;
	public float velocidadCorrer=20;
	public float velocidadGiro=110;
	private float velocidad = 0;
	public static float atacar = 0;
	private float skills = 0;
	Vector3 movimiento;
	Vector3 giro;


	// vidas esqueleto y ia
	public static float variableMuerte;   // Utilizada en animacion morir y restrinfir movimientos
	public static float vidaIA;
	public static float daño = 0;
	public Slider vida;
	public static float variableVida; // Vida del personaje


	// Condicionales y prefab canvas y pieza
	bool pulsado = false;
	public GameObject prefab;
	public GameObject pieza;
	bool piezaInstanciada = true;

	bool activador1 = true;
	bool activador2 = true;
	bool activador3 = true;

	// Audios
	public AudioClip golpe;
	public AudioClip roar;
	public AudioClip audioDie;
	bool reprod = true;

	// Use this for initialization
	void Start () {
		// inicializamos aqui para cuando se carge la escena se vuelvan a cargar
		variableMuerte = 0;
		anim = GetComponent<Animator> ();

		// Recogemos la vida guardada( 100 desde inicio y la ultima cargada en la primera parte)
		//variableVida = PlayerPrefs.GetFloat ("vida");
		variableVida = 10;

		caidaAgua = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		// Para que en cada escena se guarde la vida, la vamos guardando gradualmente
		// y en la funcion Start(), le asignamos la vida guardada,
		// que cuando carge de inicio sea 100, y en la segunda parte la ultima registrada aqui
		vida.value = variableVida;

		PlayerPrefs.SetFloat ("vida", vida.value);

		// animaciones y moviemiento del esqueleto, variableMuerte = si la vida llega a 0
		// final = cuando accedemos al barco para el final
		if (variableMuerte == 0 && final == false) {
			float v = Input.GetAxis ("Vertical");
			float h = Input.GetAxis ("Horizontal");
			float c = Input.GetAxis ("Correr");
			float a = Input.GetAxis ("Fire1");
			float s = Input.GetAxis ("skill");
			if (daño == 0) {
				velocidad = v;
				if (v > 0 || v < 0) {
						
					if (c > 0 && v > 0) {
						velocidad += c;
						movimiento = Vector3.forward * (c) * Time.deltaTime * velocidadCorrer;
					} else {
						movimiento = Vector3.forward * v * Time.deltaTime * velocidadAndar;

					}

				} else {
					if (s > 0) {
						if (reprod) {
							Invoke ("reproducirAudioRoar", 0);
						}
						skills = 1;
						movimiento = Vector3.zero;
						giro = Vector3.zero;
					} else {
						skills = 0;
					}

					movimiento = Vector3.zero;
				}

				if (a > 0) {
					if (reprod) {
						Invoke("reproducirAudioGolpe", 0);
					}
					atacar = 1;
					movimiento = Vector3.zero;
					giro = Vector3.zero;

				} else {
					atacar = 0;
				}
			}
			anim.SetFloat ("daño", daño);
			daño = 0;

			giro = new Vector3 (0, h * Time.deltaTime * velocidadGiro, 0);
			transform.Translate (movimiento);
			transform.Rotate (giro);


			//animacion
			anim.SetFloat ("velocidad", velocidad);
			anim.SetFloat ("atacar", atacar);	
			anim.SetFloat ("skill", skills);

		} 

		// Se ejecuta cuando muere el personaje
		if (final == true) {
			anim.SetFloat ("velocidad", 0);
			anim.SetFloat ("atacar", 0);	
			anim.SetFloat ("skill", 0);
		}

		// Se ejecuta cuando muere el personaje
		if (variableVida <= 0) {
			if (variableMuerte == 0) {
				transform.GetComponent<AudioSource>().PlayOneShot(audioDie);
			}
			variableMuerte = 1;
			anim.SetFloat ("morir", 1);
			Invoke("VolverInicio", 6);
		}


		// Funcion que instancia la puezza dentro del puzzle
		if (pulsado) {
			if (piezaInstanciada) {
				float z = Input.GetAxis ("activar");
				if (z > 0) {
					Instantiate (pieza);
					Puzzle.piezaEncontrada = true;
					piezaInstanciada = false;
				}
			}
		}


	}

	void reproducirAudioRoar(){
		transform.GetComponent<AudioSource>().PlayOneShot(roar);
		reprod = false;
		Invoke ("esperaAudios", 1.9f);
	}

	void reproducirAudioGolpe(){
		transform.GetComponent<AudioSource>().PlayOneShot(golpe);
		reprod = false;
		Invoke ("esperaAudios", 0.95f);
	}
		
	void esperaAudios(){
		reprod = true;
	}

	void DestruirPared(){
		Destroy (paredSecreta);
	}

	// al moriri vualves al inicio
	void VolverInicio(){
		Application.LoadLevel( "Inicio" );
	}



	// diferentes acciones con distintas colisiones
	void OnCollisionEnter( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.tag == "paredsecreta" && pared) {
			Invoke("DestruirPared", 3);
		}

		// VIDA
		if ( collidedWith.tag == "huesito") {
			Destroy (collidedWith);
			variableVida = variableVida + 25;
		}

		// DAÑO
		if(collidedWith.tag == "TrStandar"){
			daño = 1;
			variableVida -= 20;
		}

		if(collidedWith.tag == "TrLowHP"){
			daño = 1;
			variableVida -= 10;
		}

		if(collidedWith.tag == "TrHardHP"){
			daño = 1;
			variableVida -= 30;
		}

		if(collidedWith.tag == "TrPorcHP"){
			InvokeRepeating ("decrecimientoVida", 0, 1.3F);
		}

		if(collidedWith.tag == "TrDie"){
			daño = 1;
			variableVida = 0;
		}

	}

	void decrecimientoVida(){
		variableVida -= 2;
	}

	void OnCollisionExit(Collision collisionInfo) {
		GameObject collidedWith = collisionInfo.gameObject;

		if(collidedWith.tag == "TrPorcHP"){
			CancelInvoke ();
		}

		if(collidedWith.tag == "piezza"){
			Destroy (prefab);
			pulsado = false;
		}
	}

	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("piezza")) {
			Instantiate (prefab);
			pulsado = true;

		}
	}

	void OnTriggerStay(Collider collision) {
		if(collision.CompareTag("activador1") && Input.GetAxis ("activar") == 1){
			if (activador1){
				Activadores.activador +=1;
				activador1 = false;
			}
		}

		if(collision.CompareTag("activador2") && Input.GetAxis ("activar") == 1){
			if (activador2){
				Activadores.activador +=1;
				activador2 = false;
			}
		}

		if(collision.CompareTag("activador3") && Input.GetAxis ("activar") == 1){
			if (activador3){
				Activadores.activador +=1;
				activador3 = false;
			}
		}
	}

	void OnTriggerExit( Collider collision ) {
		GameObject prefab2 = GameObject.FindGameObjectWithTag ("UI");
		Destroy (prefab2);
	}
}
