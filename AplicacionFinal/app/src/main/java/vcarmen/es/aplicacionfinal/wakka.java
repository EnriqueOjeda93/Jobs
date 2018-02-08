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

public class wakka extends Fragment {
    String introducccion = "Es el capitán de los Besaids Aurochs y el guardián de Yuna. Vive en la isla Besaid junto a Yuna y Lulu" +
            " desde pequeño. Tiene un gran rencor a la gente de la raza Albhed, porque su hermano Chappu murió a manos de Sinh, " +
            "y según él por culpa de ellos y de las máquinas apareció Sinh.";

    String localizacion = "Arma de Wakka. Primero deberás conseguir el Símbolo y el Emblema de Mercurio, el símbolo está en una de las taquillas del vestuario donde están los Besaid Aurochs, para conseguir el emblema deberás tener todos los turbos de Wakka,El primer turbo (ruleta de chutes) se obtiene en la copa Yevon la primera vez que juegas, el emblema aparecerá como premio en una liga de Blitzbol así que procura tener al equipo entrenado.\n" +
            "\n" +
            "Para obtener el arma, dirígete al bar de Luca y muéstrele el espejo de los 7 astros al dependiente del bar, tras haber quedado como mínimo tercero en la Liga o en una copa Yevon o lograr más de 100 victorias.\n" +
            "\n" +
            "Cuando lo tengas todo, dirígete al lugar donde obtuviste el Espejo de los 7 astros y preséntale el arma 2 veces para que aumente su poder.";

    String caracteristicas = "Más daño cuanta más Vit tenga.\n" +
            "Expansión de daño: El límite de daño aumenta hasta 99999 para Wakka y para Ifrit.\n" +
            "Turbo triple: La barra de Turbo sube 3 veces más rápido.\n" +
            "PHx2: Recibes el doble de PH.\n" +
            "Evade y ataca: Al recibir un ataque, lo esquiva y contraataca.";

    public static final String ARG_SECTION_TITLE = "opcion";


    public static wakka newInstance(String sectionTitle) {

        wakka fragment = new wakka();
        Bundle args = new Bundle();
        args.putString(ARG_SECTION_TITLE, sectionTitle);
        fragment.setArguments(args);
        return fragment;
    }

    public wakka() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.wakka, container, false);

        TextView titulo = (TextView) view.findViewById(R.id.contenido);
        titulo.setText(introducccion);

        TextView localiza = (TextView) view.findViewById(R.id.localizacion);
        localiza.setText(localizacion);

        TextView caract = (TextView) view.findViewById(R.id.caracteristicas);
        caract.setText(caracteristicas);
        return view;
    }

}