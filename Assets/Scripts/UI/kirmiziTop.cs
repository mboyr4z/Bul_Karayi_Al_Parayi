using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class kirmiziTop : MonoBehaviour
{

    

    [SerializeField] private float animasyonSuresi;

    [SerializeField] private Ease ease;

    private CanvasManager canvasManager;

    [SerializeField] private float ziplamaAraligi, ziplamaAnimasyonSuresi;

    [SerializeField] private Ease ziplama_ease;

    private void Start()
    {
        canvasManager = transform.parent.gameObject.GetComponent<CanvasManager>();    
    }


    // 1
    public void hareketEt(Vector3 gidecegiYer)
    {
        transform.DOLocalMove(gidecegiYer, animasyonSuresi).SetEase(ease).OnComplete( () => { canvasManager.kirmiziTopHareketiBitti(); });
    }

    // 6
    public void hafifceZipla()
    {
        transform.DOLocalMoveY(transform.localPosition.y + ziplamaAraligi, ziplamaAnimasyonSuresi).SetEase(ziplama_ease).SetLoops(2, LoopType.Yoyo).OnComplete(() => ortadanKaybol()); ;
    }

    // 7
    private void ortadanKaybol()
    {
        transform.DOLocalMove(new Vector3(450,0,0), 0.5f).OnComplete(() => { ObserverSystem.instance.UIElemanlarýCekildi?.Invoke();  });
    }

    public void basla()
    {
        transform.localPosition = new Vector3(448,51,0);
    } 
}
