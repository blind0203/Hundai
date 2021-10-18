using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandController : Singleton<HandController>
{
    private void Start()
    {
        SetCardsAtPositions();
    }

    public void SetCardsAtPositions() 
    {
        int cardCount = transform.childCount;

        for (int i = 0; i < cardCount; i++)
        {
            Transform card = transform.GetChild(i).transform;

            Vector3 pos = new Vector3((i - cardCount / 2) * (card.GetComponent<RectTransform>().rect.width / 1.5f), 250 - (10 * Mathf.Abs(i - cardCount / 2)), 0);
            Vector3 rot = new Vector3(0, 0, (i - cardCount / 2) * -5);

            card.GetComponent<CardComponent>().StartPosition = pos;
            card.GetComponent<CardComponent>().StartRotation = rot;

            card.DOLocalMove(pos, .5f).SetEase(Ease.OutBack);
            card.DOLocalRotate(rot, .5f).SetEase(Ease.OutBack);
        }
    }
}
