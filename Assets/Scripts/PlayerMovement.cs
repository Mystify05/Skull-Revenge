using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Image knob;
    [SerializeField]
    private float speed = 5f;
    private PlayerJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = knob.GetComponent<PlayerJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(joystick.Direction * Time.deltaTime * speed);
    }
}
