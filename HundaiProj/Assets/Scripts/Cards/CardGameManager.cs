using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameManager : Singleton<CardGameManager>
{
    [HideInInspector] public int TurnCount = 0;

    [HideInInspector] public Vector2 ScreenDifference;

    private void Awake()
    {
        ScreenDifference = GetComponent<CanvasScaler>().referenceResolution / new Vector2(Screen.width, Screen.height);
    }

    public void StartGame() 
    {
        TurnCount = Random.Range(0, 2);


    }

    public void PlayerTurn() 
    {
        
    }
}
