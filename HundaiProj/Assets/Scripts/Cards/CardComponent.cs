using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YarCustomMath;

using DG.Tweening;

public class CardComponent : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 StartPosition;
    public Vector3 StartRotation;

    private Camera _camera;
    private Image _image;
    
    private Canvas _canvas;

    private Vector2 _screenDifference;

    private void Start()
    {
        _image = GetComponent<Image>();
        _camera = Camera.main;
        //StartPosition = transform.localPosition;
        _canvas = GetComponentInParent<Canvas>();
        _screenDifference = GetComponentInParent<CardGameManager>().ScreenDifference;
    }

    private void Update()
    {

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
        transform.DOLocalRotate(Vector3.zero, .1f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        /*transform.localPosition = new Vector3(CustomMath.RemapValue(Input.mousePosition.x, 0, _camera.scaledPixelWidth, -Screen.width / 2, Screen.width / 2),
            CustomMath.RemapValue(Input.mousePosition.y, 0, _camera.scaledPixelHeight, -Screen.height / 2, Screen.height / 2),
            0);*/

        transform.localPosition += (Vector3)(eventData.delta * _screenDifference);

        //transform.position = _camera.ScreenToWorldPoint(Input.mousePosition);

        //transform.localPosition = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.DOLocalMove(StartPosition, .1f);
        transform.DOLocalRotate(StartRotation, .1f);
    }
}
