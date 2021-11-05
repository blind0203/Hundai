using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameManager : Singleton<CardGameManager>
{
    [HideInInspector] public int TurnCount = 0, TurnState = 0;

    [HideInInspector] public Vector2 ScreenDifference;
    
    [HideInInspector] public bool IsPlayerPLayed = false, IsEnemyPlayed = false;

    private void Awake()
    {
        ScreenDifference = GetComponent<CanvasScaler>().referenceResolution / new Vector2(Screen.width, Screen.height);
    }

    public void StartGame() 
    {
        TurnCount = Random.Range(0, 2);

        HandleTurn();
    }

    public void HandleTurn() 
    {
        if (TurnCount % 2 == 0) // Инициатива игрока
        {
            PlayerPoseTurn();
        }

        else                    // Инициатива противника
        {
            EnemyPoseTurn();
        }
    }

    private void PlayerPoseTurn() 
    {
        {
            //Действия игрока
        }

        EnemyActionTurn();
    }

    private void PlayerActionTurn() 
    {
        {
            //Действия игрока
        }

        //Следующий ход
    }

    private void EnemyPoseTurn() 
    {
        {
            //Действия противника
        }

        PlayerActionTurn();
    }

    private void EnemyActionTurn() 
    {
        {
            //Действия противника
        }

        //Следующий ход
    }

    public void ShowPlayerHand() 
    {
        HandController.Instance.transform.DOLocalMove(Vector3.zero, .25f).SetEase(Ease.OutBack);
    }

    public void HidePlayerHand() 
    {
        HandController.Instance.transform.DOLocalMove(new Vector3(0, -1000, 0), .25f).SetEase(Ease.OutBack);
    }

    public void ShowEnemyHand()
    {
        //EnemyHand.transform.DOLocalMove(Vector3.zero, .25f).SetEase(Ease.OutBack);
    }

    public void HideEnemyHand()
    {
        //EnemyHand.Instance.transform.DOLocalMove(new Vector3(0, 1000, 0), .25f).SetEase(Ease.OutBack);
    }

    public void NextTurnState() 
    {
        TurnState++;

        TurnState = TurnState > 1 ? 0 : 1;

        if(TurnState == 0) 
        {
            //Стадия поз
        }

        else if( TurnState == 1) 
        {
            //Стадия действий
        }
    }
}
