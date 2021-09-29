using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class CanvasManager : MonoBehaviour
{

    private kirmiziTop kirmiziTop;

    private Sapka sapka;

    private Click click;
    void Start()
    {
        kirmiziTop = GameObject.Find("kirmiziTop").GetComponent<kirmiziTop>();
        sapka = GameObject.Find("Sapka").GetComponent<Sapka>();
        click = GameObject.Find("Click").GetComponent<Click>(); 

        kirmiziTop.hareketEt(sapka.transform.localPosition);     // kirmizi top harekete baþlar
    }

    
    public void kirmiziTopHareketiBitti()
    {
        click.gorunurlukAc();
        click.hareketEt();

        sapka.ufakHareketlereBasla();
        sapka.tiklanilabilirlikAc();

    }

    public void sapkaKaldirildi()
    {
        click.hareketiDurdur();
        click.gorunurlukKapa();
    }


    // 6
    public void sapkaHareketiBitti() {
        kirmiziTop.hafifceZipla();
    }
    
  
}
