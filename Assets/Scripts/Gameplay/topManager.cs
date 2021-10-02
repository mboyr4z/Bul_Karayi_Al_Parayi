using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topManager : MonoBehaviour
{
    public static topManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ObserverSystem.instance.karistirmaBitti += topParentAyir;
    }

    public void topParentAyarla(Transform bardak)
    {
        transform.SetParent(bardak);
    }

    public void topuBardaginAltinaGotur(Transform bardak)
    {
        transform.position = new Vector3(bardak.position.x, bardak.position.y, bardak.position.z);
    }

    public void topParentAyir()
    {
        transform.SetParent(null);
    }
}
