using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Sapka : MonoBehaviour
{

    [SerializeField] private float ufakHareketSuresi, ufakHareketAraligi, kalkmaSuresi;

    [SerializeField] Ease ufakHareket_Ease;

    [SerializeField] LoopType ufakHareket_loopType;

    [SerializeField] Ease koklu_Ease;


    private CanvasManager canvasManager;

    /*
     Dotween IDker
     0 -> Ufak hareketler
     1 -> kalkma animasyon
     */


    private void Start()
    {
        canvasManager = transform.parent.gameObject.GetComponent<CanvasManager>();
        basla();
    }

    public void basla()
    {
        tiklanilabilirlikKapa();
        transform.localPosition = new Vector3(0,0,0);
    }

    private void tiklanilabilirlikKapa()
    {
        GetComponent<Button>().enabled = false;
    }


    // 3
    public void tiklanilabilirlikAc()
    {
        GetComponent<Button>().enabled = true;
    }


    //4
    public void tiklandi()
    {
        if(GetComponent<Button>().enabled)
        {
            kalk();
        }
    }

    // 2
    public void ufakHareketlereBasla()
    {
        transform.DOLocalMoveY(transform.localPosition.y + ufakHareketAraligi, ufakHareketSuresi).SetEase(ufakHareket_Ease).SetLoops(-1,ufakHareket_loopType).SetId(0);
    }

    // 5
    private void kalk()
    {
        transform.DOLocalMove(new Vector3(492,217,0), kalkmaSuresi).SetEase(koklu_Ease).SetId(1).OnComplete(() => { kalkmaBitir(); canvasManager.sapkaHareketiBitti(); });
        ufakHareketiDurdur();
        tiklanilabilirlikKapa();
        canvasManager.sapkaKaldirildi();
    }

    // 4
    private void ufakHareketiDurdur()
    {
        DOTween.Kill(0);
    }

    
    private void kalkmaBitir()
    {
        DOTween.Kill(1);
    }
}
