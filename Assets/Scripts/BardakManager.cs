using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BardakManager : MonoBehaviour
{
    public static BardakManager instance;

    private Material m_bardak;

    private Color color_dogruBardak, color_yanlisBardak;

    private Transform[] bardaklar;

    private Transform bardak;

    private int dogruBardakSirasi;

    private int secilenBardak;

    private int karistirmaSayisi;

    private int[,] karistirilacakBardakListesi;

    int sayi = 0;

    public int SecilenBardak { get => secilenBardak; set => secilenBardak = value; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        color_dogruBardak = new Color(0,0,110,0);
        color_yanlisBardak = new Color(110, 0, 0, 0);

        bardaklar = new Transform[3];

        int i = 0;
        foreach (Transform child in transform)
        {
            bardaklar[i++] = child;
        }

        bardaklarinTiklanilabilirlikKapa();

        ObserverSystem.oyunBasladi += oyunBasla;
        ObserverSystem.bardakSecildi += bardaklarinTiklanilabilirlikKapa;
        ObserverSystem.karistirmaBitti += bardaklarinTiklanilabilirlikkAc;
        ObserverSystem.bardakSecildi += dogruBardagiGoster;
    }

    public void oyunBasla()
    {
        ObserverSystem.baslangic?.Invoke();

        dogruBardakSirasi = Random.Range(0, bardaklar.Length);

        bardak = bardaklar[dogruBardakSirasi];

        topManager.instance.topuBardaginAltinaGotur(bardak);          // bardaðýn altýna týpu götür

        bardagiKaldir();            // bardaðý kaldýr, indir ve parentini ayarla

    }
    private void bardagiKaldir()
    {
        bardak.gameObject.GetComponent<Bardak>().secimOncesiBardakKaldir();
    }

    public void karistirmayaBasla()
    {
        karistirmaSayisi = Random.Range(3, 5);

        karistirilacakBardakListesi = new int[karistirmaSayisi, 2];

        for (int i = 0; i < karistirmaSayisi; i++)
        {
            int birinciBardak = Random.Range(0, 3);
            int ikinciBardak;
            do
            {
                ikinciBardak = Random.Range(0, 3);
            } while (ikinciBardak == birinciBardak);

            karistirilacakBardakListesi[i, 0] = birinciBardak;
            karistirilacakBardakListesi[i, 1] = ikinciBardak;
        }

        for (int i = 0; i < karistirmaSayisi; i++)
        {
            StartCoroutine(Karistir(karistirilacakBardakListesi[i, 0], karistirilacakBardakListesi[i, 1], i + 1));
        }
    }

    IEnumerator Karistir(int birinciSira, int ikinciSira, int sira)
    {
        yield return new WaitForSeconds(sira * 0.5f);

        bardaklar[ikinciSira].GetComponent<Bardak>().yerDegistir(bardaklar[birinciSira].transform.localPosition.z + 0.5f, bardaklar[birinciSira].transform.localPosition.x);
        bardaklar[birinciSira].GetComponent<Bardak>().yerDegistir(bardaklar[ikinciSira].transform.localPosition.z - 0.5f, bardaklar[ikinciSira].transform.localPosition.x);

        if(sira == karistirmaSayisi)
        {
            Invoke("karistirmaBiter",0.5f);
        }
    }

    private void karistirmaBiter()
    {
        ObserverSystem.karistirmaBitti?.Invoke();
    }

    private void bardaklarinTiklanilabilirlikkAc()
    {
        foreach (var bardak in bardaklar)
        {
            bardak.gameObject.GetComponent<Bardak>().enabled = true;
        }
    }

    private void bardaklarinTiklanilabilirlikKapa()
    {
        foreach (var bardak in bardaklar)
        {
            bardak.gameObject.GetComponent<Bardak>().enabled = false;
        }
    }

    private bool secilenBardakDogruMu()
    {
        if(instance.SecilenBardak == dogruBardakSirasi)
        {
            ObserverSystem.win?.Invoke();
            return true;
        }
        ObserverSystem.lose?.Invoke();
        return false;
    }


    private void dogruBardagiGoster() {
        if (secilenBardakDogruMu() == false)
        {
            //bardaklar[instance.SecilenBardak].GetComponent<Bardak>().isikRenkDegis(color_yanlisBardak);         // yanlýþ bardak kýrmýzý olsun
            bardaklar[dogruBardakSirasi].GetComponent<Bardak>().yanYat();
        }
       // bardaklar[dogruBardakSirasi].GetComponent<Bardak>().isikRenkDegis(color_dogruBardak);           // doðru bardak maviye dönsün
    }

}

