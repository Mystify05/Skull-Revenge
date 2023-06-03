using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Image knob;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animator;
    private Direction direction;
    private PlayerJoystick joystick;
    public PlayerJoystick Joystick { get { return joystick; } }
    // Start is called before the first frame update
    void Start()
    {
        joystick = knob.GetComponent<PlayerJoystick>();
        direction = GetComponent<Direction>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", joystick.Direction.x);
        direction.Directions["JoyStick"] = joystick.Direction * speed;
        transform.Translate(direction.Richtung * Time.deltaTime);
    }
}
