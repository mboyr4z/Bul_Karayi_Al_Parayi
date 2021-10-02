using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Start()
    {
        ObserverSystem.instance.homePage += homePage;
    }

    private void homePage()
    {
        SceneManager.LoadScene(0);
    }
    
    private void Awake()
    {
        instance = this;
    }

    
    
    
}
