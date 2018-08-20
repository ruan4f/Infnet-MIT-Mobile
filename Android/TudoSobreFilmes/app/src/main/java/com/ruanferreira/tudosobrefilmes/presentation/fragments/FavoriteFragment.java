package com.ruanferreira.tudosobrefilmes.presentation.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.ruanferreira.tudosobrefilmes.R;
import com.ruanferreira.tudosobrefilmes.model.Movie;
import com.ruanferreira.tudosobrefilmes.presentation.adapter.FavoriteAdapter;
import com.ruanferreira.tudosobrefilmes.presentation.dao.DataBaseManager;

import java.util.List;

/**
 * Created by ruanf on 11/04/2017.
 *
 * Classe responsável por exibir os filmes favoritos do usuário
 */

public class FavoriteFragment extends Fragment {

    private static String TAG = FavoriteFragment.class.getSimpleName();

    RecyclerView listMovies;
    FavoriteAdapter favoriteAdapter;
    DataBaseManager dbManager;
    Context mContext;

    public FavoriteFragment() {

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_favorite, container, false);
        //Inicializa o contexto e os componentes
        mContext = rootView.getContext();

        listMovies = (RecyclerView) rootView.findViewById(R.id.listFavoriteMovie);
        listMovies.setLayoutManager(new GridLayoutManager(mContext, 2));
        listMovies.setItemAnimator(new DefaultItemAnimator());
        listMovies.setHasFixedSize(true);

        dbManager = new DataBaseManager(mContext);

        return rootView;
    }

    //Obtém os filmes favoritos e preenche a lista
    @Override
    public void onResume() {
        super.onResume();

        dbManager.open();

        List<Movie> movies = dbManager.getAllData();

        favoriteAdapter = new FavoriteAdapter(mContext, movies, R.layout.list_favorite_movie);

        listMovies.setAdapter(favoriteAdapter);

        dbManager.close();
    }

}