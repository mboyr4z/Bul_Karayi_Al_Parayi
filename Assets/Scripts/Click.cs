using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Click : MonoBehaviour
{
    [SerializeField] private float hareketAraligi;

    [SerializeField] private Ease ease;

    [SerializeField] private float animasyonSuresi;

    

    /*
     ID ler
     0 hareket id si
     */

    public void hareketEt()
    {
        transform.DOLocalMoveX(transform.localPosition.x + hareketAraligi , animasyonSuresi).SetEase(ease).SetId(0).SetLoops(-1,LoopType.Yoyo);
    }

    public void hareketiDurdur()
    {
        DOTween.Kill(0);
    }

    public void gorunurlukKapa()
    {
        gameObject.GetComponent<Image>().enabled = false;
    }

    public void gorunurlukAc()
    {
        gameObject.GetComponent<Image>().enabled = true;
    }
}
