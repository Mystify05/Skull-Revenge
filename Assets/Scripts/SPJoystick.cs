using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPJoystick : MonoBehaviour
{
    public GameObject player;
    public Vector2 direction;
    private Vector2 dPostion; //d = default
    private RectTransform knobRect;
    [SerializeField]
    private float knobRange;
    // Start is called before the first frame update
    /*
    void Start()
    {
        knobRect = GetComponent<RectTransform>();
        dPostion = (Vector2) knobRect.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPosition = Camera.main.WorldToScreenPoint(touch.position);
        //if(touchPosition.y-kn)
        direction = (Vector2)knobRect.transform.localPosition - dPostion;
        player.transform.Translate(direction);
    }
    */
}
