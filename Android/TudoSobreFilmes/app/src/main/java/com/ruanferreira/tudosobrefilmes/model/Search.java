package com.ruanferreira.tudosobrefilmes.model;

import com.google.gson.annotations.SerializedName;
import java.util.List;

/**
 * Classe de modelo de busca de filmes, na qual traz a lista de filmes resultado da pesquisa
 */

public class Search{

    private static final String FIELD_TOTAL_RESULTS = "total_results";
    private static final String FIELD_RESULTS = "results";
    private static final String FIELD_TOTAL_PAGES = "total_pages";
    private static final String FIELD_PAGE = "page";

    @SerializedName(FIELD_TOTAL_RESULTS)
    private int mTotalResult;
    @SerializedName(FIELD_RESULTS)
    private List<Result> mResults;
    @SerializedName(FIELD_TOTAL_PAGES)
    private int mTotalPage;
    @SerializedName(FIELD_PAGE)
    private int mPage;

    public Search(){

    }

    public void setTotalResult(int totalResult) {
        mTotalResult = totalResult;
    }

    public int getTotalResult() {
        return mTotalResult;
    }

    public void setResults(List<Result> results) {
        mResults = results;
    }

    public List<Result> getResults() {
        return mResults;
    }

    public void setTotalPage(int totalPage) {
        mTotalPage = totalPage;
    }

    public int getTotalPage() {
        return mTotalPage;
    }

    public void setPage(int page) {
        mPage = page;
    }

    public int getPage() {
        return mPage;
    }

    @Override
    public String toString(){
        return "totalResult = " + mTotalResult + ", results = " + mResults + ", totalPage = " + mTotalPage + ", page = " + mPage;
    }


}