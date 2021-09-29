using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class tasinabilirObjeler : MonoBehaviour
{
    
    [SerializeField] private float tasinmaSuresi;

    [SerializeField] private Ease ease;

    void Start()
    {
        ObserverSystem.UIElemanlarýCekildi += masayiTasi;    
    }

    private void masayiTasi()
    {
        transform.DOMove(new Vector3(0,0,0), tasinmaSuresi).SetEase(ease).OnComplete( () => ObserverSystem.oyunBasladi?.Invoke());
    }

    public void basla()
    {
        transform.position = new Vector3(-10, 0, 0);
    }
}
