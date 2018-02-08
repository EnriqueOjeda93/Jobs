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

public class tidus extends Fragment {
    String introducccion = "Es el protagonista del juego. Un chico alegre, estrella de los Zanarkand Abes y es conocido por ser el" +
            " hijo de Jecht (considerado el mejor jugador de Spira) del que siente un gran odio hacia el. Desde su llegada a Spira " +
            "1000 años después del ataque que sufrió Zanarkand, se une a Yuna y a sus guardianes para emprender un largo viaje para" +
            " librar a Spira de Sinh.";

    String localizacion = "Es el arma de Tidus. En la versión norteamericana se conoce como Caladbolg. Primero deberás conseguir el Símbolo y el Emblema del Sol. El Símbolo del Sol está en el mismo lugar donde peleas contra Yunalesca, cuando la derrotes vuelve a entrar hasta que aparezca un cofre con el símbolo, si tienes el Barco Volador te tendrás que enfrentar a Bahamut Oscuro para obtenerlo. Para obtener el emblema del Sol dirígete a la Llanura de la Calma, habla con la cuidadora de Chocobos y completa el minijuego «chocobo codicioso» con un récord insuperable, es decir de 0-0-0, no es imposible el truco es conseguir muchos globos sin que te golpeen demasiado y procura llegar antes de 36 segundos.\n" +
            "\n" +
            "Cuando hayas ganado a la cuidadora en este último minijuego aparecerá un hombre asombrado de que hayas ganado a la cuidadora, dirígete a la parte superior-izquierda de la llanura, allí habrá un pequeño camino que te lleva hasta un lugar donde hay un símbolo en la pared, tócalo y Arma Artema será tuya.\n" +
            "\n" +
            "Ahora dirígete hasta donde obtuviste el espejo de los 7 astros y preséntala el arma 2 veces para que obtenga todo su poder.";

    String caracteristicas = "Más daño cuanta más VIT tenga.\n" +
            "Expansión de daño: El límite de daño máximo asciende hasta 99999.\n" +
            "Turbo triple: El turbo aumenta 3 veces mas rápido.\n" +
            "Evade y ataca: Evade los ataques normales del enemigo y contraataca.\n" +
            "Contramagia: Cuando recibe un ataque mágico, contraataca.";

    public static final String ARG_SECTION_TITLE = "opcion";


    public static tidus newInstance(String sectionTitle) {
        tidus fragment = new tidus();
        Bundle args = new Bundle();
        args.putString(ARG_SECTION_TITLE, sectionTitle);
        fragment.setArguments(args);
        return fragment;
    }

    public tidus() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.tidus, container, false);

        TextView contenido = (TextView) view.findViewById(R.id.contenido);
        contenido.setText(introducccion);

        TextView localiza = (TextView) view.findViewById(R.id.localizacion);
        localiza.setText(localizacion);

        TextView caract = (TextView) view.findViewById(R.id.caracteristicas);
        caract.setText(caracteristicas);
        return view;
    }

}