using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class EnemyController : Singleton<EnemyController>
{
    public EnemySO EnemyData;

    private int _progressToCum = 0;

    public void TakeDamage(CardSO card) 
    {
        float damageMultiplier = 1;

        if (card.CardCategory == EnemyData.PositiveCategoty)
        {
            damageMultiplier = 2;
        }

        else if(card.CardCategory == EnemyData.NegativeCategoty)
        {
            damageMultiplier = .5f;
        }

        _progressToCum += Mathf.RoundToInt(card.CardDamage * damageMultiplier);

        Debug.Log(card.CardDamage + " | " + Mathf.RoundToInt(card.CardDamage * damageMultiplier));

        UpdateDisplayedData();
    }

    private void UpdateDisplayedData() 
    {
        
    }

    public void EnemyTurnSequence() 
    {
        if (true) // действие при первом ходе
        {

        }

        else // действие при втором ходе
        {

        }
    }
}
