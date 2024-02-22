using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUiElement : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler , IPointerUpHandler
{
    [SerializeField] private RectTransform _dragableRect;
    private bool _isDrag = false;
    private Vector2 _dragDelta;
    private Vector2 _lastFramePosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isDrag = true;
        _lastFramePosition = eventData.position;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if(_isDrag)
        {
            _dragDelta =  eventData.position - _lastFramePosition;

            _dragableRect.anchoredPosition += _dragDelta / 2;

            _lastFramePosition = eventData.position;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isDrag = false;
    }
}
