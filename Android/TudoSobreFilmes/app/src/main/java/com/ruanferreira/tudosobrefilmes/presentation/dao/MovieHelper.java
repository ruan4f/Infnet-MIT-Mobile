package com.ruanferreira.tudosobrefilmes.presentation.dao;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

/**
 * Created by ruanf on 09/04/2017.
 *
 * Classe responsável por auxiliar na criação  e gerenciamento da tabela de filmes favoritos
 */

public class MovieHelper extends SQLiteOpenHelper {

    //Nome da tabela
    public static final String TABLE_NAME = "FilmesFavoritos";

    //Colunas da tabela
    public static final String ID = "_id";

    public static final String ID_API = "idapi";
    public static final String TITLE = "title";
    public static final String BACKDROP = "backdrop";
    public static final String POSTER = "poster";
    public static final String DESCRIPTION = "description";
    public static final String DATA_RELEASE = "datarelease";

    //Nome do banco de dados
    static final String DB_NAME = "TudoSobreFilmes.DB";

    //Versão do banco de dados
    static final int DB_VERSION = 2;

    //Query de crição da tabela
    private static final String CREATE_TABLE = "create table " + TABLE_NAME + "(" + ID
            + " INTEGER PRIMARY KEY AUTOINCREMENT, "
            + ID_API + " TEXT NOT NULL, "
            + TITLE + " TEXT NOT NULL, "
            + BACKDROP + " TEXT, "
            + POSTER + " TEXT, "
            + DESCRIPTION + " TEXT, "
            + DATA_RELEASE + " INTEGER);";

    public MovieHelper(Context context) {
        super(context, DB_NAME, null, DB_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(CREATE_TABLE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME);
        onCreate(db);
    }
}
