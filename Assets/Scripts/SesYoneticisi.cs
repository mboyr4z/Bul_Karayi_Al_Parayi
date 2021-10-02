using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesYoneticisi : MonoBehaviour
{
    public static SesYoneticisi instance;

    private AudioSource audio;

    public List<AudioClip> baslangic, win, lose;

    public AudioClip bardak_Hareket;

    private bool sesAcikmi = true;

    private int sira;

    public bool SesAcikmi { get => sesAcikmi; set => sesAcikmi = value; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        ObserverSystem.instance.baslangic += baslangicMuzikVer;  // +
        ObserverSystem.instance.win += winMuzikVer;              // * 
        ObserverSystem.instance.lose += loseMuzikVer;            //+
        ObserverSystem.instance.bardakHareketEtti += bardakHareketiSesiVer;
    }

    private void bardakHareketiSesiVer()
    {
        sesVer(bardak_Hareket);
    }


    private void loseMuzikVer()
    {
        sira = Random.Range(0, lose.Count);
        sesVer(lose[sira]);
    }

    private void winMuzikVer()
    {
        sira = Random.Range(0, win.Count);
        sesVer(win[sira]);
    }

    private void baslangicMuzikVer()
    {
        sira = Random.Range(0, baslangic.Count);
        sesVer(baslangic[sira]);
    }


    public void sesVer(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }

    public void sesKapat()
    {
        audio.volume = 0;
    }

    public void sesAc()
    {
        audio.volume = 1;
    }
}
