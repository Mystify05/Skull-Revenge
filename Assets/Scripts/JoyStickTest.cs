using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStickTest : MonoBehaviour
{
    [SerializeField] private GameObject tpPrefab;
    [SerializeField] private RectTransform background = null;
    [SerializeField] private RectTransform handle = null;
    [SerializeField] private RectTransform touchCheck = null;
    [SerializeField] private Image field = null; //field ist gleich backgrounds Image
    [SerializeField] private float deadZone;
    private GameObject tpPosition;
    private Canvas canvas;
    private Vector2 input = Vector2.zero;
    private Vector2 startPosition;
    private bool touchOn = false;
    private WhoesTouch whoesTouch = new WhoesTouch();

    public Vector2 Direction { get { return new Vector2(input.x, input.y); } }
    public float DeadZone { set { 
            if (value <= 1) deadZone = value; 
            else Debug.Log("DeadZone darf nicht größer als 1 Sein"); } 
    }

    void Start()
    {
        DeadZone = deadZone;

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
        if (Input.touchCount > 0 && whoesTouch.RightTouch != -1)
        {
            Touch touch = Input.GetTouch(whoesTouch.RightTouch);
            if(touch.position.x > Screen.width / 2 && RectTransformUtility.RectangleContainsScreenPoint(touchCheck, touch.position))
            {
                field.enabled = true;
                if (touchOn)
                {
                    moveHandle(touch.position);
                }
                else
                {
                    background.position = touch.position;
                    tpPosition = Instantiate(tpPrefab, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
                }
                touchOn = true;
            }
        }
        else
        {
            moveToZero(input.magnitude);
        }
    }

    private void moveHandle(Vector2 touchPosition)
    {
        Vector2 position = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, background.position);
        Vector2 radius = background.sizeDelta / 2;
        input = (touchPosition - position) / (radius * canvas.scaleFactor);
        handleInput(input.magnitude, input.normalized, touchPosition);
        handle.anchoredPosition = input * radius;
    }

    private void handleInput(float magnitude, Vector2 normalised, Vector2 touchPosition)
    {
        if (magnitude > 1)
        {
            Vector2 r = background.sizeDelta / 2;
            Vector2 newPosiiton = touchPosition - (normalised * r);
            background.position = newPosiiton;
            input = normalised;
        }
        if (magnitude < deadZone)
        {
            tpPosition.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            tpPosition.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void moveToZero(float magnitude)
    {
        background.position = startPosition;
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;

        if(magnitude < deadZone)
        {
            try
            {
                tpPosition.GetComponent<TPPositioning>().Cancel();
            }
            catch { }
        }
        else
        {
            try
            {
                tpPosition.GetComponent<TPPositioning>().DestroyObjekt();
            }
            catch { }
        }

        touchOn = false;
        field.enabled = false;
    }
}
