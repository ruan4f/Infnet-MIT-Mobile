package com.ruanferreira.tudosobrefilmes.presentation.adapter;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.load.engine.DiskCacheStrategy;
import com.ruanferreira.tudosobrefilmes.R;
import com.ruanferreira.tudosobrefilmes.model.ConfigurationImage;
import com.ruanferreira.tudosobrefilmes.model.Result;
import com.ruanferreira.tudosobrefilmes.presentation.activities.DetailsActivity;

import java.util.List;

/**
 * Created by ruanf on 27/03/2017.
 *
 * Classe responsável por criar a lista de filmes para a tela de pesquisa
 */

public class SearchAdapter extends RecyclerView.Adapter<SearchAdapter.MovieViewHolder> {

    private List<Result> movies;
    private int rowLayout;
    private static Context context;

    public SearchAdapter(Context context, List<Result> movies, int rowLayout) {
        this.context = context;
        this.movies = movies;
        this.rowLayout = rowLayout;
    }

    @Override
    public MovieViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(rowLayout, parent, false);
        return new MovieViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final MovieViewHolder holder, final int position) {
        final Result filme = movies.get(position);

        holder.title.setText(filme.getTitle());
        holder.dataRelease.setText(filme.getReleaseDate());

        Glide.with(context).load(ConfigurationImage.getTmdbImagePath() + ConfigurationImage.getSizew185() + filme.getPosterPath())
                .thumbnail(0.5f)
                .placeholder(R.drawable.ic_placeholder)
                .error(R.drawable.ic_placeholder)
                .diskCacheStrategy(DiskCacheStrategy.ALL)
                .into(holder.fotoCapa);

        holder.movie = filme;
    }

    @Override
    public int getItemCount() {
        return movies.size();
    }

    public static class MovieViewHolder extends RecyclerView.ViewHolder {
        ImageView fotoCapa;
        TextView title;
        TextView dataRelease;

        public Result movie;

        public MovieViewHolder(View v) {
            super(v);
            fotoCapa =(ImageView) v.findViewById(R.id.image);
            title = (TextView) v.findViewById(R.id.txtTitle);
            dataRelease = (TextView) v.findViewById(R.id.txtDataRelease);

            //Incluo a ação de navegar para a tela de detalhes enviando o ID do filme como parâmetro
            v.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent intent = new Intent(v.getContext(), DetailsActivity.class);
                    intent.putExtra("movieId", movie.getId());
                    v.getContext().startActivity(intent);
                }
            });
        }
    }

}
