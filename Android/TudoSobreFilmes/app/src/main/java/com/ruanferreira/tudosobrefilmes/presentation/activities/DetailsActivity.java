package com.ruanferreira.tudosobrefilmes.presentation.activities;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.bumptech.glide.Glide;
import com.bumptech.glide.load.engine.DiskCacheStrategy;
import com.ruanferreira.tudosobrefilmes.R;
import com.ruanferreira.tudosobrefilmes.model.ConfigurationImage;
import com.ruanferreira.tudosobrefilmes.model.Movie;
import com.ruanferreira.tudosobrefilmes.presentation.dao.DataBaseManager;
import com.ruanferreira.tudosobrefilmes.presentation.services.APIFilm;
import com.ruanferreira.tudosobrefilmes.presentation.services.APIInterface;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * Created by ruanf on 02/04/2017.
 */

/**
 * Classe responsável por exibir os detalhes dos filmes selecionados na tela de pesquisa
 * e também por favoritar o filme
 */
public class DetailsActivity extends AppCompatActivity {

    //Propriedades
    APIInterface apiInterface;
    DataBaseManager dbManager;
    Movie movie;
    Movie movieRegistered;
    ImageView backdrop;
    ImageView poster;
    TextView title;
    TextView description;
    CollapsingToolbarLayout toolbarLayout;
    FloatingActionButton fab;

    long id_api;
    String titulo;
    String textoBackdrop;
    String textoPoster;
    String descricao;
    String data_lancamento;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_details);

        //Instancio a propriedade para conectar com a api
        apiInterface = APIFilm.getClient().create(APIInterface.class);
        //Inicializo o banco
        dbManager = new DataBaseManager(this);

        //Inicializo a toolbar e ativo o suporte para versões anteriores
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        //Inicializo a toolbar que minimiza quando o usuário desce a tela
        toolbarLayout = (CollapsingToolbarLayout) findViewById(R.id.toolbar_layout);

        //Inicializo os componentes da view
        backdrop = (ImageView) findViewById(R.id.backdrop);
        title = (TextView) findViewById(R.id.movie_title);
        description = (TextView) findViewById(R.id.movie_description);
        poster = (ImageView) findViewById(R.id.movie_poster);

        //Obtenho o id do filme passado por parâmetro na activity que chamou essa tela
        Intent intent = getIntent();
        final long movieId = intent.getLongExtra("movieId", 0);

        if (possuiConexaoComInternet()) {
            //Faço a chamada na api que obtém o detalhe do filme pelo ID
            Call<Movie> call = apiInterface.doGetMovieDetail(movieId);

            call.enqueue(new Callback<Movie>() {
                @Override
                public void onResponse(Call<Movie> call, Response<Movie> response) {
                    movie = response.body();

                    //Verifico se o resultado da chamada não é nula e inicializo as propriedades e atualizo a tela com os valores
                    if (movie != null) {
                        id_api = movie.getId();
                        titulo = movie.getTitle();
                        textoBackdrop = movie.getBackdropPath();
                        textoPoster = movie.getPosterPath();
                        descricao = movie.getOverview();
                        data_lancamento = movie.getReleaseDate();

                        preencheTela();
                    }
                }

                @Override
                public void onFailure(Call<Movie> call, Throwable t) {
                    call.cancel();
                }
            });
        }

        //Inicializo o botão flutuante, no qual eu faço a ação de favoritar o filme
        fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setBackgroundResource(R.color.cardview_dark_background);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                dbManager.open();
                //Verifico se o filme já existe na minha base, se existir eu não faço nada, senão eu incluo na base de dados no celular
                movieRegistered = dbManager.getByIdApi(String.valueOf(movieId));

                if (movieRegistered == null) {
                    long retorno = dbManager.insert(id_api, titulo, textoBackdrop, textoPoster, descricao, data_lancamento);

                    if (retorno > 0) {
                        Toast.makeText(getBaseContext(), "Filme adicionado aos favoritos", Toast.LENGTH_SHORT).show();
                        atualizaTela(true);
                    } else {
                        Toast.makeText(getBaseContext(), "Erro ao favoritar o filme. Tente novamente!", Toast.LENGTH_SHORT).show();
                    }
                } else {
                    dbManager.delete(movieRegistered.ID);
                    Toast.makeText(getBaseContext(), "Filme removido dos favoritos", Toast.LENGTH_SHORT).show();
                    atualizaTela(false);
                }

                dbManager.close();
            }
        });

        dbManager.open();
        //Verifico se o id que foi passado por parâmetro pela intent existe, se sim eu atualizo o botão de favoritar para informar o usuário que esse filme já está favoritado
        movieRegistered = dbManager.getByIdApi(String.valueOf(movieId));
        dbManager.close();
        if (movieRegistered == null) {
            atualizaTela(false);
        } else {
            atualizaTela(true);
            movieRegistered = null;
        }
    }

    //Utiliza a variável de filme para poder preencher a tela
    private void preencheTela() {
        if (movie != null) {
            toolbarLayout.setTitle(movie.getTitle());

            title.setText(movie.getTitle());
            description.setText(movie.getOverview());

            Glide.with(getBaseContext()).load(ConfigurationImage.getTmdbImagePath() + ConfigurationImage.getSizew780() + movie.getPosterPath())
                    .placeholder(R.drawable.ic_placeholder)
                    .error(R.drawable.ic_placeholder)
                    .diskCacheStrategy(DiskCacheStrategy.ALL)
                    .into(poster);

            Glide.with(getBaseContext()).load(ConfigurationImage.getTmdbImagePath() + ConfigurationImage.getSizew342() + movie.getBackdropPath())
                    .placeholder(R.drawable.ic_placeholder)
                    .error(R.drawable.ic_placeholder)
                    .diskCacheStrategy(DiskCacheStrategy.ALL)
                    .into(backdrop);
        }
    }

    private void atualizaTela(Boolean atualiza) {
        if (atualiza) {
            fab.setImageResource(R.drawable.ic_delete_white);
        } else {
            fab.setImageResource(R.drawable.ic_tab_favourite);
        }
    }

    //Verifica se o aplicativo possui conexão com a internet
    private boolean possuiConexaoComInternet() {
        ConnectivityManager connectivityManager = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();

        if (activeNetworkInfo != null && activeNetworkInfo.isConnected()) {
            return true;
        } else {
            Toast.makeText(getBaseContext(), "Sem conexão com a internet!!!", Toast.LENGTH_SHORT).show();
            return false;
        }
    }
}
