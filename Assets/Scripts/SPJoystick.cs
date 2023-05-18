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
    public bool dragOn = false;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        //Die Mitte wird fest gelegt
        Vector2 center = new Vector2(0.5f, 0.5f);
        background.pivot = center;
        //min und max sind hier, damit handle immer in der Mitte von background sind
        handle.anchorMin = center;
        handle.anchorMax = center;
        handle.pivot = center;
        //damit handle am Anfang in der Mitte ist
        handle.anchoredPosition = Vector2.zero;
    }

    private void Update()
    {
        if (!dragOn)
        {
            if (Input.touchCount > 0 && !touchOn)
            {
                touchOn = true;
                touch = Input.GetTouch(0);
                background.position = touch.position;

                Input.simulateMouseWithTouches = false;
                Input.simulateMouseWithTouches = true;

                /*PointerEventData pData = new PointerEventData(EventSystem.current);
                pData.position = touch.position;
                OnPointerDown(pData);*/
            }
            else if (Input.touchCount == 0)
                touchOn = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
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
