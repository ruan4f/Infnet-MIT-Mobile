package com.ruanferreira.tudosobrefilmes.presentation.dao;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.text.TextUtils;

import com.ruanferreira.tudosobrefilmes.model.Movie;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by ruanf on 10/04/2017.
 *
 * Classe responsável por gerenciar o banco de dados
 */

public class DataBaseManager {

    private MovieHelper dbHelper;

    private Context context;

    private SQLiteDatabase database;

    public DataBaseManager(Context c) {
        context = c;
    }

    public DataBaseManager open() throws SQLException {
        dbHelper = new MovieHelper(context);
        database = dbHelper.getWritableDatabase();
        return this;
    }

    public void close() {
        dbHelper.close();
    }

    //Insere um novo filme na base de dados
    public long insert(long id_api, String title, String backdrop, String poster, String description, String data_release) {
        boolean inserido = false;

        inserido = id_api > 0 && !TextUtils.isEmpty(title);

        if (inserido){
            ContentValues contentValue = new ContentValues();
            contentValue.put(MovieHelper.ID_API, id_api);
            contentValue.put(MovieHelper.TITLE, title);
            contentValue.put(MovieHelper.BACKDROP, backdrop);
            contentValue.put(MovieHelper.POSTER, poster);
            contentValue.put(MovieHelper.DESCRIPTION, description);
            contentValue.put(MovieHelper.DATA_RELEASE, data_release);
            return database.insert(MovieHelper.TABLE_NAME, null, contentValue);
        }

        return 0;
    }

    //Obtém todos os filmes da base de dados
    public List<Movie> getAllData() {
        List<Movie> lista = new ArrayList<>();

        String[] columns = new String[]{MovieHelper.ID, MovieHelper.ID_API, MovieHelper.TITLE, MovieHelper.BACKDROP, MovieHelper.POSTER, MovieHelper.DESCRIPTION, MovieHelper.DATA_RELEASE};
        Cursor cursor = database.query(MovieHelper.TABLE_NAME, columns, null, null, null, null, null);

        while (cursor.moveToNext()) {
            int index0 = cursor.getColumnIndex(MovieHelper.ID);
            int index1 = cursor.getColumnIndex(MovieHelper.ID_API);
            int index2 = cursor.getColumnIndex(MovieHelper.TITLE);
            int index3 = cursor.getColumnIndex(MovieHelper.BACKDROP);
            int index4 = cursor.getColumnIndex(MovieHelper.POSTER);
            int index5 = cursor.getColumnIndex(MovieHelper.DESCRIPTION);
            int index6 = cursor.getColumnIndex(MovieHelper.DATA_RELEASE);

            int id = cursor.getInt(index0);
            long id_api = cursor.getLong(index1);
            String title = cursor.getString(index2);
            String backdrop = cursor.getString(index3);
            String poster = cursor.getString(index4);
            String description = cursor.getString(index5);
            String data_release = cursor.getString(index6);

            Movie filme = new Movie(id, id_api, title, backdrop, poster, description, data_release);
            lista.add(filme);
        }

        return lista;
    }

    //Obtém um filme pelo Id da api
    public Movie getByIdApi(String id_api) {
        String where = MovieHelper.ID_API + " = ?";
        String[] whereArgs = {id_api};
        Cursor cursor = database.query(MovieHelper.TABLE_NAME, null, where, whereArgs, null, null, null);
        Movie obj = null;

        if (cursor.moveToFirst()) {
            int index0 = cursor.getColumnIndex(MovieHelper.ID);
            int index1 = cursor.getColumnIndex(MovieHelper.ID_API);
            int index2 = cursor.getColumnIndex(MovieHelper.TITLE);
            int index3 = cursor.getColumnIndex(MovieHelper.BACKDROP);
            int index4 = cursor.getColumnIndex(MovieHelper.POSTER);
            int index5 = cursor.getColumnIndex(MovieHelper.DESCRIPTION);
            int index6 = cursor.getColumnIndex(MovieHelper.DATA_RELEASE);

            int id = cursor.getInt(index0);
            long idapi = cursor.getLong(index1);
            String title = cursor.getString(index2);
            String backdrop = cursor.getString(index3);
            String poster = cursor.getString(index4);
            String description = cursor.getString(index5);
            String data_release = cursor.getString(index6);

            obj = new Movie(id, idapi, title, backdrop, poster, description, data_release);
        }

        return obj;
    }

    //Exclui um filme da base de dados
    public void delete(long id) {
        database.delete(MovieHelper.TABLE_NAME, MovieHelper.ID + "=" + id, null);
    }

}
