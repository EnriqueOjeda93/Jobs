package vcarmen.es.aplicacionfinal;

/**
 * Created by Usuario on 16/05/2017.
 */

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

public class rikku extends Fragment {
    String introducccion = "Es una chica muy alegre y jovial de la raza Albhed. Es la primera que conoce a Tidus, pero por culpa de" +
            " un ataque de Sinh separan hasta que se vuelven a reencontrar en el Río de la luna. Tambien es prima y guardiana de " +
            "Yuna e intenta protegerla en todo momento.";

    String localizacion = "Arma de Rikku. Primero deberás obtener el Símbolo y el Emblema de Venus, el símbolo está en la pantalla donde se encuentra la tormenta de arena que oculta el poblado cactilio, antes de llegar al Hogar, para conseguir el emblema hay que completar el minijuego de los cactilios para ello busca un monolito con un dibujo de un cactilio, deberás localizar a los 10 guardianes de la arena, ellos están:\n" +
            "\n" +
            "En el Oasis\n" +
            "Corriendo al Norte de la pantalla donde hay una Esfera del Viajero debajo de una tienda.\n" +
            "En la pantalla donde debes llevar las esferas de los cactilios revisa los carteles.\n" +
            "El 4 y el 5 juntos, corriendo en las ruinas de la izquierda de la pantalla anterior a la que está el monolito.\n" +
            "Vete a la Esfera del Viajero que está debajo de una tienda.\n" +
            "Escondido en un cofre en la pantalla donde están las ruinas a la izquierda, un consejo no importa si pierdes a este dedícate a coger los objetos de los cofres.\n" +
            "Corriendo en un hoyo en la pantalla del monolito, pero deberás salir a otra pantalla y volver para encontrarlo, un consejo para ganarle métete en el hoyo y camina recto hasta que salgas por el otro.\n" +
            "Examina el Oasis y vete a la Esfera del Viajero que está allí, verás al cactilio subiéndose a la nave, vete hasta la cubierta y allí está.\n" +
            "Después de colocar la última esfera aparecerá por detrás.\n" +
            "Cuando hayas completado el minijuego, la tormenta de arena se disipa y puedes entrar en el poblado y coger el emblema.\n" +
            "\n" +
            "Para conseguir el arma, vete al barco volador y habla con Cid, vete a Contraseña y escribe MANODEDIOS, vete al lugar que aparece y el arma es tuya.\n" +
            "\n" +
            "Una vez lo tengas todo, regresa donde obtienes el espejo de los 7 astros y presenta el arma 2 veces para que aumente su poder.";

    String caracteristicas = "Más daño cuanto más VIT tengas.\n" +
            "Turbo triple: La barra de Turbo sube 3 veces más rápido\n" +
            "Expansión de daño: El límite de daño asciende hasta 99999 para Rikku.\n" +
            "PH x 2: Doble de PH.\n" +
            "Guiles x 2: Doble de Guiles.";

    public static final String ARG_SECTION_TITLE = "opcion";


    public static rikku newInstance(String sectionTitle) {

        rikku fragment = new rikku();
        Bundle args = new Bundle();
        args.putString(ARG_SECTION_TITLE, sectionTitle);
        fragment.setArguments(args);
        return fragment;
    }

    public rikku() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.rikku, container, false);
        TextView titulo = (TextView) view.findViewById(R.id.contenido);
        titulo.setText(introducccion);

        TextView localiza = (TextView) view.findViewById(R.id.localizacion);
        localiza.setText(localizacion);

        TextView caract = (TextView) view.findViewById(R.id.caracteristicas);
        caract.setText(caracteristicas);

        return view;
        //return inflater.inflate(R.layout.tidus, container, false);
    }

}