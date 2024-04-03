package com.webthreads.store.dao;

import com.webthreads.store.model.Apparel;

import java.util.List;

public interface ApparelDao {

    List<Apparel> getApparels();

    Apparel getApparelById(int id);

    Apparel createApparel(Apparel apparel);

    Apparel updateApparel(Apparel apparel);

    int deleteApparelById(int id);
}
