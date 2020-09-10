using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject startButton;
    void Start()
    {
        DelegatesHandler.GameStart += HideStartButton;
    }

    void HideStartButton()
    {
        startButton.SetActive(false);
        DelegatesHandler.GameStart -= HideStartButton;
    }

}
