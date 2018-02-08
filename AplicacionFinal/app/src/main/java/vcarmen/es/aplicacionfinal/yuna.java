package vcarmen.es.aplicacionfinal;

/**
 * Created by Usuario on 16/05/2017.
 */

import android.media.MediaPlayer;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

public class yuna extends Fragment {
    String introducccion = "Es una chica muy tímida y honesta que vive " +
            "junto a Lulu y a Wakka en la isla Besaid y es aprendiz de invocadora. Emprende un largo viaje junto a sus " +
            "guardianes para derrotar a Sinh y es conocida por ser la hija del gran invocador Braska, que devolvió la paz a Spira " +
            "derrotando a Sinh junto a sus guardianes Jecht y Auron.";

    String localizacion = "Arma de Yuna. Primero deberás obtener el Símbolo y el Emblema de la Luna, el símbolo es muy fácil de conseguir, está en la playa de Besaid nadando hacia la derecha, el emblema de la Luna te lo da Belgemine (en el Templo de Remiem), cuando consigas a las Hermanas Magus habla con ella y que invoque a las Hermanas Magus, derrótalas y conseguirás el emblema antes de enviar a Belgemine al Etéreo.\n" +
            "\n" +
            "Para conseguir el arma, dirígete a la parte derecha de la Llanura de la Calma, allí verás un camino que te lleva hasta un criador de monstruos, te pedirá que le captures a las 9 especies de monstruos que viven en la llanura, cuando los captures te dará el arma.\n" +
            "\n" +
            "Cuando ya tengas todo dirígete al lugar donde obtuviste el espejo de los 7 astros y preséntale Nirvana 2 veces para que el arma alcance todo su poder.";

    String caracteristicas = "Más daño con más PM tenga.\n" +
            "PHx2: Gana el doble de PH en las batallas.\n" +
            "Expansión de daño: Su límite de daño máximo asciende a 99999 tanto par ella como para Valefor.\n" +
            "Turbo triple: El turbo aumenta 3 veces más rápido.\n" +
            "Consumo PM=1: Cualquier hechizo solo te costará 1 PM.";

    public static final String ARG_SECTION_TITLE = "opcion";


    public static yuna newInstance(String sectionTitle) {

        yuna fragment = new yuna();
        Bundle args = new Bundle();
        args.putString(ARG_SECTION_TITLE, sectionTitle);
        fragment.setArguments(args);
        return fragment;
    }

    public yuna() {
    }



    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.yuna, container, false);

        TextView descripcion = (TextView) view.findViewById(R.id.contenido);
        descripcion.setText(introducccion);

        TextView localiza = (TextView) view.findViewById(R.id.localizacion);
        localiza.setText(localizacion);

        TextView caract = (TextView) view.findViewById(R.id.caracteristicas);
        caract.setText(caracteristicas);


        return view;
    }

}