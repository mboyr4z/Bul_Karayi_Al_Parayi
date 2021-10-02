using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class tasinabilirObjeler : MonoBehaviour
{
    public static tasinabilirObjeler instance;
    
    [SerializeField] private float tasinmaSuresi;

    [SerializeField] private Ease ease;


    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
       
        ObserverSystem.instance.UIElemanlarýCekildi += masayiTasi;    
    }

    public void masayiTasi()
    {
        print("girdik " + gameObject.name);
        transform.DOLocalMove(Vector3.zero, tasinmaSuresi).SetEase(ease).SetId(0).OnComplete( () => { ObserverSystem.instance.oyunBasladi?.Invoke(); DOTween.Kill(0); });
        print("çýktýk " + gameObject.name);
    }


}
