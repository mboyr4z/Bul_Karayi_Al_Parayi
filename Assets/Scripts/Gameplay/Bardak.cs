using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bardak : MonoBehaviour
{
    [SerializeField] private Abstract›sikYanmaStili isikYakmaStili;
    [SerializeField] private AbstractYanYatmaStili yanYatmaStili;

    [SerializeField] private LoopType loopType;
    [SerializeField] private Ease ease;
    [SerializeField] private float animasyonSuresi;
    [SerializeField] private float kalkisAraligi;

    private void Start()
    {
        ObserverSystem.instance.restart += eskiRotasyonaGel;
    }


    private void OnMouseDown()
    {
        if(GetComponent<Bardak>().enabled == true)
        {

            tiklanilanBardagiKaldir();

            var sonHarf = gameObject.name[gameObject.name.Length - 1];

            BardakManager.instance.SecilenBardak = int.Parse(sonHarf.ToString()) - 1;

            ObserverSystem.instance.bardakSecildi?.Invoke();
        }
    }

    // BARDAKMANAGER›N ETK›LED›–› PUBL›C VONKS›YONLAR

    private void eskiRotasyonaGel()
    {
        transform.eulerAngles = new Vector3(0, 0, -180);
    }

    public void yanYat()
    {
        yanYatmaStili.yanYat(gameObject);
    }

    public void isikRenkDegis(Color color)
    {
        isikYakmaStili.isikYakSondur(gameObject, color);
    }

    public void yerDegistir(float z, float x)
    {
        transform.DOLocalMoveZ(z, 0.2f).SetLoops(2, LoopType.Yoyo);
        transform.DOLocalMoveX(x, 0.2f);
    }

    public void secimOncesiBardakKaldir()
    {
        transform.DOLocalMoveY(transform.position.y + 1f, 1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).OnComplete(() => { topManager.instance.topParentAyarla(transform); BardakManager.instance.karistirmayaBasla(); });
    }
    private void tiklanilanBardagiKaldir()
    {
        transform.DOLocalMoveY(transform.position.y + kalkisAraligi,animasyonSuresi).SetEase(ease).SetLoops(2,loopType);
    }
}
