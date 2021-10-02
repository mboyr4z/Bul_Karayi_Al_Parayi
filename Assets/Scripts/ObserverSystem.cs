using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObserverSystem : MonoBehaviour
{
    public Action oyunBasladi;

    public Action bardakSecildi;

    public Action karistirmaBitti;

    public Action baslangic, win, lose;

    public Action UIElemanlarýCekildi;

    public Action bardakHareketEtti;

    public Action restart;

    public Action homePage;

    public static ObserverSystem instance;

    private void Awake()
    {
        instance = this;
    }

}
