using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_restart : MonoBehaviour
{
    public void tiklandi()
    {
        ObserverSystem.instance.restart?.Invoke();
    }
}
