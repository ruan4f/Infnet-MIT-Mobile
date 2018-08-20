package com.ruanferreira.tudosobrefilmes.model;

import com.google.gson.annotations.SerializedName;

/**
 * Classe de modelo de filme
 */

public class Movie {

    private static final String FIELD_BACKDROP_PATH = "backdrop_path";
    private static final String FIELD_RELEASE_DATE = "release_date";
    private static final String FIELD_ID = "id";
    private static final String FIELD_OVERVIEW = "overview";
    private static final String FIELD_POSTER_PATH = "poster_path";
    private static final String FIELD_TITLE = "title";

    public int ID;

    @SerializedName(FIELD_BACKDROP_PATH)
    private String mBackdropPath;
    @SerializedName(FIELD_RELEASE_DATE)
    private String mReleaseDate;
    @SerializedName(FIELD_ID)
    private long mId;
    @SerializedName(FIELD_OVERVIEW)
    private String mOverview;
    @SerializedName(FIELD_POSTER_PATH)
    private String mPosterPath;
    @SerializedName(FIELD_TITLE)
    private String mTitle;

    public Movie() {

    }

    public Movie(int id, long id_api, String title, String backdrop, String poster, String description, String data_release) {
        ID = id;
        mId = id_api;
        mTitle = title;
        mBackdropPath = backdrop;
        mPosterPath = poster;
        mOverview = description;
        mReleaseDate = data_release;
    }

    public void setBackdropPath(String backdropPath) {
        mBackdropPath = backdropPath;
    }

    public String getBackdropPath() {
        return mBackdropPath;
    }

    public void setReleaseDate(String releaseDate) {
        mReleaseDate = releaseDate;
    }

    public String getReleaseDate() {
        return mReleaseDate;
    }

    public void setId(long id) {
        mId = id;
    }

    public long getId() {
        return mId;
    }

    public void setOverview(String overview) {
        mOverview = overview;
    }

    public String getOverview() {
        return mOverview;
    }

    public void setPosterPath(String posterPath) {
        mPosterPath = posterPath;
    }

    public String getPosterPath() {
        return mPosterPath;
    }

    public void setTitle(String title) {
        mTitle = title;
    }

    public String getTitle() {
        return mTitle;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj instanceof Movie) {
            return ((Movie) obj).getId() == mId;
        }
        return false;
    }

    @Override
    public int hashCode() {
        return ((Long) mId).hashCode();
    }

    @Override
    public String toString() {
        return "backdropPath = " + mBackdropPath + ", releaseDate = " + mReleaseDate + ", id = " + mId + ", overview = " + mOverview + ", posterPath = " + mPosterPath + ", title = " + mTitle;
    }


}