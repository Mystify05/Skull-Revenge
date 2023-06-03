using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Image knob;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animator;
    private Vector2 oldDirection;
    private Direction direction;
    private PlayerJoystick joystick;
    public PlayerJoystick Joystick { get { return joystick; } }
    public Vector2 OldDirection { get { return oldDirection; } }
    // Start is called before the first frame update
    void Start()
    {
        joystick = knob.GetComponent<PlayerJoystick>();
        direction = GetComponent<Direction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Direction.magnitude > joystick.DeadZone)
            oldDirection = joystick.Direction;

        animator.SetFloat("Speed", joystick.Direction.x);
        direction.Directions["JoyStick"] = joystick.Direction * speed;
        transform.Translate(direction.Richtung * Time.deltaTime);
    }
}
