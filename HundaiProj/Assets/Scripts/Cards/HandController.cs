using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class HandController : Singleton<HandController>
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private int _startCardsInHandCount;

    private CardSO[] cardsResources = new CardSO[0];

    private void Start()
    {
        cardsResources = Resources.LoadAll<CardSO>("Cards");
        FillHand();
    }

    public async void FillHand() 
    {
        int c = _startCardsInHandCount - transform.childCount;

        for (int i = 0; i < c; i++)
        {
            AddCardToHand();
            await Task.Delay(300);
        }
    }

    public void SetCardsAtPositions() 
    {
        int cardCount = transform.childCount;

        for (int i = 0; i < cardCount; i++)
        {
            Transform card = transform.GetChild(i).transform;

            Vector3 pos = new Vector3((i - cardCount / 2) * (card.GetComponent<RectTransform>().rect.width / Mathf.Pow(cardCount, .5f)), 250 - (10 * Mathf.Pow(Mathf.Abs(i - cardCount / 2), 2)), 0);
            Vector3 rot = new Vector3(0, 0, (i - cardCount / 2) * -5f);

            card.GetComponent<CardComponent>().StartPosition = pos;
            card.GetComponent<CardComponent>().StartRotation = rot;

            card.DOLocalMove(pos, .25f).SetEase(Ease.OutBack);
            card.DOLocalRotate(rot, .25f).SetEase(Ease.OutBack);
        }
    }

    public void AddCardToHand() 
    {
        GameObject cardToAdd = Instantiate(_cardPrefab, transform);

        cardToAdd.transform.localPosition = Vector3.down * 2000;

        SetCardData(cardToAdd.transform.GetComponent<CardComponent>());

        SetCardsAtPositions();
    }

    private void SetCardData(CardComponent cardComponent) 
    {
        if (CardGameManager.Instance.TurnState == 0)
        {

        }

        else
        {
            
        }

        cardComponent.CardData = cardsResources[Random.Range(0, cardsResources.Length)];
        cardComponent.FillCardDataFields();
    }
}
