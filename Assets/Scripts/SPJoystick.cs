using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SPJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform background = null;
    [SerializeField] private RectTransform handle = null;
    private Canvas canvas;
    private Vector2 input = Vector2.zero;
    private Touch touch;
    private bool touchOn = false;
    private bool dragOn = false;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    private void Update()
    {
        if(Input.touchCount > 0 && !touchOn)
        {
            touchOn = true;
            touch = Input.GetTouch(0);
            background.position = touch.position;
        }
        else if(Input.touchCount == 0)
            touchOn = false;

        PointerEventData pData = new PointerEventData(EventSystem.current);
        pData.position = touch.position;
        eventStart(pData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    private void eventStart(PointerEventData eventData)
    {
        if(!dragOn)
        {
            OnDrag(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragOn = true;
        Vector2 position = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, background.position);
        Vector2 radius = background.sizeDelta / 2;
        input = (eventData.position - position) / (radius * canvas.scaleFactor);
        HandleInput(input.magnitude, input.normalized);
        handle.anchoredPosition = input * radius;
    }

    public void OnPointerUp(PointerEventData evenData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        dragOn = false;
    }

    private void HandleInput(float magnitude, Vector2 normalised)
    {
        if (magnitude > 1)
            input = normalised;
    }
}
