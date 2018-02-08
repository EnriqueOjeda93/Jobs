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


public class trailer extends Fragment{
    public static final String ARG_SECTION_TITLE = "opcion";


    public static trailer newInstance(String sectionTitle) {

        trailer fragment = new trailer();
        Bundle args = new Bundle();
        args.putString(ARG_SECTION_TITLE, sectionTitle);
        fragment.setArguments(args);
        return fragment;
    }

    public trailer() {
    }


    MediaPlayer mp;
    Button play;
    Button siquiente;
    Button atras;
    Button stop;
    int i = 0;
    TextView musica;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View view = inflater.inflate(R.layout.trailer, container, false);


        play = (Button) view.findViewById(R.id.play);
        siquiente = (Button) view.findViewById(R.id.siguiente);
        atras = (Button) view.findViewById(R.id.atras);
        stop = (Button) view.findViewById(R.id.stop);
        musica = (TextView) view.findViewById(R.id.cancion);

        play.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                siquiente.setEnabled(true);
                atras.setEnabled(true);
                stop.setEnabled(true);
                cambiarMusica();

            }
        });

        siquiente.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                mp.stop();
                i++;
                if(i>3){
                    i = 0;
                }
                cambiarMusica();

            }
        });

        atras.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                mp.stop();
                i--;
                if(i<0){
                    i = 3;
                }
                cambiarMusica();
            }
        });


        stop.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                mp.stop();
            }
        });

      return view;
    }


    public void cambiarMusica(){
        switch (i) {
            case 0:
                musica.setText("Reproduciendo en este momento: Real Emotion (FFX-2)");
                mp = MediaPlayer.create(getContext(), R.raw.emotion);
                mp.start();
                break;
            case 1:
                musica.setText("Reproduciendo en este momento: 1000 Worlds - Yuna and Lenne (FFX-2)");
                mp = MediaPlayer.create(getContext(), R.raw.milworld);
                mp.start();
                break;
            case 2:
                musica.setText("Reproduciendo en este momento: To Zanarkand");
                mp = MediaPlayer.create(getContext(), R.raw.zanarkand);
                mp.start();
                break;
            case 3:
                musica.setText("Reproduciendo en este momento: Suketi Da Ne");
                mp = MediaPlayer.create(getContext(), R.raw.suketidane);
                mp.start();
                break;
            default:
                break;
        }
    }
}
