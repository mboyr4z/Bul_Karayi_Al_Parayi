using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OyunBitisMenu : MonoBehaviour
{
    [SerializeField] private float sure;

    [SerializeField] private Ease ease;

    void Start()
    {
        ObserverSystem.instance.restart += ekraniKapat;
        ObserverSystem.instance.win += biSaniyeSonraEkraniAc;
        ObserverSystem.instance.lose += biSaniyeSonraEkraniAc;
    }

    private void ekraniKapat()
    {
        transform.DOLocalMove(new Vector3(-800, 0, 0), sure).SetEase(ease);
    }

    public void biSaniyeSonraEkraniAc()
    {
        Invoke("ekraniAc", 1f);
    }
    private void ekraniAc()
    {
        transform.DOLocalMove(new Vector3(0,0,0), sure).SetEase(ease);
    }


}
