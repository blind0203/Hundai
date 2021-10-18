using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameManager : Singleton<CardGameManager>
{
    public Vector2 ScreenDifference;

    private void Awake()
    {
        ScreenDifference = GetComponent<CanvasScaler>().referenceResolution / new Vector2(Screen.width, Screen.height);
    }

    public void PlayerTurn() 
    {
        
    }
}
