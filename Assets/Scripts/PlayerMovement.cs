using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Image knob;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animator;
    private PlayerJoystick joystick;
    public PlayerJoystick Joystick { get { return joystick; } }
    // Start is called before the first frame update
    void Start()
    {
        joystick = knob.GetComponent<PlayerJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", joystick.Direction.x);
        transform.Translate(joystick.Direction * Time.deltaTime * speed);
    }
}
