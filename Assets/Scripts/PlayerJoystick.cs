using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    [SerializeField] private RectTransform background = null;
    [SerializeField] private RectTransform handle = null;
    private Canvas canvas;
    private Vector2 input = Vector2.zero;
    private Vector2 startPosition;
    private bool touchOn = false;
    private WhoesTouch whoesTouch = new WhoesTouch();
    public Vector2 Direction { get { return new Vector2(input.x, input.y); } }
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        Vector2 center = new Vector2(0.5f, 0.5f);
        background.pivot = center;
        //min und max sind hier, damit handle immer in der Mitte von background sind
        handle.anchorMin = center;
        handle.anchorMax = center;
        handle.pivot = center;
        //damit handle am Anfang in der Mitte ist
        handle.anchoredPosition = Vector2.zero;
        startPosition = background.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && whoesTouch.LeftTouch != -1)
        {
            Touch touch = Input.GetTouch(whoesTouch.LeftTouch);
            if(touch.position.x < Screen.width / 2)
            {
                if (touchOn)
                {
                    moveHandle(touch.position);
                }
                else
                {
                    background.position = touch.position;
                }
                touchOn = true;
            }
        }
        else
        {
            moveToZero();
            touchOn = false;
        }
    }

    private void moveHandle(Vector2 touchPosition)
    {
        Vector2 position = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, background.position);
        Vector2 radius = background.sizeDelta / 2;
        input = (touchPosition - position) / (radius * canvas.scaleFactor);
        handleInput(input.magnitude, input.normalized);
        handle.anchoredPosition = input * radius;
    }

    private void handleInput(float magnitude, Vector2 normalised)
    {
        if (magnitude > 1)
            input = normalised;
    }

    private void moveToZero()
    {
        background.position = startPosition;
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
