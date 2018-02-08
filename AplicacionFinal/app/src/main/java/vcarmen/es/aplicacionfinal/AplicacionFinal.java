package vcarmen.es.aplicacionfinal;


import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.design.widget.NavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.widget.DrawerLayout;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;

public class AplicacionFinal extends AppCompatActivity {

    private DrawerLayout drawerLayout;
    private NavigationView navView;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_aplicacion_final);
        drawerLayout = (DrawerLayout)findViewById(R.id.drawer_layout);
        navView = (NavigationView)findViewById(R.id.navigator);


        Fragment fragment = null;

        String title = "introduccion";
        Bundle args = new Bundle();
        fragment = new introduccion();
        args.putString(introduccion.ARG_SECTION_TITLE,  "introduccion");

        Fragment fragment0 = introduccion.newInstance(title);
        fragment.setArguments(args);

        getSupportFragmentManager().beginTransaction()
                .replace(R.id.contenido, fragment0)
                .commit();
        drawerLayout.closeDrawers();




        navView.setNavigationItemSelectedListener(
                new NavigationView.OnNavigationItemSelectedListener() {
                    @Override
                    public boolean onNavigationItemSelected(MenuItem menuItem) {
                        Fragment fragment = null;

                        String title = menuItem.getTitle().toString();
                        Bundle args = new Bundle();

                        switch (menuItem.getItemId()) {

                            case R.id.introduccion:
                                fragment = new introduccion();
                                args.putString(introduccion.ARG_SECTION_TITLE,  "introduccion");

                                Fragment fragment0 = introduccion.newInstance(title);
                                fragment.setArguments(args);

                                getSupportFragmentManager().beginTransaction()
                                        .replace(R.id.contenido, fragment0)
                                        .commit();
                                break;

                            case R.id.trailer:
                                fragment = new trailer();
                                args.putString(trailer.ARG_SECTION_TITLE,  "trailer");

                                Fragment fragment8 = trailer.newInstance(title);
                                fragment.setArguments(args);

                                getSupportFragmentManager().beginTransaction()
                                        .replace(R.id.contenido, fragment8)
                                        .commit();
                                break;

                            case R.id.tidus:
                                fragment = new tidus();
                                args.putString(tidus.ARG_SECTION_TITLE,  "tidus");

                                Fragment fragment1 = tidus.newInstance(title);
                                fragment.setArguments(args);

                                getSupportFragmentManager().beginTransaction()
                                        .replace(R.id.contenido, fragment1)
                                        .commit();
                                break;

                            case R.id.yuna:
                                fragment = new yuna();
                                args.putString(yuna.ARG_SECTION_TITLE,  "yuna");

                                Fragment fragment2 = yuna.newInstance(title);
                                fragment.setArguments(args);

                                getSupportFragmentManager().beginTransaction()
                                        .replace(R.id.contenido, fragment2)
                                        .commit();
                                break;

                            case R.id.wakka:
                                fragment = new wakka();
                                args.putString(wakka.ARG_SECTION_TITLE,  "wakka");

                                Fragment fragment3 = wakka.newInstance(title);
                                fragment.setArguments(args);
                                getSupportFragmentManager().beginTransaction()
                                        .replace(R.id.contenido, fragment3)
                                        .commit();
                                break;

                            case R.id.rikku:
                                fragment = new rikku();
                                args.putString(rikku.ARG_SECTION_TITLE,  "rikku");

                                Fragment fragment4 = rikku.newInstance(title);
                                fragment.setArguments(args);
                                getSupportFragmentManager().beginTransaction()
                                        .replace(R.id.contenido, fragment4)
                                        .commit();
                                break;

                            case R.id.lulu:
                                fragment = new lulu();
                                args.putString(lulu.ARG_SECTION_TITLE,  "lulu");

                                Fragment fragment5 = lulu.newInstance(title);
                                fragment.setArguments(args);
                                getSupportFragmentManager().beginTransaction()
                                        .replace(R.id.contenido, fragment5)
                                        .commit();
                                break;

                            case R.id.auron:
                                fragment = new auron();
                                args.putString(auron.ARG_SECTION_TITLE,  "auron");

                                Fragment fragment6 = auron.newInstance(title);
                                fragment.setArguments(args);
                                getSupportFragmentManager().beginTransaction()
                                        .replace(R.id.contenido, fragment6)
                                        .commit();
                                break;

                            case R.id.kimari:
                                fragment = new kimari();
                                args.putString(kimari.ARG_SECTION_TITLE,  "kimari");

                                Fragment fragment7 = kimari.newInstance(title);
                                fragment.setArguments(args);
                                getSupportFragmentManager().beginTransaction()
                                        .replace(R.id.contenido, fragment7)
                                        .commit();
                                break;
                        }

                        menuItem.setChecked(true);
                        getSupportActionBar().setTitle(menuItem.getTitle());
                        drawerLayout.closeDrawers();

                        return true;
                    }
                });
    }



    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.toolbar, menu);
        return super.onCreateOptionsMenu(menu);
    }


    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_edit:
                action(R.string.action_edit);
                return true;
            case R.id.action_settings:
                action(R.string.action_settings);
                return true;
            case R.id.action_about:
                action(R.string.action_about2);
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }


    private void action(int resid) {
        Toast.makeText(this, getText(resid), Toast.LENGTH_SHORT).show();
    }



}
