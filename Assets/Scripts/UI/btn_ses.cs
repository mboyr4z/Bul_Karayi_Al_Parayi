using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_ses : MonoBehaviour
{
    [SerializeField] private Sprite sesKapali, sesAcik;

    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }



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
