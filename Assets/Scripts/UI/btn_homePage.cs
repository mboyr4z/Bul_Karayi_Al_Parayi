using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_homePage : MonoBehaviour
{
    public void tiklandi()
    {
        ObserverSystem.instance.homePage?.Invoke();
    }
}
