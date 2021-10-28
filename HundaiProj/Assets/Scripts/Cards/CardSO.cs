using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/CardSO", order = 1)]
public class CardSO : ScriptableObject
{
    public string CardName;
    public string CardDescription;
    public int CardDamage;
    public int CardCost;
    public CardCategory CardCategory;
    public Sprite CardPicture;
}

public enum CardCategory 
{
    Classic, BDSM
}
