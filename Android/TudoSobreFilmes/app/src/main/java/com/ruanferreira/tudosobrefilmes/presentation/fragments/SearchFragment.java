package com.ruanferreira.tudosobrefilmes.presentation.fragments;

import android.app.ProgressDialog;
import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ProgressBar;
import android.widget.SearchView;
import android.widget.TextView;
import android.widget.Toast;

import com.ruanferreira.tudosobrefilmes.R;
import com.ruanferreira.tudosobrefilmes.model.Result;
import com.ruanferreira.tudosobrefilmes.model.Search;
import com.ruanferreira.tudosobrefilmes.presentation.adapter.SearchAdapter;
import com.ruanferreira.tudosobrefilmes.presentation.services.APIFilm;
import com.ruanferreira.tudosobrefilmes.presentation.services.APIInterface;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * Created by ruanf on 11/04/2017.
 *
 * Classe responsável por montar a lista de pesquisa e fazer a pesquisa sobre o título digitado pelo usuário
 */

public class SearchFragment extends Fragment {

    APIInterface apiInterface;
    RecyclerView listaFilmes;
    SearchAdapter searchAdapter;
    Context mContext;
    private ProgressBar progressBar;

    public SearchFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View rootView = inflater.inflate(R.layout.fragment_search, container, false);
        setHasOptionsMenu(true);
        apiInterface = APIFilm.getClient().create(APIInterface.class);

        mContext = rootView.getContext();

        listaFilmes = (RecyclerView) rootView.findViewById(R.id.filmesRecycler);
        listaFilmes.setLayoutManager(new GridLayoutManager(rootView.getContext(), 3));
        listaFilmes.setItemAnimator(new DefaultItemAnimator());
        listaFilmes.setHasFixedSize(true);
        progressBar = (ProgressBar) rootView.findViewById(R.id.progressBarSearch);

        return rootView;
    }

    //Cria o menu, no qual tem o componente de pesquisa
    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {

        MenuItem item = menu.add("Pesquisar");
        item.setIcon(R.drawable.ic_search_white);
        item.setShowAsAction(MenuItem.SHOW_AS_ACTION_IF_ROOM);
        SearchView sv = new SearchView(getActivity());

        int id = sv.getContext().getResources().getIdentifier("android:id/search_src_text", null, null);
        TextView textView = (TextView) sv.findViewById(id);
        textView.setHint("Pesquisar");
        textView.setHintTextColor(getResources().getColor(R.color.textIcons));
        textView.setTextColor(getResources().getColor(R.color.textIcons));

        //Método do componente que faz pesquisa
        sv.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String s) {
                if (s.length() < 4) {
                    Toast.makeText(getActivity(),
                            "O título não pode ter menos que 3 caracteres.",
                            Toast.LENGTH_LONG).show();
                    return true;
                } else {
                    pesquisaFilmes(s);
                    return false;
                }
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                return true;
            }
        });
        item.setActionView(sv);
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        montaLista();
    }

    //Cria a primeira lista de filmes quando a aplicação é carregada
    private void montaLista() {

        if (possuiConexaoComInternet()) {
            progressBar.setVisibility(View.VISIBLE);
            Call<Search> call = apiInterface.doGetListDiscover();

            call.enqueue(new Callback<Search>() {
                @Override
                public void onResponse(Call<Search> call, Response<Search> response) {
                    Search resource = response.body();

                    List<Result> listaDeFilmes = resource.getResults();

                    searchAdapter = new SearchAdapter(getContext(), listaDeFilmes, R.layout.list_item_movie);

                    listaFilmes.setAdapter(searchAdapter);
                    progressBar.setVisibility(View.GONE);
                }

                @Override
                public void onFailure(Call<Search> call, Throwable t) {
                    call.cancel();
                    progressBar.setVisibility(View.GONE);
                }
            });
        }
    }

    //Método que faz a pesquisa de filmes pela API
    private void pesquisaFilmes(String titulo) {
        if (!titulo.isEmpty() && possuiConexaoComInternet()) {
            progressBar.setVisibility(View.VISIBLE);
            Call<Search> call = apiInterface.doGetSearchFilms(titulo);

            call.enqueue(new Callback<Search>() {
                @Override
                public void onResponse(Call<Search> call, Response<Search> response) {
                    Search resource = response.body();

                    List<Result> listaDeFilmes = resource.getResults();

                    searchAdapter = new SearchAdapter(getContext(), listaDeFilmes, R.layout.list_item_movie);
                    listaFilmes.setAdapter(searchAdapter);
                    progressBar.setVisibility(View.GONE);
                }

                @Override
                public void onFailure(Call<Search> call, Throwable t) {
                    call.cancel();
                    progressBar.setVisibility(View.GONE);
                }
            });
        }
    }

    //Método que verifica se o celular tem conexão com a internet
    private boolean possuiConexaoComInternet() {
        ConnectivityManager connectivityManager = (ConnectivityManager) mContext.getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();

        if (activeNetworkInfo != null && activeNetworkInfo.isConnected()) {
            return true;
        } else {
            Toast.makeText(mContext, "Sem conexão com a internet!!!", Toast.LENGTH_SHORT).show();
            return false;
        }
    }

}
