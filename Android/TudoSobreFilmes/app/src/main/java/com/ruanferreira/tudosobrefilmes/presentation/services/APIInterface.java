package com.ruanferreira.tudosobrefilmes.presentation.services;

import com.ruanferreira.tudosobrefilmes.model.Movie;
import com.ruanferreira.tudosobrefilmes.model.Search;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
import retrofit2.http.Query;

/**
 * Created by ruanf on 01/04/2017.
 *
 * Interface com os métodos de acesso aos link utilizados pelo aplicativo
 */

public interface APIInterface {

    //Obtém a lista de filmes populares no momento
    @GET("/3/discover/movie?api_key=24443430a85e37c0026e983fb9f335bc&language=pt-BR&sort_by=popularity.desc&include_adult=false&include_video=false&page=1")
    Call<Search> doGetListDiscover();

    //Faz a pesquisa de filmes que contenham o titulo que o usuário digitou
    @GET("/3/search/movie?api_key=24443430a85e37c0026e983fb9f335bc&language=pt-BR&query=")
    Call<Search> doGetSearchFilms(@Query("query") String query);

    //Obtem o detalhe do filme
    @GET("/3/movie/{id}?api_key=24443430a85e37c0026e983fb9f335bc&language=pt-BR")
    Call<Movie> doGetMovieDetail(@Path("id") long filmeId);


}
