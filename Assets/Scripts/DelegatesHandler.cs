using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesHandler : MonoBehaviour
{
    public static DelegatesHandler SharedInstance;

    public delegate void OnGameStart();
    public static event OnGameStart GameStart;

    public delegate void OnMeteorDestroyed();
    public static event OnMeteorDestroyed MeteorDestroyed;

    public delegate void OnMeteorHitsPlanet();
    public static event OnMeteorHitsPlanet MeteorHitted;

    public delegate void OnGameOver();
    public static event OnGameOver GameOver;

    private void Awake()
    {
            SharedInstance = this;
    }

    public void StartGame()
    {
        GameStart();
    }

    public void IncreaseScore()
    {
        MeteorDestroyed();
    }

    public void DecreaseHealth()
    {
        MeteorHitted();
    }

    public void FinishGame()
    {
        GameOver();
    }

    private void OnDestroy()
    {
        GameStart = null;
        MeteorDestroyed = null;
        MeteorHitted = null;
        GameOver = null;
    }

}
