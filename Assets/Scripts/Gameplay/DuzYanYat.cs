using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Yatma/DuzYanYat")]
public class DuzYanYat : AbstractYanYatmaStili
{
    [SerializeField] private Vector3 aci;
    [SerializeField] private float animasyonSuresi;
    [SerializeField] private Ease ease;
    
    public override void yanYat(GameObject obj)
    {
        obj.transform.DORotate(aci, animasyonSuresi).SetEase(ease);
    }
}
