package vcarmen.es.aplicacionfinal;

import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

/**
 * Created by Usuario on 30/05/2017.
 */

public class kimari extends Fragment {
    String introducccion = "Es un miembro de la tribu Ronso y no es muy respetado por ellos ya que tiene el cuerno partido. Kimahri es " +
            "un guardián de Yuna y solo habla cuando es necesario y protege a Yuna en todo momento ya que Auron después de conocer a " +
            "Kimahri en Bevelle le pidió que cuidara de ella.";

    String localizacion = "Arma de Kimahri. Primero deberás obtener el Símbolo y el Emblema de Júpiter, el símbolo está en el Monte Gagazet en el camino de las columnas antes de entrar en la cueva, el cofre que lo contiene está entre dos columnas, el emblema lo consigues cuando ganas el juego de las mariposas en el bosque de Macalania, deberás ganar en las dos zonas para obtener el emblema.\n" +
            "\n" +
            "Para obtener el arma, dirígete a la Llanura de los Rayos, cuando veas que uno de los monolitos que tienen pintado un Cactilio brilla, dirígete a él y pulsa el botón cuadrado, hazlo tres veces, luego vete a la parte sur de la llanura, allí verás un cactilio fantasma que te seguirá, debes llevarlo a una torre abandonada en el lado derecho, cuando llegues pulsa cuadrado y el arma será tuya.\n" +
            "\n" +
            "Cuando lo tengas todo, dirígete donde obtuviste el espejo de los 7 astros y presenta el arma 2 veces para que aumente su poder.";

    String caracteristicas = "Más daño cuanta más VIT tenga.\n" +
            "PHx2: Gana el doble de PH en las batallas.\n" +
            "Expansión de daño: El límite de daño aumenta hasta 99999 para Kimahri y para Ixion.\n" +
            "Turbo triple: El turbo aumenta 3 veces más rápido.\n" +
            "Evade y ataca: Al recibir algún ataque lo evade y contraataca.";

    public static final String ARG_SECTION_TITLE = "opcion";


    public static kimari newInstance(String sectionTitle) {
        kimari fragment = new kimari();
        Bundle args = new Bundle();
        args.putString(ARG_SECTION_TITLE, sectionTitle);
        fragment.setArguments(args);
        return fragment;
    }

    public kimari() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.kimari, container, false);
        TextView titulo = (TextView) view.findViewById(R.id.contenido);
        titulo.setText(introducccion);

        TextView localiza = (TextView) view.findViewById(R.id.localizacion);
        localiza.setText(localizacion);

        TextView caract = (TextView) view.findViewById(R.id.caracteristicas);
        caract.setText(caracteristicas);

        return view;
    }

}
