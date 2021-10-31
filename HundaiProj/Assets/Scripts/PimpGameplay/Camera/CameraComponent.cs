using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : Singleton<CameraComponent>
{
    [SerializeField, Tooltip("x > xMin, y > yMin, z > xMax, w > yMax")] private Vector4 _camPositionBorders;
    [SerializeField] private float _camSpeed = 10f;


    private float _speedToLerp = 0;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        HandleCamMotion();
    }

    private void HandleCamMotion()
    {
        Vector2 mousePositionOnViewport = _camera.ScreenToViewportPoint(Input.mousePosition);

        Vector2 mouseDisplace = mousePositionOnViewport - Vector2.one / 2;

        if (Mathf.Abs(mouseDisplace.x) > .49f || Mathf.Abs(mouseDisplace.y) > .49f)
        {
            _speedToLerp = Mathf.Lerp(_speedToLerp, _camSpeed, Time.deltaTime);
            MoveCamera(mouseDisplace);
        }
        else 
        {
            _speedToLerp = 0;
        }
    }

    private void MoveCamera(Vector3 direction) 
    {
        transform.Translate(_speedToLerp * Time.deltaTime * direction.normalized);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _camPositionBorders.x, _camPositionBorders.z),
            Mathf.Clamp(transform.position.y, _camPositionBorders.y, _camPositionBorders.w),
            transform.position.z);
    }
}
