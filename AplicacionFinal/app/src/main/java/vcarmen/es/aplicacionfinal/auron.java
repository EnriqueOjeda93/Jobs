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

public class auron extends Fragment {
    String introducccion = "Es un hombre muy serio, de pocas palabras y con una gran fuerza. Fue un guardián legendario " +
            "que lucho al lado de Braska y Jecht y juntos consiguieron derrotar a Sinh, Auron ayuda a Tidus y a Yuna en su largo " +
            "viaje por una promesa que le hizo a Braska y Jecht de cuidar de sus hijos, cuando ellos murieran.";

    String localizacion = "Arma de Auron. Primero deberás obtener el Símbolo y el Emblema de Saturno, el símbolo está en uno de los cofres del Camino de Miihen, el emblema lo obtienes cuando hayas capturado todos los monstruos de 10 zonas diferentes de Spira, entonces el «Criamonstruos» te lo dará.\n" +
            "\n" +
            "Para obtener el arma, primero deberás ir al barranco donde está la Caverna del Orador Robado, pero en lugar de entrar en la cueva, dirígete a la derecha de la pantalla, hasta que no puedas continuar, allí encontrarás el Sable oxidado, después coge el barco volador y ve al Camino de Djose, súbete a los restos del arma usada por los albhed y llegarás a la Senda de las Rocas Hongo, allí busca una estatua, te pedirá que dejes el Sable Oxidado, y después aparecerá un símbolo en la pared y el arma será tuya.\n" +
            "\n" +
            "Cuando lo tengas todo, dirígete donde obtuviste el espejo de los 7 astros y presenta el arma 2 veces para que aumente su poder.";

    String caracteristicas = "Más daño cuando menos VIT tenga.\n" +
            "Expansión de daño: El límite de daño asciende hasta 99999 para Auron y para Yojimbo.\n" +
            "Turbo triple. La barra Turbo sube 3 veces más rápido\n" +
            "Iniciativa: Ataca antes que nadie.\n" +
            "Al recibir un ataque contraataca.";

    public static final String ARG_SECTION_TITLE = "opcion";


    public static auron newInstance(String sectionTitle) {

        auron fragment = new auron();
        Bundle args = new Bundle();
        args.putString(ARG_SECTION_TITLE, sectionTitle);
        fragment.setArguments(args);
        return fragment;
    }

    public auron() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.auron, container, false);

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