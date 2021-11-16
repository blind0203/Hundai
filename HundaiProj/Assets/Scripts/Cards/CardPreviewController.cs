using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class CardPreviewController : Singleton<CardPreviewController>
{
    [SerializeField] private CardSO _currentCardData;

    [SerializeField] private Image _cardImage, _gradientBackground;
    [SerializeField] private Text _cardTitleText, _cardDescriptionText;

    private List<Tween> _fadeAnimation = new List<Tween>();

    private bool _isActive = true;

    private void Start()
    {
        _cardImage.color = Color.clear;
        _gradientBackground.color = Color.clear;
        _cardTitleText.color = Color.clear;
        _cardDescriptionText.color = Color.clear;
    }

    public void ToogleActivity(bool active) 
    {
        _isActive = active;
    }

    public void ShowCardPreview(CardSO cardData)
    {
        if (_isActive)
        {
            _currentCardData = cardData;

            _cardImage.sprite = _currentCardData.CardPicture;
            _cardTitleText.text = "" + _currentCardData.CardName;
            _cardDescriptionText.text = "" + _currentCardData.CardDescription;

            FadeInAnimation();
        }
    }

    public void CloseCardPreview() 
    {
        FadeOutAnimation();
    }

    private void FadeInAnimation()
    {
        if (_fadeAnimation.Count > 0)
        {
            for (int i = 0; i < _fadeAnimation.Count; i++)
            {
                _fadeAnimation[i].Kill();
            }
            
            _fadeAnimation = new List<Tween>();
        }

        _fadeAnimation.Add(_cardImage.DOColor(Color.white, .2f).OnComplete(() => 
        {
            _fadeAnimation = new List<Tween>();
        }));
        _fadeAnimation.Add(_gradientBackground.DOColor(new Color(0, 0, 0, .5f), .1f));
        _fadeAnimation.Add(_cardTitleText.DOColor(Color.black, .2f));
        _fadeAnimation.Add(_cardDescriptionText.DOColor(Color.black, .2f));
    }

    private void FadeOutAnimation() 
    {
        if (_fadeAnimation.Count > 0)
        {
            for (int i = 0; i < _fadeAnimation.Count; i++)
            {
                _fadeAnimation[i].Kill();
            }
            _fadeAnimation = new List<Tween>();
        }

        _fadeAnimation.Add(_cardImage.DOColor(Color.clear, .1f).OnComplete(() =>
        {
            _fadeAnimation = new List<Tween>();
        }));
        _fadeAnimation.Add(_gradientBackground.DOColor(Color.clear, .1f));
        _fadeAnimation.Add(_cardTitleText.DOColor(Color.clear, .1f));
        _fadeAnimation.Add(_cardDescriptionText.DOColor(Color.clear, .1f));
    }
}
