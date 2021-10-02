using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Işık/DüzIşık")]
public class DuzIsıkYakSondur : AbstractİsikYanmaStili
{
    [SerializeField] private float animasyonSuresi;
    [SerializeField] private int loopSayisi;
    [SerializeField] private LoopType loopType;
    [SerializeField] private Ease ease;

    public override void isikYakSondur(GameObject obj,Color color)
    {
        Debug.Log(obj);
        obj.transform.FindChild("Lamp").GetComponent<Light>().DOColor(color, animasyonSuresi).SetLoops(loopSayisi, loopType);
    }
}
