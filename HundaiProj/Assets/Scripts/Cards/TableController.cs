using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TableController : Singleton<TableController>
{
    public Transform CardInHand;

    public void HandleCardDrop()
    {
        Debug.Log("W");
    }
}
