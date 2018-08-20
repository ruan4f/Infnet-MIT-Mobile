package com.ruanferreira.tudosobrefilmes.model;

import com.google.gson.annotations.SerializedName;
import java.util.List;

/**
 * Classe de modelo de filmes gerados pela busca da api
 */

public class Result{

    private static final String FIELD_ID = "id";
    private static final String FIELD_ORIGINAL_TITLE = "original_title";
    private static final String FIELD_BACKDROP_PATH = "backdrop_path";
    private static final String FIELD_ORIGINAL_LANGUAGE = "original_language";
    private static final String FIELD_VOTE_AVERAGE = "vote_average";
    private static final String FIELD_OVERVIEW = "overview";
    private static final String FIELD_RELEASE_DATE = "release_date";
    private static final String FIELD_TITLE = "title";
    private static final String FIELD_ADULT = "adult";
    private static final String FIELD_VOTE_COUNT = "vote_count";
    private static final String FIELD_POSTER_PATH = "poster_path";
    private static final String FIELD_POPULARITY = "popularity";
    private static final String FIELD_VIDEO = "video";

    @SerializedName(FIELD_ID)
    private long mId;
    @SerializedName(FIELD_ORIGINAL_TITLE)
    private String mOriginalTitle;
    @SerializedName(FIELD_BACKDROP_PATH)
    private String mBackdropPath;
    @SerializedName(FIELD_ORIGINAL_LANGUAGE)
    private String mOriginalLanguage;
    @SerializedName(FIELD_VOTE_AVERAGE)
    private double mVoteAverage;
    @SerializedName(FIELD_OVERVIEW)
    private String mOverview;
    @SerializedName(FIELD_RELEASE_DATE)
    private String mReleaseDate;
    @SerializedName(FIELD_TITLE)
    private String mTitle;
    @SerializedName(FIELD_ADULT)
    private boolean mAdult;
    @SerializedName(FIELD_VOTE_COUNT)
    private int mVoteCount;
    @SerializedName(FIELD_POSTER_PATH)
    private String mPosterPath;
    @SerializedName(FIELD_POPULARITY)
    private double mPopularity;
    @SerializedName(FIELD_VIDEO)
    private boolean mVideo;


    public Result(){

    }

    public void setId(long id) {
        mId = id;
    }

    public long getId() {
        return mId;
    }

    public void setOriginalTitle(String originalTitle) {
        mOriginalTitle = originalTitle;
    }

    public String getOriginalTitle() {
        return mOriginalTitle;
    }

    public void setBackdropPath(String backdropPath) {
        mBackdropPath = backdropPath;
    }

    public String getBackdropPath() {
        return mBackdropPath;
    }

    public void setOriginalLanguage(String originalLanguage) {
        mOriginalLanguage = originalLanguage;
    }

    public String getOriginalLanguage() {
        return mOriginalLanguage;
    }

    public void setVoteAverage(double voteAverage) {
        mVoteAverage = voteAverage;
    }

    public double getVoteAverage() {
        return mVoteAverage;
    }

    public void setOverview(String overview) {
        mOverview = overview;
    }

    public String getOverview() {
        return mOverview;
    }

    public void setReleaseDate(String releaseDate) {
        mReleaseDate = releaseDate;
    }

    public String getReleaseDate() {
        return mReleaseDate;
    }

    public void setTitle(String title) {
        mTitle = title;
    }

    public String getTitle() {
        return mTitle;
    }

    public void setAdult(boolean adult) {
        mAdult = adult;
    }

    public boolean isAdult() {
        return mAdult;
    }

    public void setVoteCount(int voteCount) {
        mVoteCount = voteCount;
    }

    public int getVoteCount() {
        return mVoteCount;
    }

    public void setPosterPath(String posterPath) {
        mPosterPath = posterPath;
    }

    public String getPosterPath() {
        return mPosterPath;
    }

    public void setPopularity(double popularity) {
        mPopularity = popularity;
    }

    public double getPopularity() {
        return mPopularity;
    }

    public void setVideo(boolean video) {
        mVideo = video;
    }

    public boolean isVideo() {
        return mVideo;
    }

    @Override
    public boolean equals(Object obj){
        if(obj instanceof Result){
            return ((Result) obj).getId() == mId;
        }
        return false;
    }

    @Override
    public int hashCode(){
        return ((Long)mId).hashCode();
    }

    @Override
    public String toString(){
        return "id = " + mId + ", originalTitle = " + mOriginalTitle + ", backdropPath = " + mBackdropPath + ", originalLanguage = " + mOriginalLanguage + ", voteAverage = " + mVoteAverage + ", overview = " + mOverview + ", releaseDate = " + mReleaseDate + ", title = " + mTitle + ", adult = " + mAdult + ", voteCount = " + mVoteCount + ", posterPath = " + mPosterPath + ", popularity = " + mPopularity + ", video = " + mVideo;
    }


}