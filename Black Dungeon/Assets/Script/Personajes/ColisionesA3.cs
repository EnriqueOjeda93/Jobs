using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesA3 : MonoBehaviour {


	void OnTriggerEnter(Collider collision) {
		if ( collision.CompareTag("esqueleto")) {

			if(IA3.atacar == true){
				AnimacionEsqueleto.variableVida -= 8;
				AnimacionEsqueleto.daño = 1;
				IA3.atacar = false;
			}

			if(IA32.atacar == true){
				AnimacionEsqueleto.variableVida -= 8;
				AnimacionEsqueleto.daño = 1;
				IA32.atacar = false;
			}

			if(IA33.atacar == true){
				AnimacionEsqueleto.variableVida -= 8;
				AnimacionEsqueleto.daño = 1;
				IA33.atacar = false;
			}

			if(IA2.atacar == true){
				AnimacionEsqueleto.variableVida -= 4;
				AnimacionEsqueleto.daño = 1;
				IA3.atacar = false;
			}

			if(IA25.atacar == true){
				AnimacionEsqueleto.variableVida -= 4;
				AnimacionEsqueleto.daño = 1;
				IA25.atacar = false;
			}

			if(IA22.atacar == true){
				AnimacionEsqueleto.variableVida -= 4;
				AnimacionEsqueleto.daño = 1;
				IA22.atacar = false;
			}

			if(IA23.atacar == true){
				AnimacionEsqueleto.variableVida -= 4;
				AnimacionEsqueleto.daño = 1;
				IA23.atacar = false;
			}

			if(IA24.atacar == true){
				AnimacionEsqueleto.variableVida -= 4;
				AnimacionEsqueleto.daño = 1;
				IA24.atacar = false;
			}

			if(IA.atacar == true){
				AnimacionEsqueleto.variableVida -= 15;
				AnimacionEsqueleto.daño = 1;
				IA.atacar = false;
			}
		}
	}


}
