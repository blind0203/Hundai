using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Threading.Tasks;

public class TableController : Singleton<TableController>
{
    public Transform CardInHand;

    public void HandleCardDrop()
    {
        CardInHand.SetParent(transform);

        CardInHand.DOLocalMove(Vector3.zero, .1f).SetEase(Ease.OutBack);

        //HandController.Instance.AddCardToHand();

        SetCardsPositionsOnTable();
    }

    public async void EndTurn() 
    {
        

        /*CardPreviewController.Instance?.ToogleActivity(false);

        int cardCount = transform.childCount;

        for (int i = 0; i < cardCount; i++)
        {
            CardComponent cc = transform.GetChild(0).transform.GetComponent<CardComponent>();

            EnemyController.Instance?.TakeDamage(cc.CardData);

            Destroy(cc.gameObject);
            await Task.Delay(300);
        }

        HandController.Instance.FillHand();

        CardPreviewController.Instance?.ToogleActivity(true);*/
    }

    private void SetCardsPositionsOnTable() 
    {
        int cardCount = transform.childCount;

        for (int i = 0; i < cardCount; i++)
        {
            Transform card = transform.GetChild(i).transform;

            Vector3 pos = new Vector3((i - cardCount / 2) * (card.GetComponent<RectTransform>().rect.width / 2), 0, 0);

            card.DOLocalMove(pos, .25f).SetEase(Ease.OutBack);
        }
    }
}
