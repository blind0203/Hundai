using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class CardComponent : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 StartPosition;
    public Vector3 StartRotation;

    private Canvas _canvas;
    private Camera _camera;
    private Image _image;

    private Quaternion _handRotation;
    private Vector2 _screenDifference;
    private float _scaleDIfference = .75f;

    void Start()
    {
        _image = GetComponent<Image>();
        _camera = Camera.main;
        _handRotation = transform.parent.rotation;
        //StartPosition = transform.localPosition;
        _canvas = GetComponentInParent<Canvas>();
        _screenDifference = GetComponentInParent<CardGameManager>().ScreenDifference;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = Color.red;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.DORotate(Vector3.zero, .1f);
        _image.raycastTarget = false;
        TableController.Instance.CardInHand = transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition +=  _handRotation * (Vector3)(eventData.delta * _screenDifference / _scaleDIfference);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GraphRCaster.Instance.TableCheck())
        {
            TableController.Instance.HandleCardDrop();
        }

        else
        {
            TableController.Instance.CardInHand = null;
            
            transform.DOLocalMove(StartPosition, .1f);
            transform.DOLocalRotate(StartRotation, .1f);
        }

        _image.raycastTarget = true;
    }
}
