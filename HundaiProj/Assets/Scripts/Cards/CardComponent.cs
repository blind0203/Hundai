using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YarCustomMath;

public class CardComponent : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Camera _camera;
    private Image _image;
    private Vector3 _startPosition;
    private Canvas _canvas;

    private void Start()
    {
        _image = GetComponent<Image>();
        _camera = Camera.main;
        _startPosition = transform.localPosition;
        _canvas = GetComponentInParent<Canvas>();
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
        //_image.color = Color.green;
    }

    public void OnDrag(PointerEventData eventData)
    {
        /*transform.localPosition += new Vector3(CustomMath.RemapFloat(eventData.delta.x, 0, _camera.scaledPixelWidth, -Screen.width/2, Screen.width / 2),
            CustomMath.RemapFloat(eventData.delta.y, 0, _camera.scaledPixelHeight, -Screen.height / 2, Screen.height / 2),
            0);*/

        transform.localPosition += (Vector3)eventData.delta;

        //transform.localPosition = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = _startPosition;
    }
}
