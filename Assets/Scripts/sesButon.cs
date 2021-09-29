using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sesButon : MonoBehaviour
{
    [SerializeField] private Sprite sesKapali, sesAcik;

    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }


     // BÝR TEK RESTART OLAYLARI KALDI

    /*
     
     
     wakdkhawdhawdawdawd


    AW
    DAW
    D
    AWD
    AW
    DAW
    D
     
     */
    public void tiklandi()
    {
        SesYoneticisi.instance.SesAcikmi = !SesYoneticisi.instance.SesAcikmi;
        if (SesYoneticisi.instance.SesAcikmi)
        {
            SesYoneticisi.instance.sesAc();
            img.sprite = sesKapali;
            return;
        }
        SesYoneticisi.instance.sesKapat();
        img.sprite = sesAcik;
    }


}
