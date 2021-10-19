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

    private void Start()
    {
        _image = GetComponent<Image>();
        _camera = Camera.main;
        _handRotation = transform.parent.rotation;
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
        transform.DORotate(Vector3.zero, .1f);
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        /*transform.localPosition = new Vector3(CustomMath.RemapValue(Input.mousePosition.x, 0, _camera.scaledPixelWidth, -Screen.width / 2, Screen.width / 2),
            CustomMath.RemapValue(Input.mousePosition.y, 0, _camera.scaledPixelHeight, -Screen.height / 2, Screen.height / 2),
            0);*/

        transform.localPosition +=  _handRotation * (Vector3)(eventData.delta * _screenDifference / _scaleDIfference);

        //transform.position = _camera.ScreenToWorldPoint(Input.mousePosition);

        //transform.localPosition = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _image.raycastTarget = true;
        transform.DOLocalMove(StartPosition, .1f);
        transform.DOLocalRotate(StartRotation, .1f);
    }
}
