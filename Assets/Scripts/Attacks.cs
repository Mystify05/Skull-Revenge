using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject shadowBall;
    //private Vector2 oldDirection;
    //private PlayerJoystick joystick;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        //joystick = player.GetComponent<PlayerMovement>().Joystick;
    }

    private void Update()
    {
        /*if(joystick.Direction.magnitude > joystick.DeadZone)
            oldDirection = joystick.Direction;*/
    }

    public void ShadowBall()
    {
        GameObject sb = Instantiate(shadowBall, player.transform.position, Quaternion.identity);
        //sb.transform.Rotate(0, 0, Mathf.Atan2(oldDirection.y, oldDirection.x) * Mathf.Rad2Deg - 90);
    }
}
