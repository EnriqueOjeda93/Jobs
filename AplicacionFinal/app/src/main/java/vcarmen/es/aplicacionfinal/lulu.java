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

public class lulu extends Fragment {

    String introducccion = "Es una mujer muy inteligente y con carácter. Vive desde pequeña en la isla Besaid junto a Yuna y Wakka" +
            " y es la guardiana de Yuna. Mantenía una relación con el hermano de Wakka, hasta que murió luchando contra Sinh.";

    String localizacion = "Arma de Lulu. Primero deberás conseguir el Símbolo y el Emblema de Marte, el símbolo está en el Etéreo en Guadosalam, para conseguir el emblema deberás esquivar 200 rayos seguidos en la Llanura de los Rayos, cuando lo hayas hecho dirígete a la Casa del Viajero, fuera verás un cofre que contiene varios objetos y por último el emblema.\n" +
            "\n" +
            "Para conseguir el arma, dirígete al Templo de Baaj, donde encuentras a Ánima, en el agua dirígete a unas ruinas con forma de túnel, ve pulsando el botón X mientras investigas por la parte de abajo y allí está el arma.\n" +
            "\n" +
            "Cuando lo tengas todo regresa donde obtuviste el espejo de los 7 astros y preséntale el arma 2 veces para que aumente su poder.";

    String caracteristicas = "Más daño cuantos más PM.\n" +
            "Consumo PM=1: El consumo de PM del personaje para acciones que lo requieran es solamente 1.\n" +
            "Magia+: Los hechizos del personaje son más poderosos pero gastan más PM.\n" +
            "Expansión de daño: El límite de daño es de 99999 para Lulu y para Shiva.\n" +
            "Turbo triple: El turbo sube 3 veces más rápido.";

    public static final String ARG_SECTION_TITLE = "opcion";


    public static lulu newInstance(String sectionTitle) {

        lulu fragment = new lulu();
        Bundle args = new Bundle();
        args.putString(ARG_SECTION_TITLE, sectionTitle);
        fragment.setArguments(args);
        return fragment;
    }

    public lulu() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.lulu, container, false);

        TextView titulo = (TextView) view.findViewById(R.id.contenido);
        titulo.setText(introducccion);

        TextView localiza = (TextView) view.findViewById(R.id.localizacion);
        localiza.setText(localizacion);

        TextView caract = (TextView) view.findViewById(R.id.caracteristicas);
        caract.setText(caracteristicas);

        return view;
    }

}