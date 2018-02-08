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

public class introduccion extends Fragment {
    static String  title = "ARGUMENTO\n";
    String introducccion = "Mil años antes de los hechos de Final Fantasy X, se produjo una guerra entre las dos ciudades más" +
            " importantes que existían, Bevelle y Zanarkand: la guerra de las Maquinas, en la que Bevelle luchaba con artilugios " +
            "de gran potencia y Zanarkand se defendía de los ataques con invocadores. Mientras luchaban, apareció Sinh, un monstruo " +
            "horrible y abominable que lo destruyó todo. Después de la aparición de este ser, Zanarkand (que estaba siendo el campo " +
            "de batalla), quedó reducida a cenizas. Y por culpa de Sinh, Tidus se traslada en el tiempo y aparece mil años después en Spira." +
            "Final Fantasy X nos pone en la piel de Tidus, un joven alegre y carismático que vive en Zanarkand y que es la estrella del" +
            " Blitzball y juega en los Zanarkand Abes.\n\n\n Hasta que un día cuando se encontraba jugando un partido aparece un extraño ser que " +
            "destruye toda la ciudad, se hace llamar Sinh. En mitad del caos, aparece otro personaje, Auron, que ayuda a escapar a Tidus " +
            "introduciéndose en una esfera (como un vórtice), después de esto Tidus aparece en unas ruinas rodeado de escombros, y busca " +
            "comida y refugio dentro de un templo, donde es \"rescatada\" por una joven llamada Rikku y esta lo traslada a un barco, le " +
            "proporciona comida y le dice que Zanarkand fue destruida hace 1000 años por Sinh, y en ese momento aparece otra vez Sinh, " +
            "que ataca al barco y hace que Tidus se quede inconsciente en mitad del mar, después recobra el conocimiento cerca de una isla, " +
            "en la que conoce a Wakka, que también le dice que Zanarkand fue destruida hace 1000 años. Desde ese momento emprenderá una " +
            "aventura y deberá descubrir como regresar a Zanarkand y como librar al mundo de Sinh, el causante de todos los problemas.";
    String cont;
    public static final String ARG_SECTION_TITLE = "opcion";


    public static introduccion newInstance(String sectionTitle) {

        introduccion fragment = new introduccion();
        Bundle args = new Bundle();
        args.putString(ARG_SECTION_TITLE, sectionTitle);
        fragment.setArguments(args);
        return fragment;
    }

    public introduccion() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.introduccion, container, false);

        TextView titulo = (TextView) view.findViewById(R.id.introduccion2);
        TextView arg = (TextView) view.findViewById(R.id.argument);
        arg.setText(title);
        titulo.setText(introducccion);
        return view;
        //return inflater.inflate(R.layout.tidus, container, false);
    }

}