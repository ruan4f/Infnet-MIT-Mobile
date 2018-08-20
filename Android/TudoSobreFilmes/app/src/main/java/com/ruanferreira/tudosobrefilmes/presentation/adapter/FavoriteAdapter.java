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
import com.ruanferreira.tudosobrefilmes.model.Movie;
import com.ruanferreira.tudosobrefilmes.presentation.activities.DetailsActivity;

import java.util.List;

/**
 * Created by ruanf on 27/03/2017.
 *
 * Classe responsável por gerenciar a lista de filmes favoritos para o recyclerview
 */

public class FavoriteAdapter extends RecyclerView.Adapter<FavoriteAdapter.MovieViewHolder> {

    private List<Movie> movies;
    private int rowLayout;
    private static Context context;

    public FavoriteAdapter(Context context, List<Movie> filmes, int rowLayout) {
        this.context = context;
        this.movies = filmes;
        this.rowLayout = rowLayout;
    }

    @Override
    public FavoriteAdapter.MovieViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(rowLayout, parent, false);
        return new FavoriteAdapter.MovieViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final FavoriteAdapter.MovieViewHolder holder, final int position) {
        final Movie movie = movies.get(position);

        holder.titulo.setText(movie.getTitle());
        holder.subtitulo.setText(movie.getReleaseDate());

        Glide.with(context).load(ConfigurationImage.getTmdbImagePath() + ConfigurationImage.getSizew185() + movie.getPosterPath())
                .thumbnail(0.5f)
                .placeholder(R.drawable.ic_placeholder)
                .error(R.drawable.ic_placeholder)
                .diskCacheStrategy(DiskCacheStrategy.ALL)
                .into(holder.fotoCapa);

        holder.movie = movie;
    }

    @Override
    public int getItemCount() {
        return movies.size();
    }

    public static class MovieViewHolder extends RecyclerView.ViewHolder {
        ImageView fotoCapa;
        TextView titulo;
        TextView subtitulo;

        public Movie movie;

        public MovieViewHolder(View v) {
            super(v);
            fotoCapa =(ImageView) v.findViewById(R.id.image);
            titulo = (TextView) v.findViewById(R.id.txtTitulo);
            subtitulo = (TextView) v.findViewById(R.id.txtSubtitulo);

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
